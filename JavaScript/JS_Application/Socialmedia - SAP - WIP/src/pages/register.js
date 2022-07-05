import { registerRequest } from "../api.js";
import { router } from "../router.js";

const registerSection = document.getElementById('register-section');
const form = document.querySelector('#register-section form');

export function renderRegister() {
    registerSection.style.display = 'block';
}

form.addEventListener('submit', (e) => {
    e.preventDefault();
    let formData = new FormData(form);
    const bodyData = {
        email: formData.get('email'),
        username: formData.get('username'),
        photoURL: formData.get('photoURL'),
        age: formData.get('age'),
        password: formData.get('password'),
    }
    if (formData.get('email') != '' &&
        formData.get('password').length >= 6 &&
        formData.get('password') == formData.get('password-repeat')) {

        registerRequest(bodyData);
        form.reset();
        router('/login');
    }
})