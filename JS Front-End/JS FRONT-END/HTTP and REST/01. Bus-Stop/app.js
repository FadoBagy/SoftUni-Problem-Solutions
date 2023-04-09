function getInfo() {
    const inputEl = document.getElementById('stopId');
    const stopNameEl = document.getElementById('stopName');
    const busesInfoEl = document.getElementById('buses');

    busesInfoEl.innerHTML = '';
    fetch(`http://localhost:3030/jsonstore/bus/businfo/${inputEl.value}`)
        .then(res => res.json())
        .then((data) => {
            stopNameEl.textContent = data.name;
            for (const busId in data.buses) {
                let li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${data.buses[busId]} minutes`;
                busesInfoEl.appendChild(li);
            }
        })
        .catch(() => stopNameEl.textContent = 'Error');
}