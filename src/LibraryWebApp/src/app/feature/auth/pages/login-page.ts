import { Component } from "@angular/core";
import { FormLogin } from "../components/form-login/form-login";

@Component({
    selector: 'login-page',
    templateUrl: './login-page.html',
    imports: [FormLogin]
})
export class  LoginPage{

}