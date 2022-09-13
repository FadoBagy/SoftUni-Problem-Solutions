import { towns } from "./towns.js";

const townsEl = document.getElementById('towns');
const searchEl = document.getElementById('searchText');
const searchBtnEl = document.querySelector('button');
const resultEl = document.getElementById('result');

const ulEl = document.createElement('ul');
ulEl.id = 'townsList';
for (const town of towns) {
   const liEl = document.createElement('li');
   liEl.textContent = town;
   ulEl.appendChild(liEl);
}
townsEl.appendChild(ulEl);
const townsListEl = document.querySelectorAll('#townsList li');

searchEl.addEventListener('keyup', () => {
   let searchInput = searchEl.value;
   let matchesCount = 0;

   for (const town of townsListEl) {
      town.classList.remove('active');
      if (town.textContent.includes(searchInput) && searchInput != '') {
         town.classList = 'active';
         matchesCount++;
      }
   }
   resultEl.textContent = `${matchesCount} matches found`;
});

// searchBtnEl.addEventListener('click', (e) => {
//    let searchInput = searchEl.value;
//    for (const town of townsListEl) {
//       town.classList.remove('active');
//       if (town.textContent.includes(searchInput) && searchInput != '') {
//          town.classList = 'active';
//       }
//    }
// });