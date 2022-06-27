const baseUrl = 'http://localhost:3030';
const moviesUrl = `${baseUrl}/data/movies`;
const loginsUrl = `${baseUrl}/users/login`;
const registerUrl = `${baseUrl}/users/register`;


export function registerRequest(bodyData) {
    return fetch(registerUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            email: bodyData.email,
            username: bodyData.username,
            photoURL: bodyData.photoURL,
            age: bodyData.age,
            password: bodyData.password,
        })
    });
}