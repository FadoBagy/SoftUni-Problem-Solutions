window.addEventListener('load', solve);

function solve() {
    const createBtn = document.getElementById('create-task-btn');
    const deleteTaskBtn = document.getElementById('delete-task-btn');

    const taskSectionEl = document.getElementById('tasks-section');
    const totalPointsEl = document.getElementById('total-sprint-points');
    const taskId = document.getElementById('task-id');

    let tasksCount = 1;
    let totalPoints = 0;

    createBtn.addEventListener('click', () => {
        const { title, description, label, points, assignee } = getInputFields();
        if (title.value != '' && title.value != null &&
            description.value != '' && description.value != null &&
            label.value != '' && label.value != null &&
            points.value != '' && points.value != null &&
            assignee.value != '' && assignee.value != null) {
            //Creating a new article (task)
            let newArticle = document.createElement('article');
            newArticle.setAttribute('id', `task-${tasksCount++}`)
            newArticle.classList.add('task-card');

            let feature = document.createElement('div');
            feature.classList.add('task-card-label');
            if (label.value == 'Feature') {
                feature.innerHTML = label.value + ' &#8865';
                feature.classList.add('feature');
            } else if (label.value == 'Low Priority Bug') {
                feature.innerHTML = label.value + ' &#9737';
                feature.classList.add('low-priority');
            } else if (label.value == 'High Priority Bug') {
                feature.innerHTML = label.value + ' &#9888';
                feature.classList.add('high-priority');
            }
            newArticle.appendChild(feature);

            let titleH3 = document.createElement('h3');
            titleH3.classList.add('task-card-title');
            titleH3.textContent = title.value;
            newArticle.appendChild(titleH3);

            let descriptionP = document.createElement('p');
            descriptionP.classList.add('task-card-description');
            descriptionP.textContent = description.value;
            newArticle.appendChild(descriptionP);

            let pointsDiv = document.createElement('div');
            pointsDiv.classList.add('task-card-points');
            pointsDiv.textContent = `Estimated at ${points.value} pts`;
            newArticle.appendChild(pointsDiv);

            let assigneeDiv = document.createElement('div');
            assigneeDiv.classList.add('task-card-assignee');
            assigneeDiv.textContent = `Assigned to : ${assignee.value}`;
            newArticle.appendChild(assigneeDiv);

            let actionsDiv = document.createElement('div');
            actionsDiv.classList.add('task-card-actions');
            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', () => {
                deleteTaskBtn.disabled = false;
                createBtn.disabled = true;

                title.value = titleH3.textContent;
                description.value = descriptionP.textContent;
                label.value = feature.textContent.replace(/[^a-zA-Z0-9 ]/g, '').trimEnd();
                points.value = pointsDiv.textContent
                    .substring(pointsDiv.textContent.indexOf('at ') + 3, pointsDiv.textContent.indexOf(' pts'));
                assignee.value = assigneeDiv.textContent.split(':')[1].trim();
                taskId.value = newArticle.getAttribute('id').match(/\d+/)[0]

                title.disabled = true;
                description.disabled = true;
                label.disabled = true;
                points.disabled = true;
                assignee.disabled = true;
            });
            actionsDiv.appendChild(deleteBtn);
            newArticle.appendChild(actionsDiv);

            taskSectionEl.appendChild(newArticle);

            totalPoints += Number(points.value);
            totalPointsEl.textContent = `Total Points ${totalPoints}pts`;
            resetInput(title, description, label, points, assignee);
        };
    });
    deleteTaskBtn.addEventListener('click', () => {
        const { title, description, label, points, assignee } = getInputFields();

        const currentTaskId = document.getElementById('task-id');
        const task = document.querySelector(`#tasks-section article[id="task-${currentTaskId.value}"]`);
        if (task) {
            taskSectionEl.removeChild(task);
            totalPoints -= Number(points.value);
            totalPointsEl.textContent = `Total Points ${totalPoints}pts`;

            resetInput(title, description, label, points, assignee);

            title.disabled = false;
            description.disabled = false;
            label.disabled = false;
            points.disabled = false;
            assignee.disabled = false;

            deleteTaskBtn.disabled = true;
            createBtn.disabled = false;
        }
    });

    function resetInput(title, description, label, points, assignee) {
        title.value = '';
        description.value = '';
        label.value = '';
        points.value = '';
        assignee.value = '';
        taskId.value = '';
    }

    function getInputFields() {
        return {
            title: document.getElementById('title'),
            description: document.getElementById('description'),
            label: document.getElementById('label'),
            points: document.getElementById('points'),
            assignee: document.getElementById('assignee'),
        };
    }
}