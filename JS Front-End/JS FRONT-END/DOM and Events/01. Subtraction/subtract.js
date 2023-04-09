function subtract() {
    const firstNumberEl = document.getElementById('firstNumber');
    const secondNumberEl = document.getElementById('secondNumber');
    const resultEl = document.getElementById('result');

    resultEl.textContent = firstNumberEl.value - secondNumberEl.value;
}