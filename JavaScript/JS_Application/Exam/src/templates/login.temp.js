import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { loginRequest } from '../api.js';

const loginTemp = (onSubmit) => html`
    <section id="loginPage">
        <form class="loginForm" @submit=${onSubmit}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Login</h2>
    
            <div>
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>
    
            <div>
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>
    
            <button class="btn" type="submit">Login</button>
    
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </form>
    </section>
`;

export function loginPage(ctx) {
    ctx.render(loginTemp(onSubmit));

    function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = {
            email: formData.get('email'),
            password: formData.get('password')
        }

        if (formData.get('email') && formData.get('password')) {
            loginRequest(body)
                .then((user) => {
                    if (user.email) {
                        localStorage.setItem('email', user.email);
                        localStorage.setItem('accessToken', user.accessToken);
                        localStorage.setItem('userId', user._id);
                        e.target.reset();
                        ctx.updateUserNav();
                        page.redirect('/');
                    } else {
                        window.alert(user.message);
                    }
                });
        } else {
            window.alert('All fields should be filled!');
        }
    }
}