import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { editBookRequest, getBookByID } from '../api.js';

const editBookTemp = (book, onSubmit) => html`
    <section id="edit-page" class="edit">
        <form id="edit-form" action="#" method="" @submit=${onSubmit}>
            <fieldset>
                <legend>Edit my Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" value="${book.title}">
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description" id="description">${book.description}</textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" value="${book.imageUrl}">
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type" value="${book.type}">
                            <option value="Fiction" selected>Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Save">
            </fieldset>
        </form>
    </section>
`;

export function editBookPage(ctx) {
    getBookByID(ctx.params.id)
        .then((book) => {
            ctx.render(editBookTemp(book, onSubmit));
        });

    function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = {
            title: formData.get('title'),
            description: formData.get('description'),
            imageUrl: formData.get('imageUrl'),
            type: formData.get('type'),
        };

        if (formData.get('title') && formData.get('description') && formData.get('imageUrl')) {
            editBookRequest(ctx.params.id, body)
                .then((editedBook) => {
                    e.target.reset();
                    page.redirect('/');
                });
        }
    }
}