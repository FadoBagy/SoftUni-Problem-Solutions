import { loadBooks } from './app.js';
import { loginScript } from './login.js';
import { registerScript } from './register.js';
import { addBookScript } from './add-book.js';
import { upadeAuth } from './auth.js';

upadeAuth();

let loadBooksButton = document.getElementById('loadBooks');
let logoutBtn = document.getElementById('logout');

let loginFormEl = document.getElementById('login-form');
let registerFormEl = document.getElementById('register-form');
let addBookFormEl = document.getElementById('book-form');

// Can Work in the path file also!!! (the event handlerer)

// Can be improved !!!
logoutBtn.addEventListener('click', () => {
    localStorage.clear();
    upadeAuth();
});

loadBooksButton.addEventListener('click', () => {
    loadBooks();
});

loginFormEl.addEventListener('submit', (e) => {
    e.preventDefault();
    loginScript(loginFormEl);
});

registerFormEl.addEventListener('submit', (e) => {
    e.preventDefault();
    registerScript(registerFormEl);
});

addBookFormEl.addEventListener('submit', (e) => {
    e.preventDefault();
    addBookScript(addBookFormEl);
});