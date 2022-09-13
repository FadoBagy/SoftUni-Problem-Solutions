function colorize() {
    let tableItems = document.querySelectorAll('table tr');
    let index = 1;
    for (const item of tableItems) {
        if (index % 2 == 0) {
            item.style.backgroundColor = 'teal';
        }
        index++;
    }
}