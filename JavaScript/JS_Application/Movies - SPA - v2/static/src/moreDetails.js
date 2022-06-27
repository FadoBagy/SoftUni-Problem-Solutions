import { deleteMovieRequest, renderMoreDetailsRequest } from "./api.js";

const movieExampleEl = document.getElementById('movie-example');

export function renderMoreDetails() {
    movieExampleEl.style.display = 'block';

    renderMoreDetailsRequest()
        .then((movie) => {
            movieExampleEl.innerHTML = '';

            const containerDiv = document.createElement('div');
            containerDiv.setAttribute('class', 'container');

            const mainDiv = document.createElement('div');
            mainDiv.setAttribute('class', 'row bg-light text-dark');

            const h1Title = document.createElement('h1');
            h1Title.textContent = `Movie title: ${movie.title}`;

            const imageDiv = document.createElement('div');
            imageDiv.setAttribute('class', 'col-md-8');

            const image = document.createElement('img');
            image.setAttribute('class', 'img-thumbnail');
            image.setAttribute('src', movie.img);
            image.setAttribute('alt', 'Movie');

            const descriptionDiv = document.createElement('div');
            descriptionDiv.setAttribute('class', 'col-md-4 text-center');

            const h3Description = document.createElement('h3');
            h3Description.setAttribute('class', 'my-3');

            const descriptionParagraph = document.createElement('p');
            descriptionParagraph.textContent = movie.description;

            const likedSpan = document.createElement('span');
            likedSpan.setAttribute('class', 'enrolled-span');
            likedSpan.textContent = 'Liked 1';

            if (localStorage.getItem('userId') == movie._ownerId) {
                const deleteElement = document.createElement('a');
                deleteElement.setAttribute('class', 'btn btn-danger');
                deleteElement.setAttribute('href', '#');
                deleteElement.textContent = 'Delete';

                deleteElement.addEventListener('click', (e) => {
                    e.preventDefault();
                    deleteMovieRequest(movie._id);
                });

                const editElement = document.createElement('a');
                editElement.setAttribute('class', 'btn btn-warning');
                editElement.setAttribute('href', '#');
                editElement.textContent = 'Edit';

                imageDiv.appendChild(image);

                descriptionDiv.appendChild(h3Description);
                descriptionDiv.appendChild(descriptionParagraph);
                descriptionDiv.appendChild(deleteElement);
                descriptionDiv.appendChild(editElement);
                descriptionDiv.appendChild(likedSpan);

                mainDiv.appendChild(h1Title);
                mainDiv.appendChild(imageDiv);
                mainDiv.appendChild(descriptionDiv);

                containerDiv.appendChild(mainDiv);

                movieExampleEl.appendChild(containerDiv);

            } else {
                const likeElement = document.createElement('a');
                likeElement.setAttribute('class', 'btn btn-primary');
                likeElement.setAttribute('href', '#');
                likeElement.textContent = 'Like';
                likeElement.addEventListener('click', () => {
                    likeMovie(data);
                });

                // const isLiked = getOwnLike();
                // if (isLiked) {
                //     likeElement.style.display = 'none';
                // } else {
                //     likeElement.style.display = 'block';
                // }

                imageDiv.appendChild(image);

                descriptionDiv.appendChild(h3Description);
                descriptionDiv.appendChild(descriptionParagraph);
                descriptionDiv.appendChild(likeElement);
                descriptionDiv.appendChild(likedSpan);

                mainDiv.appendChild(h1Title);
                mainDiv.appendChild(imageDiv);
                mainDiv.appendChild(descriptionDiv);

                containerDiv.appendChild(mainDiv);

                movieExampleEl.appendChild(containerDiv);
            }
        })
}