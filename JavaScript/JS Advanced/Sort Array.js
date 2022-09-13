function solution(array, sortingOrder) {
    if (sortingOrder == 'asc') {
        return array.sort((a, b) => a - b);
    } else if (sortingOrder == 'desc') {
        return array.sort((a, b) => b - a);
    }
}