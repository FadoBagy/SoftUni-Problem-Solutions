function solve(number, number2) {
    let num1 = number;
    let num2 = number2;
    let highestDevider = 0;
    for (let index = 0; index < 10; index++) {
        if (num1 % index == 0 && num2 % index == 0) {
            highestDevider = index;
        }
    }
    console.log(highestDevider);
}