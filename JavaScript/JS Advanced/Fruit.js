function solve(input, inpu2, input3) {
    let fruit = input;
    let kg = inpu2 / 1000;
    let price = input3;
    let moneyNeeded = price * kg;

    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
}
