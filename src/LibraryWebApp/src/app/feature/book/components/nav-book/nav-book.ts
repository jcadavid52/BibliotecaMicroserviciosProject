import { Component } from "@angular/core";
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from "@angular/router";

@Component({
    selector: 'nav-book',
    templateUrl: './nav-book.html',

    imports: [RouterLink,RouterLinkActive,RouterOutlet,RouterModule]
})
export class NavBook{

}