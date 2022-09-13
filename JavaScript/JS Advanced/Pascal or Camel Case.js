function solve() {
    let inputText = document.getElementById('text').value.toLowerCase();
    let inputCase = document.getElementById('naming-convention').value;
    let result = document.getElementById('result');
    let words = inputText.split(' ');
    if (inputCase == 'Camel Case') {
        for (let word of words) {
            if (words.indexOf(word) == 0) {
                result.textContent += word.charAt(0) + word.slice(1);
            } else result.textContent += word.charAt(0).toUpperCase() + word.slice(1);
        }
    } else if (inputCase == 'Pascal Case') {
        for (let word of words) {
            result.textContent += word.charAt(0).toUpperCase() + word.slice(1);
        }
    } else result.textContent = 'Error!';
}