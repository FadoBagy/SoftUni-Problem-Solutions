import { registerRequest } from "./api.js";
import { hideAllSections } from "./hideSections.js";
import { renderLogin } from "./login.js";

const registerForm = document.querySelector('#form-sign-up form');
const registerSection = document.getElementById('form-sign-up');

export function renderRegister() {
    registerSection.style.display = 'block';
}

registerForm.addEventListener('submit', (e) => {
    e.preventDefault();
    makeRegisterRequest(registerForm)
});

// Can display Error message, don't have a place to do so
function makeRegisterRequest(form) {
    let formData = new FormData(form);
    const body = {
        email: formData.get('email'),
        password: formData.get('password')
    }

    if (formData.get('email') != '' &&
        formData.get('password').length >= 6 &&
        formData.get('password') == formData.get('repeatPassword')) {

        registerRequest(body)
        registerForm.reset();
        hideAllSections();
        renderLogin();
    }
}