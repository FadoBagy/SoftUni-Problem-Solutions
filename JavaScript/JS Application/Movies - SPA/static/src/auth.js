import { hideAllSections } from './hideSections.js';
import { renderHome } from './pages/home.js';
import { renderNavigation } from './navigation.js';


export function auth() {
    hideAllSections();
    if (localStorage.getItem('email')) {
        renderNavigation();
        renderHome();
    } else {
        renderNavigation();
        renderHome();
    }
}
