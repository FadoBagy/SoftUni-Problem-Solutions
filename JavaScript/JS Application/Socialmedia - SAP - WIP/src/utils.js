const sections = document.querySelectorAll('section');
const navElements = document.querySelectorAll('ul a');

export function hideSections() {
    for (const section of sections) {
        section.style.display = 'none';
    }
}

export function hideNavigation() {
    for (const element of navElements) {
        element.style.display = 'none';
    }
}