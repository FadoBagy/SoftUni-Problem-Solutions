function solve(array) {
    let foodinfo = {}
    for (let i = 0; i < array.length; i++) {
        if (i % 2 == 0) {
            foodinfo[array[i]] = Number(array[i + 1]);
        }
    }
    console.log(foodinfo);
}