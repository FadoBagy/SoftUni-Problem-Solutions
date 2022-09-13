function deleteByEmail() {
    let inputElement = document.querySelector('input[name="email"]');
    let tableRows = Array.from(document.querySelectorAll('tr'));
    let result = document.getElementById('result');
    let isDeleted = false;
    for (const row of tableRows) {
        if (row.textContent.includes(inputElement.value)) {
            row.remove();
            isDeleted = true;
        }
    }
    if (isDeleted) {
        result.textContent = 'Deleted.'
    } else result.textContent = 'Not found.'
}