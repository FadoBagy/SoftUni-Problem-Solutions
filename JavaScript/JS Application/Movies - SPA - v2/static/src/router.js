import { hideAllSections } from "./hideSections.js";
import { renderHome } from "./pages/home.js";
import { renderLogin } from "./login.js";
import { logOut } from "./logout.js";
import { renderMoreDetails } from "./moreDetails.js";
import { renderRegister } from "./register.js";

const routs = {
    '/': renderHome,
    '/login': renderLogin,
    '/register': renderRegister,
    '/logout': logOut,
    '/details/': renderMoreDetails,
}

export function router(path) {
    hideAllSections();
    const renderer = routs[path] || console.log('Invalid Path');
    renderer();
}