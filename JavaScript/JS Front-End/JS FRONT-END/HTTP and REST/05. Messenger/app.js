function attachEvents() {
    const sendBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');
    const messagesEl = document.getElementById('messages');
    const baseUrl = 'http://localhost:3030/jsonstore/messenger';

    refreshBtn.addEventListener('click', () => {
        messagesEl.textContent = '';
        fetch(baseUrl)
            .then(res => res.json())
            .then((data) => {
                for (const msg in data) {
                    let { author, content } = data[msg];
                    messagesEl.textContent += `${author}: ${content}\n`;
                }
                messagesEl.textContent = messagesEl.textContent.trimEnd();
            })
            .catch(err => console.log(err));
    });
    sendBtn.addEventListener('click', () => {
        const nameInputEl = document.querySelector('input[name="author"]');
        const contentInputEl = document.querySelector('input[name="content"]');

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                author: nameInputEl.value,
                content: contentInputEl.value
            })
        });

        nameInputEl.value = '';
        contentInputEl.value = '';
    });
}

attachEvents();