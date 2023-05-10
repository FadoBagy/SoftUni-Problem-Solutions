function solve_4(num) {
    let oddSum = 0;
    let evenSum = 0;
    while (num > 0) {
        let currentNumber = num % 10;
        if (currentNumber % 2 == 0) {
            evenSum += currentNumber
        } else {
            oddSum += currentNumber;
        }
        num = Math.floor(num / 10);
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
