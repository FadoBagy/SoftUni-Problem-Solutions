let formEl = document.getElementById('login-form');
let backBtn = document.getElementById('back');
let errorMessageEl = document.getElementById('errorMessage');

let url = 'http://localhost:3030/users/login';

formEl.addEventListener('submit', (e) => {
    e.preventDefault();
    let formData = new FormData(formEl);

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
                    location.replace('/index.html');
                } else {
                    console.log('User not found or Invalid input!');
                    errorMessageEl.style.display = 'block';
                }
            })
            .catch(err => console.log(err));
    };
});

backBtn.addEventListener('click', () => {
    location.replace('/index.html');
});