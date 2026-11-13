using WorkerHub.ViewModels.Cart;

namespace WorkerHub.Services;

public enum CartAddStatus
{
    ProductNotFound,
    OutOfStockCombination,
    QuantityLimit,
    Added
}

public interface ICartService
{
    List<CartItem> GetItems();
    List<CartLine> GetLines();
    int Count();
    CartAddStatus Add(int productId, int wearSizeId, int wearColorId);
    void Remove(int productId, int wearSizeId, int wearColorId);
    void ChangeQuantity(int productId, int wearSizeId, int wearColorId, int delta);
    void Clear();
    void SetNotice(string message);
    string? ConsumeNotice();
}