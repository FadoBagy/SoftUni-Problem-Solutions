function subtract() {
    let num1Element = document.getElementById('firstNumber').value;
    let num2Element = document.getElementById('secondNumber').value;
    let resultElement = document.getElementById('result');
    return resultElement.textContent = Number(num1Element) - Number(num2Element);
}