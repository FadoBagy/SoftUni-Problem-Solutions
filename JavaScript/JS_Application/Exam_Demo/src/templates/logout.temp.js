import page from '../../node_modules/page/page.mjs';
import { logoutRequest } from '../api.js';

export function logOutPage(ctx) {
    logoutRequest()
        .then(() => {
            localStorage.clear();
            ctx.updateUserNav();
            page.redirect('/');
        })

}
