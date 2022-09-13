function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);

    function onClick() {
        let userInputElement = document.getElementById('searchField');
        let tableContent = Array.from(document.querySelectorAll('tbody tr'));
        for (const content of tableContent) {
            content.classList.remove('select');
            if (content.textContent.includes(userInputElement.value) && userInputElement.value != '') {
                content.className = 'select';
            }
        }
        userInputElement.value = '';
    }
}