function solve(array) {
    array.sort((a, b) => a - b);
    let times = array.length;
    let resultArray = [];
    while (array.length > 0) {
        resultArray.push(array.shift());
        resultArray.push(array.pop());
    }
    return resultArray;
}