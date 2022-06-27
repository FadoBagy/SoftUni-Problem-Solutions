let formEl = document.getElementById('login-form');
let backBtn = document.getElementById('back');
let errorMessageEl = document.getElementById('errorMessage');

let url = 'http://localhost:3030/users/register';

formEl.addEventListener('submit', (e) => {
    e.preventDefault();
    let formData = new FormData(formEl);

    if (formData.get('password') != formData.get('passwordRepeat')) {
        errorMessageEl.style.display = 'block';
        errorMessageEl.textContent = 'Invalid input or Passwords does not match!';
    } else {
        if (formData.get('username') != '' && formData.get('email') != '') {
            let username = formData.get('username');
            let email = formData.get('email');
            let password = formData.get('password');
            console.log(formData.get('username'));

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
                    } else {
                        formEl.reset();
                        location.replace('/login.html');
                    }
                })
                .catch(err => console.log(err));
        };
    }
});

backBtn.addEventListener('click', () => {
    location.replace('/index.html');
});