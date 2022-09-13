import { hideNavigation } from "./hideSections.js";
import { router } from "./router.js";

const navigationButtonsEl = document.querySelector('#container nav ul');
const navigationEl = document.querySelector('#container nav');

export function renderNavigation() {
    if (localStorage.getItem('email')) {
        hideNavigation();
        navigationButtonsEl.children[0].children[0].textContent = `Welcome, ${(localStorage.getItem('email').split('@')[0])}`;
        navigationButtonsEl.children[0].style.display = 'block';
        navigationButtonsEl.children[1].style.display = 'block';
    } else {
        hideNavigation();
        navigationButtonsEl.children[2].style.display = 'block';
        navigationButtonsEl.children[3].style.display = 'block';
    }
}

navigationEl.addEventListener('click', (e) => {
    e.preventDefault();
    if (e.target.tagName == 'A') {
        let url = new URL(e.target.href);
        router(url.pathname);
    }
});