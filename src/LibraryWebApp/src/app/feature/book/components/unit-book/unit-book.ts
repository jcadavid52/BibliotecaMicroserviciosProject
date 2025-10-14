import { Component, Input } from "@angular/core";
import { BookModel } from "../../models/book-model";

@Component({
    selector: 'unit-book',
    templateUrl: './unit-book.html'
})
export class UnitBook{
@Input()
book:BookModel | undefined;
}