import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { LoginModel } from "../models/login-model";
import { RegisterModel } from "../models/register-model";

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private url: string = "http://localhost:5052/api/account";


    private httpClient = inject(HttpClient);

    public login(loginModel: LoginModel) {
        return this.httpClient.post(`${this.url}/login`, loginModel);
    }

    public register(registerModel: RegisterModel){
        return this.httpClient.post(`${this.url}/register`, registerModel);
    }

}