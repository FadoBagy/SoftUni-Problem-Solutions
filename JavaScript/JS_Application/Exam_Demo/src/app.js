import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { addBookPage } from './templates/addBook.temp.js';
import { dashboardPage } from './templates/dashboard.temp.js';
import { logOutPage } from './templates/logout.temp.js';
import { myBooksPage } from './templates/myBooks.temp.js';
import { registerPage } from './templates/register.temp.js';
import { loginPage } from './templates/login.temp.js';
import { detailsPage } from './templates/details.temp.js';
import { editBookPage } from './templates/edit.temp.js';

const root = document.getElementById('site-content');
const guestNav = document.getElementById('guest');
const userNav = document.getElementById('user');
const greetMsgEl = document.querySelector('#user span');

page(decorateContext)
page('/', dashboardPage);
page('/login', loginPage);
page('/register', registerPage);
page('/logout', logOutPage);
page('/my-books', myBooksPage);
page('/add-book', addBookPage);
page('/data/books/:id', detailsPage);
page('/edit/:id', editBookPage);

updateUserNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;

    next();
}

function updateUserNav() {
    if (localStorage.getItem('email')) {
        greetMsgEl.textContent = `Welcome, ${localStorage.getItem('email')}`;

        userNav.style.display = 'block';
        guestNav.style.display = 'none';
    } else {
        userNav.style.display = 'none';
        guestNav.style.display = 'block';
    }
}