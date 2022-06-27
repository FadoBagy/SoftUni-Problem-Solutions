function solution() {
    let typesCounterObject = {};
    for (const input of arguments) {
        console.log(`${typeof input}: ${input}`);
        if (!typesCounterObject[`${typeof input}`]) {
            typesCounterObject[`${typeof input}`] = 0;
        }
        typesCounterObject[`${typeof input}`]++;

    }
    Object.keys(typesCounterObject)
        .sort((a, b) => typesCounterObject[b] - typesCounterObject[a])
        .forEach((key) => console.log(`${key} = ${typesCounterObject[key]}`))
}