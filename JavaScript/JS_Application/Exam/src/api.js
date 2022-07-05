const host = 'http://localhost:3030';
const loginsUrl = `${host}/users/login`;
const registerUrl = `${host}/users/register`;
const logoutsUrl = `${host}/users/logout`;
const petsUrl = `${host}/data/pets`;
const sertedAnimalsUrl = `${host}/data/pets?sortBy=_createdOn%20desc&distinct=name`;
const mybooksUrl = (id) => `${host}/data/books?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`;

export const loginRequest = (body) => {
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
};

export const registerRequest = (body) => {
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

export const logoutRequest = () => {
    return fetch(logoutsUrl, {
        method: 'GET',
        headers: {
            'X-Authorization': localStorage.getItem('accessToken')
        }
    })
}

export const getAllAnimals = () => {
    return fetch(sertedAnimalsUrl)
        .then(res => res.json())
}

export const getPetByID = (id) => {
    return fetch(`${petsUrl}/${id}`)
        .then(res => res.json())
}

export const editAnimalRequest = (id, body) => {
    return fetch(`${petsUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
            'X-Authorization': localStorage.getItem('accessToken')
        },
        body: JSON.stringify({
            name: body.name,
            breed: body.breed,
            age: body.age,
            weight: body.weight,
            image: body.image,
        })
    })
        .then(res => res.json())
}

export const deleteAnimal = (id) => {
    return fetch(`${petsUrl}/${id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': localStorage.getItem('accessToken')
        }
    })
        .then(res => res.json())
}

export const addPetRequest = (body) => {
    return fetch(petsUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'X-Authorization': localStorage.getItem('accessToken')
        },
        body: JSON.stringify({
            name: body.name,
            breed: body.breed,
            age: body.age,
            weight: body.weight,
            image: body.image,
        })
    })
        .then(res => res.json())
}