function solve(number) {
    let num = number.toString();
    let numberToCheck = num[0];
    let areTheSame = true;
    let sumOfDigits = 0;
    for (let index = 0; index < num.length; index++) {
        if (num[index] != numberToCheck) {
            areTheSame = false;
        }
        sumOfDigits += Number(num[index]);
    }
    if (areTheSame == true) {
        console.log(true);
    } else { console.log(false); }
    console.log(sumOfDigits);
}