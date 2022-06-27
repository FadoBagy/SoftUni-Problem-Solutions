const loadBooksSectionEl = document.getElementById('load-books-section');
const edditBookSectionEl = document.getElementById('edit-book-section');

let tableEl = document.getElementById('booksTable');

let editBookFormEl = document.getElementById('edit-book-form');
let editBookTitleEl = document.getElementById('edit-book-title');
let editBookAuthorEl = document.getElementById('edit-book-author');
let editBookButtonEl = document.getElementById('edit-book-button');

let url = 'http://localhost:3030/jsonstore/collections/books';
let editBookID = '';

export function renderApp() {
    loadBooksSectionEl.style.display = 'block';
    edditBookSectionEl.style.display = 'block';
};

export function loadBooks() {

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
                editBtn.addEventListener('click', () => {
                    editBookTitleEl.value = data[book].title;
                    editBookAuthorEl.value = data[book].author;
                    editBookID = book;
                    editBookFormEl.style.background = 'rgb(228, 228, 228)';
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

    // TO ADD FUNCTIONALITY
    editBookButtonEl.addEventListener('click', (e) => {
        e.preventDefault();
        editBookFormEl.style.background = '#ffffff';
        editBookFormEl.reset();
    })
};