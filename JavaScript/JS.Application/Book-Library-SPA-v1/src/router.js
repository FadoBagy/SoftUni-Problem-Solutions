import { renderLogin } from './login.js';
import { renderApp } from './app.js';
import { renderRegister } from './register.js';
import { renderAddBook } from './add-book.js';
import { render404 } from './page404.js';
import { hideSections } from './clearTools.js';


const routs = {
    '/': renderApp,
    '/login': renderLogin,
    '/register': renderRegister,
    '/add-book': renderAddBook
}

export function router(path) {
    hideSections();

    const renderer = routs[path] || render404;
    renderer();
};

