function create(words) {
    let resultDiv = document.getElementById('content');

    for (const div of words) {
        let newDivElement = document.createElement('div')
        newDivElement.addEventListener('click', (e) => {
            newPElement.style.display = 'block';
        });

        let newPElement = document.createElement('p');
        newPElement.style.display = 'none';
        newPElement.textContent = div;

        newDivElement.appendChild(newPElement);
        resultDiv.appendChild(newDivElement);

    }
}