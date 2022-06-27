import { router } from './router.js';
import { hideNavs } from './clearTools.js';

let userNavEl = document.getElementById('user');
let guestNavEl = document.getElementById('guest');
let greetNavEl = document.getElementById('greet');

const loadBooksSectionEl = document.getElementById('load-books-section');
const edditBookSectionEl = document.getElementById('edit-book-section');

export function upadeAuth() {
    if (localStorage.getItem('username')) {
        hideNavs();
        userNavEl.style.display = 'flex';
        greetNavEl.style.display = 'flex'
        greetNavEl.textContent = `Hello, ${localStorage.getItem('username')}!`;

        loadBooksSectionEl.style.display = 'block';
        edditBookSectionEl.style.display = 'block';

        userNavEl.addEventListener('click', (e) => {
            e.preventDefault();
            if (e.target.tagName == 'A') {
                let url = new URL(e.target.href);
                router(url.pathname);
            } else {
                let url = new URL(e.target.children[0].href);
                router(url.pathname);
            }
        });
    } else {
        hideNavs();
        guestNavEl.style.display = 'flex';
        guestNavEl.addEventListener('click', (e) => {
            e.preventDefault();
            if (e.target.tagName == 'A') {
                let url = new URL(e.target.href);
                router(url.pathname);
            } else {
                let url = new URL(e.target.children[0].href);
                router(url.pathname);
            }
        });
    }
}
