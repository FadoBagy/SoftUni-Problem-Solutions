function solve_2(num1, num2, num3) {
    function sum(number1, number2) {
        return number1 + number2;
    }
    function subtract(number1, number2) {
        return number1 - number2;
    }
    console.log(subtract(sum(num1, num2), num3));
};
