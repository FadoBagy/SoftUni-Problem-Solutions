function addItem() {
    let inputBoxElement = document.getElementById('newItemText');
    let itemListElement = document.getElementById('items');
    let newListItem = document.createElement('li');
    newListItem.textContent = inputBoxElement.value;
    itemListElement.appendChild(newListItem);

}