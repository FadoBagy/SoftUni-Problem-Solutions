function solve_13(arr, rotations) {
    for (let i = 0; i < rotations; i++) {
        let rotatedNumber = arr.shift();
        arr.push(rotatedNumber);
    }
    console.log(arr.join(' '));
}