function solve(area, vol, input) {
    let coordiantes = JSON.parse(input);
    let resultObject = [];
    for (const object of coordiantes) {
        resultObject.push({
            area: area.call(object),
            volume: vol.call(object)
        });
    }
    return resultObject;
}