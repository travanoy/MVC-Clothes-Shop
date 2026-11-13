function updateFavoriteHeart(form, isFavorite) {
    var button = form.querySelector('button');
    if (!button) return;

    button.classList.toggle('btn-danger', isFavorite);
    button.title = isFavorite ? 'Remove from favorites' : 'Add to favorites';
    button.innerHTML = isFavorite ? '❤️' : '🤍';
}

document.addEventListener('click', function (event) {
    var form = event.target.closest('.js-favorite-form');
    if (!form) return;

    event.preventDefault();

    fetch(form.action, {
        method: 'POST',
        credentials: 'same-origin',
        redirect: 'manual',
        headers: { 'X-Requested-With': 'XMLHttpRequest' },
        body: new FormData(form)
    }).then(function (response) {
        if (response.type === 'opaqueredirect') {
            window.location.href = form.action;
            return null;
        }
        if (!response.ok) throw new Error('Request failed');
        return response.json();
    }).then(function (data) {
        if (data) updateFavoriteHeart(form, data.isFavorite);
    }).catch(function () {});
});