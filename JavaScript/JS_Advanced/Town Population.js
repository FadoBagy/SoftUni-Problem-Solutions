function solve(array) {
    let citiesObjectList = [];
    for (let i = 0; i < array.length; i++) {
        let currentCity = {};
        currentCity.name = array[i].split(' <-> ')[0];
        currentCity.population = Number(array[i].split(' <-> ')[1]);
        if (citiesObjectList.some(e => e.name == currentCity.name)) {
            citiesObjectList.find(e => e.name == currentCity.name).population += currentCity.population;
        } else citiesObjectList.push(currentCity);
    }
    for (const city of citiesObjectList) {
        console.log(`${city.name} : ${city.population}`);
    }
}