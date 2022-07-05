import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { editAnimalRequest, getPetByID } from '../api.js';

const editAnimalTemp = (animal, onSubmit) => html`
    <section id="editPage">
        <form class="editForm" @submit="${onSubmit}">
            <img src="${animal.image}">
            <div>
                <h2>Edit PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" value="${animal.name}">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" value="${animal.breed}">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" value="${animal.age}">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" value="${animal.weight}">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" value="${animal.image}">
                </div>
                <button class="btn" type="submit">Edit Pet</button>
            </div>
        </form>
    </section>
`;

export function editAnimalPage(ctx) {
    getPetByID(ctx.params.id)
        .then((animal) => {
            ctx.render(editAnimalTemp(animal, onSubmit));
        });

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
            editAnimalRequest(ctx.params.id, body)
                .then((editedAnimal) => {
                    e.target.reset();
                    page.redirect('/');
                });
        }
    }
}