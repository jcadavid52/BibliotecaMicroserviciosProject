import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { TokenService } from "../../feature/auth/services/token-service";

export const loginGuard: CanActivateFn = (route, state) => {
    const tokenService = inject(TokenService);
    const router = inject(Router);

    if(tokenService.isAuthenticated()){
        router.navigate(['/books']);
        return false;
    }
    return true;
}