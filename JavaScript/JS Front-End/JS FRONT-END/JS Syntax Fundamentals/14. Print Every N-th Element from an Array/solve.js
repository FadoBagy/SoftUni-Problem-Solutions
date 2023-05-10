function solve_14(arr, n) {
    let result = arr.filter((_, i) => (i + 1) % n === 1)
    console.log(result.join('\n'));
}