function solve(array) {
    let newArray = [];
    for (let i = 0; i < array.length; i++) {
        if (array[i] < 0) {
            newArray.unshift(array[i]);
        } else newArray.push(array[i]);
    }
    newArray.forEach(element => {
        console.log(element);
    });
}