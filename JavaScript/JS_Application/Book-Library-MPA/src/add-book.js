let formEl = document.getElementById('book-form');
let backBtn = document.getElementById('back');
let addedBookEl = document.getElementById('addedBook');
let titleBookEl = document.getElementById('form-title');
let authorBookEl = document.getElementById('form-author');
let addingAsEl = document.getElementById('addingAs');

let url = 'http://localhost:3030/jsonstore/collections/books';

window.addEventListener('load', () => {
    let newParagraphEl = document.createElement('p');
    newParagraphEl.textContent = `Adding book as ${localStorage.getItem('username')}`;
    addingAsEl.appendChild(newParagraphEl);
})

formEl.addEventListener('submit', (e) => {
    e.preventDefault();
    let formData = new FormData(formEl);

    let author = formData.get('author') + ` (Added by ${localStorage.getItem('username')})`;

    if (formData.get('author') != '' && formData.get('title') != '') {
        fetch(url, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': localStorage.getItem('accessToken')
            },
            body: JSON.stringify({
                author,
                title: formData.get('title')
            })
        });
        formEl.reset();
        addedBookEl.style.opacity = '100';
        addedBookEl.style.backgroundColor = '#234465';
    };
});

backBtn.addEventListener('click', () => {
    location.replace('/index.html');
});

titleBookEl.addEventListener('focus', () => {
    addedBookEl.style.opacity = '0';
});

authorBookEl.addEventListener('focus', () => {
    addedBookEl.style.opacity = '0';
});