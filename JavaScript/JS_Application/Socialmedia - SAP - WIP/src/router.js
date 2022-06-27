import { renderHome } from './pages/home.js';
import { renderLogin } from './pages/login.js';
import { renderRegister } from './pages/register.js';
import { hideSections } from './utils.js';

const routs = {
    '/': renderHome,
    '/login': renderLogin,
    '/register': renderRegister,
    '/logout': 'logOut',
    '/details/': 'renderMoreDetails',
}

export function router(path) {
    hideSections();
    const renderer = routs[path] || console.log('Invalid Path');
    renderer();
}