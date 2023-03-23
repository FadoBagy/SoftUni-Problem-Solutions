function solve_19(word, string) {
    let words = string.split(' ');
    for (let i = 0; i < words.length; i++) {
        if (words[i].toLowerCase() == word.toLowerCase()) {
            console.log(word);
            return;
        }
    }
    console.log(`${word} not found!`);
}