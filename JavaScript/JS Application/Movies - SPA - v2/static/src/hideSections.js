const navigationButtonsEl = document.querySelector('#container nav ul');

const allSectionsEl = document.querySelectorAll('section');
const movieHeaderEl = document.querySelector('.text-center');

export function hideNavigation() {
    for (const button of navigationButtonsEl.children) {
        button.style.display = 'none';
    }
}

export function hideAllSections() {
    movieHeaderEl.style.display = 'none';
    for (const section of allSectionsEl) {
        section.style.display = 'none';
    }
}
