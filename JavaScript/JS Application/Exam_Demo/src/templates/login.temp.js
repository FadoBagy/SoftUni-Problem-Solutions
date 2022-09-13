import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { loginRequest } from '../api.js';

const loginTemp = (onSubmit) => html`
    <section id="login-page" class="login">
        <form id="login-form" action="" method="" @submit="${onSubmit}">
            <fieldset>
                <legend>Login Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input type="text" name="email" id="email" placeholder="Email">
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input type="password" name="password" id="password" placeholder="Password">
                    </span>
                </p>
                <input class="button submit" type="submit" value="Login">
            </fieldset>
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