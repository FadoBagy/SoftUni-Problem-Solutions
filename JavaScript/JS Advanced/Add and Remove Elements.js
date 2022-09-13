function solve(array) {
    let newArray = [];
    let initialNumber = 1;
    for (const command of array) {
        switch (command) {
            case 'add':
                newArray.push(initialNumber);
                initialNumber++;
                break;
            case 'remove':
                if (newArray.length > 0) {
                    newArray.pop();
                }
                initialNumber++;
                break;
        }
    }
    if (newArray.length > 0) {
        for (const number of newArray) {
            console.log(number);
        }
    } else console.log('Empty');
}