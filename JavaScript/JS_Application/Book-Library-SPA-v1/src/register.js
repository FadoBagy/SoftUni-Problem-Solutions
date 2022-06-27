import { hideSections } from './clearTools.js';


const registerSectionEl = document.getElementById('register-section');

let errorMessageEl = document.querySelector('#errorMessage-register');

let url = 'http://localhost:3030/users/register';

export function renderRegister() {
    registerSectionEl.style.display = 'block';
};

export function registerScript(el) {
    let formData = new FormData(el);

    if (formData.get('password') != formData.get('passwordRepeat')) {
        errorMessageEl.style.display = 'block';
        errorMessageEl.textContent = 'Passwords does not match!';
    } else {
        if (formData.get('username') != '' && formData.get('email') != '') {
            let username = formData.get('username');
            let email = formData.get('email');
            let password = formData.get('password');

            fetch(url, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    email,
                    password,
                    username
                })
            })
                .then(res => res.json())
                .then((user) => {
                    console.log(user);
                    if (user.code == 409) {
                        errorMessageEl.style.display = 'block';
                        errorMessageEl.textContent = user.message;
                    } else if (user.code == 400) {
                        errorMessageEl.style.display = 'block';
                        errorMessageEl.textContent = user.message;
                    } else {
                        el.reset();
                        errorMessageEl.style.display = 'none';
                        hideSections();
                    }
                })
                .catch(err => console.log(err));
        };
    }
}

