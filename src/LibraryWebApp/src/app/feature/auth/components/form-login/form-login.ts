import { Component, inject, signal } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth-service";
import { LoginModel } from "../../models/login-model";
import { Router, RouterLink } from "@angular/router";
import { LoginResponseModel } from "../../models/login-response-model";
import { HttpErrorResponse } from "@angular/common/http";
import { TokenService } from "../../services/token-service";

@Component({
    selector: 'form-login',
    imports: [ReactiveFormsModule, RouterLink],
    templateUrl: './form-login.html'
})
export class FormLogin {
    private formBuilder = inject(FormBuilder);
    private authService = inject(AuthService);
    private tokenService = inject(TokenService);
    private router = inject(Router);

    private loginModel: LoginModel | null = null;
    private loginResponse: LoginResponseModel | null = null;

    public submitted = signal(false);

    public loginForm = this.formBuilder.group({
        username: ['', [Validators.required]],
        password: ['', [Validators.required]],
    })

    onSubmit() {
        this.submitted.set(true);
        if (this.loginForm.valid) {
            console.log(this.loginForm.value);
            this.authService.login(this.loginForm.value as LoginModel).subscribe({
                next: (response) => {
                    this.loginResponse = response as LoginResponseModel;
                    console.log('Login exitoso:', this.loginResponse);
                    this.tokenService.setAuthToken(this.loginResponse.accessToken);
                    this.tokenService.setRefreshToken(this.loginResponse.refreshToken);
                    const role = this.tokenService.decodeRoleToken();
                    console.log('Rol decodificado del token:', role[0]);
                    // if(role === 'Admin'){
                    //     this.router.navigate(['/admin']);
                    // }else {
                    //     this.router.navigate(['/']);
                    // }
                },
                error: (error: HttpErrorResponse) => {
                    if (error.status === 401) {
                        console.error('Credenciales inválidas. Por favor, verifica tu usuario y contraseña.');
                    }
                }
            });
        }
    }

}