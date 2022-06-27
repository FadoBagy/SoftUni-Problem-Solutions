function solve(array, startIndex, endIndex) {
    let sum = 0;

    if (!Array.isArray(array)) {
        return NaN;
    }

    let start = Math.max(startIndex, 0);
    let end = Math.min(endIndex, array.length - 1);

    for (let i = start; i <= end; i++) {
        sum += Number(array[i]);
    }

    return sum;
}