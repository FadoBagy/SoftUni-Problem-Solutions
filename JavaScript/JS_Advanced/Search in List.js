function search() {
    let text = document.getElementById('searchText').value;
    let listItemsElements = Array.from(document.querySelectorAll('#towns li'));
    let result = document.getElementById('result');
    let count = 0;
    for (const town of listItemsElements) {
        if (town.textContent.includes(text)) {
            town.style.fontWeight = 'bold';
            town.style.textDecoration = 'underline';
            count++;
        } else {
            town.style.fontWeight = 'normal';
            town.style.textDecoration = 'none';
        }
    }
    result.textContent = `${count} matches found`;
}