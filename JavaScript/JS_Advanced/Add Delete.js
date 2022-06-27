function addItem() {
    let listElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');

    let newListItemElement = document.createElement('li');
    newListItemElement.textContent = inputElement.value;
    inputElement.value = '';

    let newDeleteElement = document.createElement('a');
    newDeleteElement.href = '#';
    newDeleteElement.textContent = '[Delete]';
    newDeleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });

    newListItemElement.appendChild(newDeleteElement);
    listElement.appendChild(newListItemElement);
}