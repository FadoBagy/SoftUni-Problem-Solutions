function solve_3(char1, char2) {
    let code1 = char1.charCodeAt(0);
    let code2 = char2.charCodeAt(0);

    let startCode, endCode;
    if (code1 <= code2) {
        startCode = code1 + 1;
        endCode = code2 - 1;
    } else {
        startCode = code2 + 1;
        endCode = code1 - 1;
    }

    let output = '';
    for (let i = startCode; i <= endCode; i++) {
        output += String.fromCharCode(i) + ' ';
    }
    console.log(output.trimEnd());
}
