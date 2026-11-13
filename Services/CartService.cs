using System.Text.Json;
using WorkerHub.Repositories;
using WorkerHub.ViewModels.Cart;

namespace WorkerHub.Services;

public class CartService(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor) : ICartService
{
    private const string SessionKey = "Cart";
    private const string NoticeKey = "CartNotice";

    private ISession Session => httpContextAccessor.HttpContext?.Session
        ?? throw new InvalidOperationException("HTTP context is not available.");

    public List<CartItem> GetItems()
    {
        var json = Session.GetString(SessionKey);
        return json is null
            ? new List<CartItem>()
            : JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
    }

    public List<CartLine> GetLines()
    {
        var lines = new List<CartLine>();

        foreach (var entry in GetItems())
        {
            var product = productRepository.Get(entry.ProductId);
            if (product is null)
                continue;

            var stock = product.ProductWearStocks.FirstOrDefault(s =>
                s.WearSizeId == entry.WearSizeId && s.WearColorId == entry.WearColorId);

            lines.Add(new CartLine
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                WearSizeId = entry.WearSizeId,
                WearColorId = entry.WearColorId,
                SizeName = stock?.WearSize?.Name ?? string.Empty,
                ColorName = stock?.WearColor?.Name ?? string.Empty,
                Quantity = entry.Quantity
            });
        }

        return lines;
    }

    public int Count()
    {
        return GetItems().Sum(c => c.Quantity);
    }

    public CartAddStatus Add(int productId, int wearSizeId, int wearColorId)
    {
        var product = productRepository.Get(productId);
        if (product is null || !product.IsAvailable)
            return CartAddStatus.ProductNotFound;

        var stock = product.ProductWearStocks.FirstOrDefault(s =>
            s.WearSizeId == wearSizeId && s.WearColorId == wearColorId);

        if (stock is null || stock.Quantity <= 0)
        {
            SetNotice("This size and color combination is out of stock.");
            return CartAddStatus.OutOfStockCombination;
        }

        var cart = GetItems();
        var existing = cart.FirstOrDefault(c =>
            c.ProductId == productId && c.WearSizeId == wearSizeId && c.WearColorId == wearColorId);

        var currentQuantity = existing?.Quantity ?? 0;
        if (currentQuantity + 1 > stock.Quantity)
        {
            SetNotice($"Only {stock.Quantity} item(s) left for this size and color.");
            return CartAddStatus.QuantityLimit;
        }

        if (existing is null)
            cart.Add(new CartItem { ProductId = productId, WearSizeId = wearSizeId, WearColorId = wearColorId, Quantity = 1 });
        else
            existing.Quantity += 1;

        SaveItems(cart);
        return CartAddStatus.Added;
    }

    public void Remove(int productId, int wearSizeId, int wearColorId)
    {
        var cart = GetItems();
        cart.RemoveAll(c => c.ProductId == productId && c.WearSizeId == wearSizeId && c.WearColorId == wearColorId);
        SaveItems(cart);
    }

    public void ChangeQuantity(int productId, int wearSizeId, int wearColorId, int delta)
    {
        var product = productRepository.Get(productId);
        if (product is null)
            return;

        var cart = GetItems();
        var existing = cart.FirstOrDefault(c =>
            c.ProductId == productId && c.WearSizeId == wearSizeId && c.WearColorId == wearColorId);

        if (existing is null)
        {
            SaveItems(cart);
            return;
        }

        var stock = product.ProductWearStocks.FirstOrDefault(s =>
            s.WearSizeId == wearSizeId && s.WearColorId == wearColorId);

        var maxQuantity = stock?.Quantity ?? 0;
        var newQuantity = Math.Min(existing.Quantity + delta, maxQuantity);

        if (maxQuantity <= 0 || newQuantity <= 0)
            cart.Remove(existing);
        else
            existing.Quantity = newQuantity;

        SaveItems(cart);
    }

    public void Clear()
    {
        Session.Remove(SessionKey);
    }

    public void SetNotice(string message)
    {
        Session.SetString(NoticeKey, message);
    }

    public string? ConsumeNotice()
    {
        var message = Session.GetString(NoticeKey);
        if (message is not null)
            Session.Remove(NoticeKey);
        return message;
    }

    private void SaveItems(List<CartItem> cart)
    {
        Session.SetString(SessionKey, JsonSerializer.Serialize(cart));
    }
}