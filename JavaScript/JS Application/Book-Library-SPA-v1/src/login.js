import { upadeAuth } from './auth.js';
import { hideSections } from './clearTools.js';


const loginSectionEl = document.getElementById('login-section');

let errorMessageEl = document.querySelector('.errorMessage');
let url = 'http://localhost:3030/users/login';

export function renderLogin() {
    loginSectionEl.style.display = 'block';
}

export function loginScript(el) {
    let formData = new FormData(el);

    if (formData.get('username') != '' && formData.get('password') != '') {
        fetch(url, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                email: formData.get('username'),
                password: formData.get('password')
            })
        })
            .then(res => res.json())
            .then((user) => {
                if (user.username) {
                    localStorage.setItem('_id', user._id);
                    localStorage.setItem('username', user.username);
                    localStorage.setItem('accessToken', user.accessToken);
                    hideSections();
                    upadeAuth();
                    el.reset();
                } else {
                    console.log('User not found or Invalid input!');
                    errorMessageEl.style.display = 'block';
                }
            })
            .catch(err => console.log(err));
    };
}