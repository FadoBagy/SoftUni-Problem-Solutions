function solve(array) {
    let result = '';
    for (let index = 0; index < array.length; index++) {
        if (index % 2 == 0) {
            result += array[index] + ' ';
        }
    }
    console.log(result);
}