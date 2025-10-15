import { Component, inject } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { TokenService } from "../../../feature/auth/services/token-service";

@Component({
    selector: 'nav-master',
    templateUrl: './nav-master.html',
    imports: [
        RouterLink,
        RouterLinkActive
    ],
})
export class NavMaster {
    tokenService = inject(TokenService);
    router = inject(Router);

    closeSession() {
        this.tokenService.clearAuthToken();
        this.router.navigate(['/auth/login']);
    }
}