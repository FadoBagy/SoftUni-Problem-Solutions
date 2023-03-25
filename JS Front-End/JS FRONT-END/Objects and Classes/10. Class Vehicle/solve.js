class Vehicle {
    constructor(type, model, parts, fuel) {
        this.type = type;
        this.model = model;
        this.parts = parts;
        this.fuel = fuel;
    }
    drive(fuelLoss) {
        this.fuel -= fuelLoss;
    }
    get parts() {
        return this._parts;
    }
    set parts(value) {
        this._parts = {
            engine: value.engine,
            power: value.power,
            quality: value.engine * value.power
        };
    }
}