const host = 'http://localhost:3030';
const loginsUrl = `${host}/users/login`;
const registerUrl = `${host}/users/register`;
const logoutsUrl = `${host}/users/logout`;
const booksUrl = `${host}/data/books`;
const sortedBooksUrl = `${host}/data/books?sortBy=_createdOn%20desc`;
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

export const addBookRequest = (body) => {
    return fetch(booksUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'X-Authorization': localStorage.getItem('accessToken')
        },
        body: JSON.stringify({
            title: body.title,
            description: body.description,
            imageUrl: body.imageUrl,
            type: body.type
        })
    })
        .then(res => res.json())
}

export const getAllBooks = () => {
    return fetch(sortedBooksUrl)
        .then(res => res.json())
}

export const getBookByID = (id) => {
    return fetch(`${booksUrl}/${id}`)
        .then(res => res.json())
}

export const editBookRequest = (id, body) => {
    return fetch(`${booksUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
            'X-Authorization': localStorage.getItem('accessToken')
        },
        body: JSON.stringify({
            title: body.title,
            description: body.description,
            imageUrl: body.imageUrl,
            type: body.type
        })
    })
        .then(res => res.json())
}

export const deleteBook = (id) => {
    return fetch(`${booksUrl}/${id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': localStorage.getItem('accessToken')
        }
    })
        .then(res => res.json())
}

export const getMyBooks = (id) => {
    return fetch(mybooksUrl(id), {
        method: 'GET',
        headers: {
            'X-Authorization': localStorage.getItem('accessToken')
        }
    })
        .then(res => res.json())
} 