function solve() {
    const departBtnEl = document.getElementById('depart');
    const arriveBtnEl = document.getElementById('arrive');
    const infoEl = document.querySelector('.info');
    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule/';
    let nextStopId = '';
    let currentStopName = '';

    function depart() {
        departBtnEl.disabled = true;
        arriveBtnEl.disabled = false;

        fetch(baseUrl + `${nextStopId != '' ? nextStopId : 'depot'}`)
            .then(res => res.json())
            .then(({ next, name }) => {
                nextStopId = next;
                currentStopName = name;
                infoEl.textContent = `Next stop ${name}`;
            })
            .catch(() => infoEl.textContent = 'Error');
    }

    async function arrive() {
        departBtnEl.disabled = false;
        arriveBtnEl.disabled = true;

        infoEl.textContent = `Arriving at ${currentStopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();