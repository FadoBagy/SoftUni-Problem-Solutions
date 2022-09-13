function solve(array, number) {
    let newArray = [];
    for (let i = 0; i < array.length; i += number) {
        newArray.push(array[i]);
    }
    return newArray;
}