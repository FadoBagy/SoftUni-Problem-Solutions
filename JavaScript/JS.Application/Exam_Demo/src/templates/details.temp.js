import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { deleteBook, getBookByID } from '../api.js';

const detailsTemp = (book, deleteContact) => html`
    <section id="details-page" class="details">
        <div class="book-information">
            <h3>${book.title}</h3>
            <p class="type">Type: ${book.type}</p>
            <p class="img"><img src="${book.imageUrl}"></p>
            <div class="actions">
                ${book._ownerId == localStorage.getItem('userId') ?
                    html`
                        <a class="button" href="/edit/${book._id}">Edit</a>
                        <a class="button" href="#" @click=${deleteContact}>Delete</a>
                    `
                    : ''
                }
                <!-- Bonus -->
                ${localStorage.getItem('userId') && book._ownerId != localStorage.getItem('userId') ?
                    html`
                        <a class="button" href="#">Like</a>
                    `    
                    : ''
                }
                <div class="likes">
                    <img class="hearts" src="/images/heart.png">
                    <span id="total-likes">Likes: 0</span>
                </div>
                <!-- Bonus -->
            </div>
        </div>
        <div class="book-description">
            <h3>Description:</h3>
            <p>${book.description}</p>
        </div>
    </section>
`;

export function detailsPage(ctx) {
    getBookByID(ctx.params.id)
        .then((book) => {
            ctx.render(detailsTemp(book, deleteContact));
        });
    
    function deleteContact(){
        const choice = confirm('Are you sure you want ot delete this item?');
        if (choice) {
            deleteBook(ctx.params.id)
                .then(()=>{
                    page.redirect('/');
                })
        }
    }
}