import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { deleteAnimal, getPetByID } from '../api.js';

const detailsTemp = (pet, deleteContact) => html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${pet.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: 0$</h4>
                </div>
    
                ${localStorage.getItem('userId') ?
                    html`
                        <div class="actionBtn">
                            ${localStorage.getItem('userId') && pet._ownerId == localStorage.getItem('userId')
                                ? html`
                                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                                    <a href="#" class="remove" @click="${deleteContact}">Delete</a>
                                ` : ''}

                            <!--(Bonus Part) Only for no creator and user-->

                            ${localStorage.getItem('userId') && pet._ownerId != localStorage.getItem('userId')
                                ? html`
                                <a href="#" class="donate">Donate</a>
                                `
                                :''}
                        </div>
                    ` : ''
                }
                
            </div>
        </div>
    </section>
`;

export function detailsPage(ctx) {
    getPetByID(ctx.params.id)
        .then((pet) => {
            ctx.render(detailsTemp(pet, deleteContact));
        });

    function deleteContact() {
        const choice = confirm('Are you sure you want ot delete this item?');
        if (choice) {
            deleteAnimal(ctx.params.id)
                .then(() => {
                    page.redirect('/');
                })
        }
    }
}