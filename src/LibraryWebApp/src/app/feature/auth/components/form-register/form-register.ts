import { Component, inject, signal } from "@angular/core";
import { AbstractControl, FormBuilder, ReactiveFormsModule, ValidationErrors, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth-service";
import { RegisterModel } from "../../models/register-model";
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
    selector: 'form-register',
    templateUrl: './form-register.html',
    imports: [
        ReactiveFormsModule
    ],
})
export class FormRegister {

    public submitted = signal(false);
    public formbuilder = inject(FormBuilder);
    public authService = inject(AuthService);
    public formRegister = this.formbuilder.group({
        fullName: ['', [Validators.required]],
        documentType: ['', [Validators.required]],
        document: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
        address: ['', [Validators.required]],
        phoneNumber: ['', [Validators.required]],
    },
        {
            validators: this.passwordMatchValidator
        });

    private router = inject(Router);

    private passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
        const password = control.get('password');
        const confirmPassword = control.get('confirmPassword');

        if (password && confirmPassword && password.value !== confirmPassword.value) {
            return { passwordMismatch: true };
        }
        return null;
    }

    public onSubmit() {
        this.submitted.set(true);
        if (this.formRegister.valid) {
            console.log(this.formRegister.value);
            this.authService.register(this.formRegister.value as RegisterModel).subscribe({
                next:(response) => {
                    console.log(response);
                    this.router.navigate(['/auth/login']);

                },
                error:(error: HttpErrorResponse) => {
                    console.error(error)
                }
            })
        }
    }
}