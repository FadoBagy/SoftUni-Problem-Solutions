function attachGradientEvents() {
    let boxElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    boxElement.addEventListener('mousemove', (e) => {
        let boxWidth = e.target.clientWidth - 1;
        let currentPosition = e.offsetX;
        let percentage = currentPosition / boxWidth * 100;
        resultElement.textContent = Math.trunc(percentage) + '%';
    });
}