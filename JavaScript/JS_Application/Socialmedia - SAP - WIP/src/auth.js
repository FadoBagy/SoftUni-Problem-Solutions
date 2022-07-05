import { hideNavigation, hideSections } from './utils.js';
import { renderGuestNavigation, renderUserNavigation } from './pages/navigation.js';

export function authenticate() {
    hideSections();
    hideNavigation();
    if (localStorage.getItem('email')) {
        renderUserNavigation();
    } else {
        renderGuestNavigation();
    }
}