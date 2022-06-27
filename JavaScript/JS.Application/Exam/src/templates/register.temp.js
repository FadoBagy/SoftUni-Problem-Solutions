import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { registerRequest } from '../api.js';

const registerTemp = (onSubmit) => html`
    <section id="registerPage">
        <form class="registerForm" @submit=${onSubmit}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Register</h2>
            <div class="on-dark">
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>
    
            <div class="on-dark">
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>
    
            <div class="on-dark">
                <label for="repeatPassword">Repeat Password:</label>
                <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
            </div>
    
            <button class="btn" type="submit">Register</button>
    
            <p class="field">
                <span>If you have profile click <a href="/login">here</a></span>
            </p>
        </form>
    </section>
`;

export function registerPage(ctx) {
    ctx.render(registerTemp(onSubmit));

    function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const body = {
            email: formData.get('email'),
            password: formData.get('password')
        }

        if (formData.get('repeatPassword') == formData.get('password') && formData.get('email')) {
            registerRequest(body)
                .then((res) => {
                    if (res.status == 200) {
                        e.target.reset();
                        page.redirect('/');
                    } else {
                        console.log(res);
                        window.alert(res.statusText)
                    }
                });
        } else {
            window.alert('Passwod does not match or There are empty field')
        }
    }
}