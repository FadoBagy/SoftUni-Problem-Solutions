function solve(arr) {
    let board = {};

    for (let i = 1; i <= arr[0]; i++) {
        let [assignee, taskId, title, status, estimatedPoints] = arr[i].split(':');
        (board[assignee] || (board[assignee] = [])).push({
            taskId,
            title,
            status,
            estimatedPoints: Number.parseInt(estimatedPoints)
        });
    };
    for (let i = Number(arr[0]) + 1; i < arr.length; i++) {
        let [command, assignee, idOrIndex, newStatusOrTask] = arr[i].split(':');
        switch (command) {
            case 'Add New':
                let [_command, _assignee, _taskId, _title, _status, _estimatedPoints] = arr[i].split(':');
                if (!board[assignee]) {
                    handleMissingAssignee(assignee);
                    continue;
                };
                board[assignee].push({
                    taskId: _taskId,
                    title: _title,
                    status: _status,
                    estimatedPoints: Number(_estimatedPoints)
                });
                break;
            case 'Change Status':
                if (!board[assignee]) {
                    handleMissingAssignee(assignee);
                    continue;
                };
                let task = board[assignee].find(task => task.taskId === idOrIndex);
                if (!task) {
                    console.log(`Task with ID ${idOrIndex} does not exist for ${assignee}!`);
                } else {
                    task.status = newStatusOrTask;
                };
                break;
            case 'Remove Task':
                if (!board[assignee]) {
                    handleMissingAssignee(assignee);
                    continue;
                }
                let index = Number(idOrIndex);
                if (index < 0 || index >= board[assignee].length) {
                    console.log('Index is out of range!');
                    continue;
                };
                board[assignee].splice(index, 1);
                break;
            default:
                console.log(`Unknown command: ${command}`);
                break;
        };
    };

    let statusPoints = {
        'ToDo': 0,
        'In Progress': 0,
        'Code Review': 0,
        'Done': 0
    };
    for (let assignee in board) {
        for (let task of board[assignee]) {
            statusPoints[task.status] += task.estimatedPoints;
        };
    };

    console.log(`ToDo: ${statusPoints['ToDo']}pts`);
    console.log(`In Progress: ${statusPoints['In Progress']}pts`);
    console.log(`Code Review: ${statusPoints['Code Review']}pts`);
    console.log(`Done Points: ${statusPoints['Done']}pts`);
    if (statusPoints['Done'] >= (statusPoints['ToDo'] + statusPoints['In Progress'] + statusPoints['Code Review'])) {
        console.log('Sprint was successful!');
    } else {
        console.log('Sprint was unsuccessful...');
    };

    function handleMissingAssignee(assignee) {
        console.log(`Assignee ${assignee} does not exist on the board!`);
    };
}

solve([
    '5',
    'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',
    'Mariya:BOP-1210:Fix Major Bug:In Progress:3',
    'Peter:BOP-1211:POC:Code Review:5',
    'Georgi:BOP-1212:Investigation Task:Done:2',
    'Mariya:BOP-1213:New Account Page:In Progress:13',
    'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',
    'Change Status:Peter:BOP-1290:ToDo',
    'Remove Task:Mariya:1',
    'Remove Task:Joro:1',
]);