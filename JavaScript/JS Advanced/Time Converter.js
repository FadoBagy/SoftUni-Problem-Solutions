function attachEventsListeners() {
    let btnElements = document.querySelectorAll('input[value="Convert"]');
    let daysInputElement = document.getElementById('days');
    let hoursInputElement = document.getElementById('hours');
    let minutesInputElement = document.getElementById('minutes');
    let secoundsInputElement = document.getElementById('seconds');
    for (const button of btnElements) {
        button.addEventListener('click', () => {
            if (daysInputElement.value.length > 0) {
                hoursInputElement.value = daysInputElement.value * 24;
                minutesInputElement.value = hoursInputElement.value * 60;
                secoundsInputElement.value = minutesInputElement.value * 60;
            } else if (hoursInputElement.value.length > 0) {
                daysInputElement.value = hoursInputElement.value / 24;
                minutesInputElement.value = hoursInputElement.value * 60;
                secoundsInputElement.value = minutesInputElement.value * 60;
            } else if (minutesInputElement.value.length > 0) {
                secoundsInputElement.value = minutesInputElement.value * 60;
                hoursInputElement.value = minutesInputElement.value / 60;
                daysInputElement.value = hoursInputElement.value / 24;
            } else if (secoundsInputElement.value.length > 0) {
                minutesInputElement.value = secoundsInputElement.value / 60;
                hoursInputElement.value = minutesInputElement.value / 60;
                daysInputElement.value = hoursInputElement.value / 24;
            }
        });
    };
}