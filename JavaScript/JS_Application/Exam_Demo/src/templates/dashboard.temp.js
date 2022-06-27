import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllBooks } from '../api.js';

const dashboardTemp = (books) => html`
    <section id="dashboard-page" class="dashboard">
        <h1>Dashboard</h1>
        <ul class="other-books-list">
            ${books.length > 0 
            ? books.map(x => html`${bookTemp(x)}`) 
            : html`<p class="no-books">No books in database!</p>`}
        </ul>
    </section>
`;

export const bookTemp = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <a class="button" href="/data/books/${book._id}">Details</a>
    </li>
`;

export function dashboardPage(ctx) {
    const booksList = [];

    getAllBooks()
        .then((books) => {
            for (const book of Object.values(books)) {
                booksList.push(book)
            }
            ctx.render(dashboardTemp(booksList));
        })
}