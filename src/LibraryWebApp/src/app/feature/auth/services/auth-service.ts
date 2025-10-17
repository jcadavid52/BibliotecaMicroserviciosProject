import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { LoginModel } from "../models/login-model";
import { RegisterModel } from "../models/register-model";
import { accountUrlApi } from "../../../../enviroments/urlApi";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private httpClient = inject(HttpClient);

    public login(loginModel: LoginModel) {
        return this.httpClient.post(`${accountUrlApi}/login`, loginModel);
    }

    public register(registerModel: RegisterModel){
        return this.httpClient.post(`${accountUrlApi}/register`, registerModel);
    }

}