function solve_10(num1, num2) {
    function findFactorial(number) {
        let result = 1;
        for (let i = 1; i <= number; i++) {
            result *= i;
        }
        return result;
    }
    console.log((findFactorial(num1) / findFactorial(num2)).toFixed(2));
}
