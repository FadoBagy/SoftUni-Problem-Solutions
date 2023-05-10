function solve_5(arr) {
    for (const numer of arr) {
        let isPalindrome = true;
        let reversedNumber = Array.from(numer.toString()).reverse();
        for (let i = 0; i < reversedNumber.length; i++) {
            if (Array.from(numer.toString())[i] != reversedNumber[i]) {
                isPalindrome = false;
            }
        }
        if (isPalindrome) {
            console.log(true);
        } else {
            console.log(false);
        }
    }
}
