function attachEvents() {
    const loadBoardBtn = document.getElementById('load-board-btn');
    const createTaskBtn = document.getElementById('create-task-btn');

    const todoSection = document.querySelector('#todo-section ul');
    const inProgressSection = document.querySelector('#in-progress-section ul');
    const codeReviewSection = document.querySelector('#code-review-section ul');
    const doneSection = document.querySelector('#done-section ul');

    const baseUrl = 'http://localhost:3030/jsonstore/tasks/';

    loadBoardBtn.addEventListener('click', loadTasks);

    createTaskBtn.addEventListener('click', () => {
        const title = document.getElementById('title');
        const description = document.getElementById('description');

        if (title.value.trim() != '' && title.value.trim() != null && description.value.trim() != '' && description.value.trim() != null) {
            fetch(baseUrl, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json',
                },
                body: JSON.stringify({
                    title: title.value,
                    description: description.value,
                    status: 'ToDo'
                })
            })
                .then(loadTasks)
                .catch((error) => console.error(error));
        }
        title.value = '';
        description.value = '';
    });

    function loadTasks() {
        fetch(baseUrl)
            .then(res => res.json())
            .then((data) => {
                todoSection.innerHTML = '';
                inProgressSection.innerHTML = '';
                codeReviewSection.innerHTML = '';
                doneSection.innerHTML = '';
                for (const task in data) {
                    createTaskElement(data[task]);
                }
            })
            .catch((error) => console.error(error));
    }

    function createTaskElement(task) {
        const { title, description, _id, status } = task;

        let li = document.createElement('li');
        li.classList.add('task');

        let h3 = document.createElement('h3');
        h3.textContent = title;
        li.appendChild(h3);

        let p = document.createElement('p');
        p.textContent = description;
        li.appendChild(p);

        let button = document.createElement('button');
        li.appendChild(button);

        switch (status) {
            case 'ToDo':
                button.textContent = 'Move to In Progress';
                button.addEventListener('click', () => {
                    fetch(`${baseUrl}${_id}`, {
                        method: 'PATCH',
                        headers: {
                            'content-type': 'application/json'
                        },
                        body: JSON.stringify({
                            status: 'In Progress'
                        })
                    })
                        .then(loadTasks)
                        .catch((error) => console.error(error));
                });
                todoSection.appendChild(li);
                break;
            case 'In Progress':
                button.textContent = 'Move to Code Review';
                button.addEventListener('click', () => {
                    fetch(`${baseUrl}${_id}`, {
                        method: 'PATCH',
                        headers: {
                            'content-type': 'application/json'
                        },
                        body: JSON.stringify({
                            status: 'Code Review'
                        })
                    })
                        .then(loadTasks)
                        .catch((error) => console.error(error));
                });
                inProgressSection.appendChild(li);
                break;
            case 'Code Review':
                button.textContent = 'Move to Done';
                button.addEventListener('click', () => {
                    fetch(`${baseUrl}${_id}`, {
                        method: 'PATCH',
                        headers: {
                            'content-type': 'application/json'
                        },
                        body: JSON.stringify({
                            status: 'Done'
                        })
                    })
                        .then(loadTasks)
                        .catch((error) => console.error(error));
                });
                codeReviewSection.appendChild(li);
                break;
            case 'Done':
                button.textContent = 'Close';
                button.addEventListener('click', () => {
                    fetch(`${baseUrl}${_id}`, {
                        method: 'DELETE'
                    })
                        .then(loadTasks)
                        .catch((error) => console.error(error));
                });
                doneSection.appendChild(li);
                break;
        }
    }
}

attachEvents();