function attachEvents() {
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');
    const contactListEl = document.getElementById('phonebook');
    const baseUrl = 'http://localhost:3030/jsonstore/phonebook/';

    loadBtn.addEventListener('click', loadContacts);
    createBtn.addEventListener('click', () => {
        const personInput = document.getElementById('person');
        const phoneInput = document.getElementById('phone');

        if (
            personInput.value != null &&
            phoneInput.value != null &&
            personInput.value != '' &&
            phoneInput.value != '') {
            fetch(baseUrl, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json',
                },
                body: JSON.stringify({
                    person: personInput.value,
                    phone: phoneInput.value
                })
            })
                .then(loadContacts);
            personInput.value = '';
            phoneInput.value = '';
        }
    });
    function loadContacts() {
        fetch(baseUrl)
            .then(res => res.json())
            .then((data) => {
                contactListEl.innerHTML = '';
                for (const contact in data) {
                    const { person, phone, _id } = data[contact];
                    let li = document.createElement('li');
                    li.textContent = `${person}: ${phone}`;
                    let btn = document.createElement('button');
                    btn.textContent = 'Delete';
                    btn.addEventListener('click', () => {
                        fetch(baseUrl + _id, {
                            method: 'DELETE'
                        });
                    });
                    li.appendChild(btn);
                    contactListEl.appendChild(li);
                }
            });
    };
}

attachEvents();