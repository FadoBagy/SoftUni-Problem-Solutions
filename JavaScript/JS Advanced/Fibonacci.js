function getFibonator() {
    let num1 = undefined;
    let num2 = 0;
    return function () {
        if (num1 == undefined) {
            console.log(0);
            result = 1 + num2;
        } else result = num1 + num2;
        num1 = num2;
        num2 = result;
        return result
    }
}