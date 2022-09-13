function attachEvents() {
    let authorInputElement = document.querySelector('#controls input[name="author"]');
    let contentInputElement = document.querySelector('#controls input[name="content"]');
    let messagesElement = document.getElementById('messages');
    let submitButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');

    let url = 'http://localhost:3030/jsonstore/messenger';

    function refreshMessages() {
        fetch(url)
            .then(res => res.json())
            .then((messageData) => {
                messagesElement.innerHTML = '';
                for (const message of Object.values(messageData)) {
                    messagesElement.textContent += `${message.author}: ${message.content}\n`;
                }
            })
    }

    refreshButton.addEventListener('click', () => {
        refreshMessages();
    });

    submitButton.addEventListener('click', () => {
        if (authorInputElement.value != '' && contentInputElement.value != '') {
            fetch(url, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    author: authorInputElement.value,
                    content: contentInputElement.value
                })
            });
            authorInputElement.value = '';
            contentInputElement.value = '';
            refreshMessages();
        }
    })
}

attachEvents();