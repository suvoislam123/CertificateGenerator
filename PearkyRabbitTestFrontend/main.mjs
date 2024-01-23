import { apiUrlProd, clientUrlDev, clientUrlProd } from "./golbal.mjs";
import { imgUrlProd } from "./golbal.mjs";
import { apiUrlDevelopment } from "./golbal.mjs";
import { imgUrlDev } from "./golbal.mjs";
import { environment } from "./environments/environment.mjs";
export let apiUrl= '';
export let imgUrl='';
export let clientUrl='';

if (environment.production) {
    apiUrl = apiUrlProd;
    imgUrl = imgUrlProd;
    clientUrl = clientUrlProd;
} else {
    apiUrl = apiUrlDevelopment;
    imgUrl = imgUrlDev;
    clientUrl = clientUrlDev;
    // apiUrl = apiUrlProd;
}
console.log(apiUrl);