import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMyBooks } from '../api.js';
import { bookTemp } from './dashboard.temp.js';

const myBooksTemp = (userBook) => html`
    <section id="my-books-page" class="my-books">
        <h1>My Books</h1>
        <!-- Display ul: with list-items for every user's books (if any) -->
        <ul class="my-books-list">
            ${userBook.length > 0 
                ? userBook.map(x => html`${bookTemp(x)}`) 
                : html`<p class="no-books">No books in database!</p>`
            }
        </ul>
    </section>
`;

export function myBooksPage(ctx) {
    getMyBooks(localStorage.getItem('userId'))
        .then((userBook) => {
            ctx.render(myBooksTemp(userBook));
        })
}