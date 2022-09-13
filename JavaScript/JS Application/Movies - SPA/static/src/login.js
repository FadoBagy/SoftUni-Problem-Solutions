import { loginRequest } from "./api.js";
import { auth } from "./auth.js";

const loginForm = document.querySelector('#form-login form');
const loginSection = document.getElementById('form-login');

export function renderLogin() {
    loginSection.style.display = 'block';
}

// Can display Error message, don't have a place to do so
loginForm.addEventListener('submit', (e) => {
    e.preventDefault();
    makeLoginRequest(loginForm);
});

function makeLoginRequest(form) {
    let formData = new FormData(form);
    const body = {
        email: formData.get('email'),
        password: formData.get('password')
    }

    if (formData.get('email') != '' && formData.get('password').length >= 6) {
        loginRequest(body)
            .then((user) => {
                if (user.email) {
                    localStorage.setItem('email', user.email);
                    localStorage.setItem('accessToken', user.accessToken);
                    localStorage.setItem('userId', user._id);
                    auth();
                } else {
                    console.log('User not found or Invalid input!');
                }
            })
            .catch(err => console.log(err));
        form.reset();
    }
}