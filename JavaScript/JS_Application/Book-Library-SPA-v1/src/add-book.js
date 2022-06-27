const bookSectionEl = document.getElementById('book-section');

let addedBookEl = document.getElementById('addedBook');
let titleBookEl = document.getElementById('form-title');
let authorBookEl = document.getElementById('form-author');

let addingAsEl = document.getElementById('addingAs');

let url = 'http://localhost:3030/jsonstore/collections/books';

let newParagraphEl = document.createElement('p');
newParagraphEl.textContent = `Adding book as ${localStorage.getItem('username')}`;
addingAsEl.appendChild(newParagraphEl);

export function renderAddBook() {
    bookSectionEl.style.display = 'flex';
}

export function addBookScript(el) {
    let formData = new FormData(el);

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
        el.reset();
        addedBookEl.style.opacity = '100';
        addedBookEl.style.backgroundColor = '#234465';
    };


    titleBookEl.addEventListener('focus', () => {
        addedBookEl.style.opacity = '0';
    });

    authorBookEl.addEventListener('focus', () => {
        addedBookEl.style.opacity = '0';
    });
}

