import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { createPage } from './templates/create.temp.js';
import { dashboardPage } from './templates/dashboard.temp.js';
import { detailsPage } from './templates/details.temp.js';
import { editAnimalPage } from './templates/edit.temp.js';
import { homePage } from './templates/home.temp.js';
import { loginPage } from './templates/login.temp.js';
import { logOutPage } from './templates/logout.temp.js';
import { registerPage } from './templates/register.temp.js';

const root = document.getElementById('content');
const navEls = document.querySelectorAll('#nav li');

page(decorateContext)
page('/', homePage);
page('/dashboard', dashboardPage);
page('/login', loginPage);
page('/register', registerPage);
page('/logout', logOutPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editAnimalPage);

updateUserNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;

    next();
}

function updateUserNav() {
    if (localStorage.getItem('email')) {
        navEls[4].style.display = 'list-item';
        navEls[5].style.display = 'list-item';

        navEls[2].style.display = 'none';
        navEls[3].style.display = 'none';
    } else {
        navEls[2].style.display = 'list-item';
        navEls[3].style.display = 'list-item';

        navEls[4].style.display = 'none';
        navEls[5].style.display = 'none';
    }
}