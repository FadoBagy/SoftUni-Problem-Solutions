import { router } from "../router.js";
import { hideAllSections } from "../hideSections.js";
import { addBookRequest, loadMoviesReqest } from "../api.js";

const homePageEl = document.getElementById('home-page');
const movieHeaderEl = document.querySelector('.text-center');
const addMovieButtonEl = document.getElementById('add-movie-button');
const movieSectionel = document.getElementById('movie');

const addMovieSection = document.getElementById('add-movie');
const addMovieBtnEl = document.getElementById('add-movie-button');
const addMovieFormEl = document.querySelector('#add-movie form');

const movieContainerEl = document.querySelector('.card-deck');
const movieExampleEl = document.getElementById('movie-example');

export function renderHome() {
    if (localStorage.getItem('email')) {
        homePageEl.style.display = 'block';
        movieHeaderEl.style.display = 'block';
        addMovieButtonEl.style.display = 'block';
        movieSectionel.style.display = 'block';
    } else {
        homePageEl.style.display = 'block';
        movieHeaderEl.style.display = 'block';
        movieSectionel.style.display = 'block';
    }
    loadMovies();
}

addMovieBtnEl.addEventListener('click', (e) => {
    e.preventDefault();
    hideAllSections();
    addMovieSection.style.display = 'block';
});

addMovieFormEl.addEventListener('submit', (e) => {
    e.preventDefault();
    addBook(addMovieFormEl);
});

function addBook(form) {
    const formData = new FormData(form);
    const bodyContent = {
        title: formData.get('title'),
        description: formData.get('description'),
        img: formData.get('imageUrl')
    }
    if (formData.get('title') != '' && formData.get('description') != '' && formData.get('imageUrl') != '') {
        addBookRequest(bodyContent);
        form.reset();
    }
}

function loadMovies() {
    movieContainerEl.innerHTML = '';
    loadMoviesReqest()
        .then((movies) => {
            for (const movie of movies) {
                let newMovie = document.createElement('div');
                newMovie.classList = 'card mb-4';

                let img = document.createElement('img');
                img.classList = 'card-img-top';
                img.src = movie.img;
                img.alt = 'Card image cap';
                img.width = '400';
                newMovie.appendChild(img);

                let cardBody = document.createElement('div');
                cardBody.classList = 'card-body';
                let cardBodyHeader = document.createElement('h4');
                cardBodyHeader.classList = 'card-title';
                cardBodyHeader.textContent = movie.title;
                cardBody.appendChild(cardBodyHeader);
                newMovie.appendChild(cardBody);

                let cardFooter = document.createElement('div');
                cardFooter.classList = 'card-footer';
                let footerAncor = document.createElement('a');
                footerAncor.href = `/details/`;
                let footerBtn = document.createElement('button');
                footerBtn.type = 'button';
                footerBtn.classList = 'btn btn-info';
                footerBtn.textContent = 'Details';
                footerBtn.addEventListener('click', (e) => {
                    e.preventDefault();
                    let url = new URL(e.currentTarget.parentElement.href);
                    localStorage.setItem('movieId', movie._id);
                    router(url.pathname);
                });
                footerAncor.appendChild(footerBtn);
                cardFooter.appendChild(footerAncor);
                newMovie.appendChild(cardFooter);

                movieContainerEl.appendChild(newMovie);
            }
        })
        .catch(err => console.log(err));
}