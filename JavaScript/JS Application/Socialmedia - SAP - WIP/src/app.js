import { authenticate } from "./auth.js";
import { renderHome } from "./pages/home.js";

authenticate();
renderHome();
