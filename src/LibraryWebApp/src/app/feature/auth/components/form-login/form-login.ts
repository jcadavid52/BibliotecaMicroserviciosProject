import { Component, inject, signal } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth-service";
import { LoginModel } from "../../models/login-model";
import { Router } from "@angular/router";
import { LoginResponseModel } from "../../models/login-response-model";
import { HttpErrorResponse } from "@angular/common/http";
import { TokenService } from "../../services/token-service";
import { NotificationService } from "../../../../core/services/notificaction-service";

@Component({
    selector: 'form-login',
    imports: [ReactiveFormsModule],
    templateUrl: './form-login.html'
})
export class FormLogin {
    private formBuilder = inject(FormBuilder);
    private authService = inject(AuthService);
    private tokenService = inject(TokenService);
    private router = inject(Router);
    private  notificationService = inject(NotificationService);

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
            this.authService.login(this.loginForm.value as LoginModel).subscribe({
                next: (response) => {
                    this.loginResponse = response as LoginResponseModel;
                    this.tokenService.setAuthToken(this.loginResponse.accessToken);
                    this.tokenService.setRefreshToken(this.loginResponse.refreshToken);
                    this.router.navigate(['/books']);
                },
                error: (error: HttpErrorResponse) => {
                    if (error.status === 401) {
                        console.error('Credenciales inválidas. Por favor, verifica tu usuario y contraseña.');
                        this.notificationService.notify("Credenciales inválidas. Por favor, verifica tu usuario y contraseña.");
                    }
                }
            });
        }
    }

}