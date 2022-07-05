import { auth } from "./auth.js";


export function logOut() {
    localStorage.clear();
    auth();
}