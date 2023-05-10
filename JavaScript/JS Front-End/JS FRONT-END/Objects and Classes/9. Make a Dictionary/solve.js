function solve_9(arr) {
    let dictionary = {};
    for (let i = 0; i < arr.length; i++) {
        let obj = JSON.parse(arr[i]);
        let term = Object.keys(obj)[0];
        let definition = obj[term];
        dictionary[term] = definition;
    }

    let sortedKeys = Object.keys(dictionary).sort();
    for (let i = 0; i < sortedKeys.length; i++) {
        let term = sortedKeys[i];
        let definition = dictionary[term];
        console.log(`Term: ${term} => Definition: ${definition}`);
    }
}
