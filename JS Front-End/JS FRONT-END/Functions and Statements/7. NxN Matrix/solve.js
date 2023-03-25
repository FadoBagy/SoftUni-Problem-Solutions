function solve_7(num) {
    for (let i = 0; i < num; i++) {
        let row = '';
        for (let j = 0; j < num; j++) {
            row += num + ' ';
        }
        console.log(row.trimEnd());
    }
}
