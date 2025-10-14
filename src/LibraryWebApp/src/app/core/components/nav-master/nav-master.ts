import { Component } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
    selector: 'nav-master',
    templateUrl: './nav-master.html',
    imports: [
        RouterLink,
        RouterLinkActive
    ],
})
export class NavMaster {

}