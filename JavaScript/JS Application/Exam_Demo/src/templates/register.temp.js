import { html } from '../../node_modules/lit-html/lit-html.js';
import page from '../../node_modules/page/page.mjs';
import { registerRequest } from '../api.js';

const registerTemp = (onSubmit) => html`
    <section id="register-page" class="register">
        <form id="register-form" action="" method="" @submit=${onSubmit}>
            <fieldset>
                <legend>Register Form</legend>
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
                <p class="field">
                    <label for="repeat-pass">Repeat Password</label>
                    <span class="input">
                        <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                    </span>
                </p>
                <input class="button submit" type="submit" value="Register">
            </fieldset>
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

        if (formData.get('confirm-pass') == formData.get('password') && formData.get('email')) {
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