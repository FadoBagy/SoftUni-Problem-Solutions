import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { addPetRequest } from '../api.js';

const createTemp = (onSubmit) => html`
    <section id="createPage">
        <form class="createForm" @submit="${onSubmit}">
            <img src="./images/cat-create.jpg">
            <div>
                <h2>Create PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" placeholder="Max">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" placeholder="2 years">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" placeholder="5kg">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
                </div>
                <button class="btn" type="submit">Create Pet</button>
            </div>
        </form>
    </section>
`;

export function createPage(ctx) {
    ctx.render(createTemp(onSubmit));

    function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = {
            name: formData.get('name'),
            breed: formData.get('breed'),
            age: formData.get('age'),
            weight: formData.get('weight'),
            image: formData.get('image'),
        };

        if (formData.get('name') && formData.get('breed') && formData.get('age') && formData.get('weight') && formData.get('image')) {
            addPetRequest(body)
                .then((newPet) => {
                    e.target.reset();
                    page.redirect('/');
                });
        }
    }
}