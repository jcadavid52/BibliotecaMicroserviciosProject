import { Component, inject } from "@angular/core";
import { Router, RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from "@angular/router";
import { TokenService } from "../../../auth/services/token-service";

@Component({
    selector: 'nav-book',
    templateUrl: './nav-book.html',

    imports: [RouterLink,
        RouterLinkActive,
        RouterModule,
    ]
})
export class NavBook {
    tokenService = inject(TokenService);
    router = inject(Router);
}