function toggle() {
    let hiddenTextElement = document.getElementById('extra');
    let buttonElement = document.querySelector('.button');
    if (buttonElement.textContent == 'More') {
        buttonElement.textContent = 'Less';
        hiddenTextElement.style.display = 'block';
    } else if (buttonElement.textContent == 'Less') {
        buttonElement.textContent = 'More';
        hiddenTextElement.style.display = 'none';
    }
}