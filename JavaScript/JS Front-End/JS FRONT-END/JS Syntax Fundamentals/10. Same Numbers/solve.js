function solve_10(number) {
    let sum = 0;
    let allSame = true;
    let previousNumber;
    while (number > 0) {
        if (previousNumber != number % 10 && previousNumber != undefined) {
            allSame = false;
        } else {
            previousNumber = number % 10;
        }
        sum += number % 10;
        number = Math.floor(number / 10);
    }
    console.log(allSame);
    console.log(sum);
}