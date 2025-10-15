import { Component } from "@angular/core";
import { FormFilterBook } from "../components/form-filter-book/form-filter-book";
import { ListBook } from "../components/list-book/list-book";
import { NavBook } from "../components/nav-book/nav-book";
import { RouterOutlet } from "@angular/router";
import { BookLayout } from "../../../layout/book-layout/book-layout";

@Component({
    selector: 'home-book-page',
    templateUrl: './home-book-page.html',
    imports: [ListBook]
})
export class HomeBookPage{

}