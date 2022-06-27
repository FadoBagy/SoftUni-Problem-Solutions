import { auth } from "./auth.js";

const baseUrl = 'http://localhost:3030';
const moviesUrl = `${baseUrl}/data/movies`;
const loginsUrl = `${baseUrl}/users/login`;
const registerUrl = `${baseUrl}/users/register`;

export function loadMoviesReqest() {
    return fetch(moviesUrl)
        .then(res => res.json())
}

export function addBookRequest(body) {
    fetch(moviesUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'X-Authorization': localStorage.getItem('accessToken')
        },
        body: JSON.stringify({
            title: body.title,
            description: body.description,
            img: body.img
        })
    });
}

export function deleteMovieRequest(movieId) {
    fetch(`${moviesUrl}/${movieId}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': localStorage.getItem('accessToken')
        }
    });
    auth();         // Could be separated
}

export function renderMoreDetailsRequest() {
    return fetch(`${moviesUrl}/${localStorage.getItem('movieId')}`)
        .then(res => res.json())
}

export function loginRequest(body) {
    return fetch(loginsUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            email: body.email,
            password: body.password
        })
    })
        .then(res => res.json())
}

export function registerRequest(body) {
    return fetch(registerUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            email: body.email,
            password: body.password
        })
    });
}