function solve(carInfo) {
    let finishedCar = {};
    finishedCar.model = carInfo.model;
    if (carInfo.power <= 90) {
        finishedCar.engine = {
            power: 90,
            volume: 1800,
        }
    } else if (carInfo.power > 90 && carInfo.power <= 120) {
        finishedCar.engine = {
            power: 120,
            volume: 2400,
        }
    } else {
        finishedCar.engine = {
            power: 200,
            volume: 3500,
        }
    }
    finishedCar.carriage = {
        type: carInfo.carriage,
        color: carInfo.color,
    }
    if (carInfo.wheelsize % 2 == 0) {
        carInfo.wheelsize -= 1;
    }
    let wheels = [];
    for (let i = 0; i < 4; i++) {
        wheels.push(carInfo.wheelsize);
    }
    finishedCar.wheels = wheels;
    return finishedCar;
}