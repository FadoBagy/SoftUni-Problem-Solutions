import { router } from "../router.js"

const navElements = document.querySelectorAll('ul a');
const navListElement = document.querySelector('nav');

export function renderUserNavigation() {
    navElements[0].style.display = 'block';
    navElements[3].style.display = 'block';
    navElements[4].style.display = 'block';
}

export function renderGuestNavigation() {
    navElements[0].style.display = 'block';
    navElements[1].style.display = 'block';
    navElements[2].style.display = 'block';
}

navListElement.addEventListener('click', (e) => {
    e.preventDefault();
    if (e.target.tagName == 'A') {
        let url = new URL(e.target.href);
        router(url.pathname);
    } else if (e.target.parentElement.tagName == 'A') {
        let url = new URL(e.target.parentElement.href);
        router(url.pathname);
    }
});