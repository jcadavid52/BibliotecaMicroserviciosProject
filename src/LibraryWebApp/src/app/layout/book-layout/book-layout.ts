import { Component } from "@angular/core";
import { NavBook } from "../../feature/book/components/nav-book/nav-book";
import { RouterOutlet } from "@angular/router";

@Component({
    selector: 'book-layout',
    templateUrl: './book-layout.html',
    imports: [NavBook,RouterOutlet]
})
export class BookLayout{

}