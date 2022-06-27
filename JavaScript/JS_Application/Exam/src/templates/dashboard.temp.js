import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllAnimals } from '../api.js';

const dashboardTemp = (animals) => html`
        <section id="dashboard">
            <h2 class="dashboard-title">Services for every animal</h2>
            <div class="animals-dashboard">
        
            ${animals.length > 0 
            ? animals.map(x => html`${cardTemp(x)}`) 
            : html`
                <div>
                    <p class="no-pets">No pets in dashboard</p>
                </div>
            `}
            </div>
        </section>
`;

export const cardTemp = (card) => html`
    <div class="animals-board">
        <article class="service-img">
            <img class="animal-image-cover" src="${card.image}">
        </article>
        <h2 class="name">${card.name}</h2>
        <h3 class="breed">${card.breed}</h3>
        <div class="action">
            <a class="btn" href="/details/${card._id}">Details</a>
        </div>
    </div>
`;

export function dashboardPage(ctx) {
    const animalsList = [];

    getAllAnimals()
        .then((animals) => {
            for (const animal of Object.values(animals)) {
                animalsList.push(animal)
            }
            ctx.render(dashboardTemp(animalsList));
        })

}