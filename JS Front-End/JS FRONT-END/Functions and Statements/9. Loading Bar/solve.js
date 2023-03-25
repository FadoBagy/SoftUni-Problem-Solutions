function solve_9(number) {
    const numBars = number / 10;
    const emptyBars = 10 - numBars;
    if (number != 100) {
        console.log(`${number}% [${'%'.repeat(numBars)}${'.'.repeat(emptyBars)}]`);
        console.log('Still loading...');
    } else {
        console.log('100% Complete!');
        console.log('[%%%%%%%%%%]');
    }
}
