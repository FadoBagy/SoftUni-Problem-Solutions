function solve_20(string) {
    let words = string.split(/(?=[A-Z])/);
    console.log(words.join(', '));
}