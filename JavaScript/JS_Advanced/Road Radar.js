function solve(speed, area) {
    if (area == 'motorway') {
        if (speed > 130) {
            let speedingSize = speed - 130;
            let status = '';
            if (speedingSize <= 20) {
                status = 'speeding';
            } else if (speedingSize > 20 && speedingSize <= 40) {
                status = 'excessive speeding';
            } else status = 'reckless driving';
            console.log(`The speed is ${speedingSize} km/h faster than the allowed speed of 130 - ${status}`);
        } else console.log(`Driving ${speed} km/h in a 130 zone`);
    } else if (area == 'interstate') {
        if (speed > 90) {
            let speedingSize = speed - 90;
            let status = '';
            if (speedingSize <= 20) {
                status = 'speeding';
            } else if (speedingSize > 20 && speedingSize <= 40) {
                status = 'excessive speeding';
            } else status = 'reckless driving';
            console.log(`The speed is ${speedingSize} km/h faster than the allowed speed of 90 - ${status}`);
        } else console.log(`Driving ${speed} km/h in a 90 zone`);
    } else if (area == 'city') {
        if (speed > 50) {
            let speedingSize = speed - 50;
            let status = '';
            if (speedingSize <= 20) {
                status = 'speeding';
            } else if (speedingSize > 20 && speedingSize <= 40) {
                status = 'excessive speeding';
            } else status = 'reckless driving';
            console.log(`The speed is ${speedingSize} km/h faster than the allowed speed of 50 - ${status}`);
        } else console.log(`Driving ${speed} km/h in a 50 zone`);
    } else if (area == 'residential') {
        if (speed > 20) {
            let speedingSize = speed - 20;
            let status = '';
            if (speedingSize <= 20) {
                status = 'speeding';
            } else if (speedingSize > 20 && speedingSize <= 40) {
                status = 'excessive speeding';
            } else status = 'reckless driving';
            console.log(`The speed is ${speedingSize} km/h faster than the allowed speed of 20 - ${status}`);
        } else console.log(`Driving ${speed} km/h in a 20 zone`);
    }
}