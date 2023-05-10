function solve_18(string) {
    let words = string.split(' ');
    let specialWords = words.filter((word) => word.startsWith('#'));
    let validSpecialWords = specialWords
        .map((word) => word.slice(1))
        .filter((word) => /^[a-zA-Z]+$/.test(word));
    validSpecialWords.forEach((word) => console.log(word));
}