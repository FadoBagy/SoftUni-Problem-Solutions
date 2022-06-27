let loadBooksButton = document.getElementById('loadBooks');
let tableEl = document.getElementById('booksTable');
let formEl = document.getElementById('form');

let headerEl = document.getElementById('form-header');
let titleEl = document.getElementById('form-title');
let authorEl = document.getElementById('form-author');
let saveButtonEl = document.getElementById('form-button');

let url = 'http://localhost:3030/jsonstore/collections/books';

let editBookID = '';

function loadBooks() {
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            tableEl.innerHTML = '';
            for (const book in data) {
                let newBookRow = document.createElement('tr');

                let bookTitle = document.createElement('td');
                bookTitle.textContent = data[book].title;
                newBookRow.appendChild(bookTitle);

                let bookAuthor = document.createElement('td');
                bookAuthor.textContent = data[book].author;
                newBookRow.appendChild(bookAuthor);

                let actionSection = document.createElement('td');
                let editBtn = document.createElement('button');
                editBtn.textContent = 'Edit';
                editBtn.addEventListener('click', (e) => {
                    headerEl.textContent = 'Edit FORM';
                    titleEl.value = data[book].title;
                    authorEl.value = data[book].author;
                    saveButtonEl.textContent = 'Save';
                    editBookID = book;
                    if (headerEl.textContent == 'Edit FORM') {
                        formEl.style.background = '#cecece';
                    } else {
                        formEl.style.background = '#ffffff';
                    };
                });
                actionSection.appendChild(editBtn);
                let deleteBtn = document.createElement('button');
                deleteBtn.textContent = 'Delete';
                deleteBtn.addEventListener('click', (e) => {
                    fetch(`${url}/${book}`, {
                        method: 'DELETE',
                    });
                    e.currentTarget.parentElement.parentElement.remove();
                });
                actionSection.appendChild(deleteBtn);
                newBookRow.appendChild(actionSection);

                tableEl.appendChild(newBookRow);
            }
        })
        .catch(err => console.log(err));
};

loadBooksButton.addEventListener('click', () => {
    loadBooks();
});

formEl.addEventListener('submit', (e) => {
    e.preventDefault();
    let formData = new FormData(formEl);
    if (formData.get('author') != '' && formData.get('title') != '') {
        if (saveButtonEl.textContent == 'Save') {
            fetch(`${url}/${editBookID}`, {
                method: 'PUT',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    author: authorEl.value,
                    title: titleEl.value,
                    _id: editBookID
                })
            });
            headerEl.textContent = 'FORM';
            saveButtonEl.textContent = 'Submit';
            if (headerEl.textContent == 'Edit FORM') {
                formEl.style.background = '#cecece';
            } else {
                formEl.style.background = '#ffffff';
            };
        } else {
            fetch(url, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    'author': formData.get('author'),
                    'title': formData.get('title')
                })
            });
        }
        loadBooks();
        formEl.reset();
    };
});

