function solution() {
    let microelements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };
    return (inputString) => {
        let input = inputString.split(' ');
        if (input[0] == 'restock') {
            microelements[input[1]] += Number(input[2]);
            return 'Success';
        } else if (input[0] == 'prepare') {
            let [requiredProtein, requiredCarbohydrate, requiredFat, requiredFlavour] = [0, 0, 0, 0]
            if (input[1] == 'apple') {
                requiredCarbohydrate = 1 * input[2];
                requiredFlavour = 2 * input[2];
                if (microelements.carbohydrate >= requiredCarbohydrate && microelements.flavour >= requiredFlavour) {
                    microelements.carbohydrate -= requiredCarbohydrate;
                    microelements.flavour -= requiredFlavour;
                    return 'Success';
                } else {
                    if (microelements.carbohydrate < requiredCarbohydrate) {
                        return 'Error: not enough carbohydrate in stock';
                    } else if (microelements.flavour < requiredFlavour) {
                        return 'Error: not enough flavour in stock';
                    }
                }

            } else if (input[1] == 'lemonade') {
                requiredCarbohydrate = 10 * input[2];
                requiredFlavour = 20 * input[2];
                if (microelements.carbohydrate >= requiredCarbohydrate && microelements.flavour >= requiredFlavour) {
                    microelements.carbohydrate -= requiredCarbohydrate;
                    microelements.flavour -= requiredFlavour;
                    return 'Success';
                } else {
                    if (microelements.carbohydrate < requiredCarbohydrate) {
                        return 'Error: not enough carbohydrate in stock';
                    } else if (microelements.flavour < requiredFlavour) {
                        return 'Error: not enough flavour in stock';
                    }
                }
            } else if (input[1] == 'burger') {
                requiredCarbohydrate = 5 * input[2];
                requiredFat = 7 * input[2];
                requiredFlavour = 3 * input[2];
                if (microelements.carbohydrate >= requiredCarbohydrate && microelements.fat >= requiredFat && microelements.flavour >= requiredFlavour) {
                    microelements.carbohydrate -= requiredCarbohydrate;
                    microelements.fat -= requiredFat;
                    microelements.flavour -= requiredFlavour;
                    return 'Success';
                } else {
                    if (microelements.carbohydrate < requiredCarbohydrate) {
                        return 'Error: not enough carbohydrate in stock';
                    } else if (microelements.fat < requiredFat) {
                        return 'Error: not enough fat in stock';
                    }
                    else if (microelements.flavour < requiredFlavour) {
                        return 'Error: not enough flavour in stock';
                    }
                }
            } else if (input[1] == 'eggs') {
                requiredProtein = 5 * input[2];
                requiredFat = 1 * input[2];
                requiredFlavour = 1 * input[2];
                if (microelements.protein >= requiredProtein && microelements.fat >= requiredFat && microelements.flavour >= requiredFlavour) {
                    microelements.protein -= requiredProtein;
                    microelements.fat -= requiredFat;
                    microelements.flavour -= requiredFlavour;
                    return 'Success';
                } else {
                    if (microelements.protein < requiredProtein) {
                        return 'Error: not enough protein in stock';
                    } else if (microelements.fat < requiredFat) {
                        return 'Error: not enough fat in stock';
                    }
                    else if (microelements.flavour < requiredFlavour) {
                        return 'Error: not enough flavour in stock';
                    }
                }
            } else if (input[1] == 'turkey') {
                requiredProtein = 10 * input[2];
                requiredCarbohydrate = 10 * input[2];
                requiredFat = 10 * input[2];
                requiredFlavour = 10 * input[2];
                if (microelements.protein >= requiredProtein && microelements.carbohydrate >= requiredCarbohydrate && microelements.fat >= requiredFat && microelements.flavour >= requiredFlavour) {
                    microelements.protein -= requiredProtein;
                    microelements.carbohydrate -= requiredCarbohydrate;
                    microelements.fat -= requiredFat;
                    microelements.flavour -= requiredFlavour;
                    return 'Success';
                } else {
                    if (microelements.protein < requiredProtein) {
                        return 'Error: not enough protein in stock';
                    } else if (microelements.carbohydrate < requiredCarbohydrate) {
                        return 'Error: not carbohydrate fat in stock';
                    } else if (microelements.fat < requiredFat) {
                        return 'Error: not enough fat in stock';
                    }
                    else if (microelements.flavour < requiredFlavour) {
                        return 'Error: not enough flavour in stock';
                    }
                }
            }
        } else if (input[0] == 'report') {
            return `protein=${microelements.protein} carbohydrate=${microelements.carbohydrate} fat=${microelements.fat} flavour=${microelements.flavour}`;
        }
    }
}