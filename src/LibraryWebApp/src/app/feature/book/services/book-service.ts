import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { BookModel } from "../models/book-model";
import { bookUrlApi } from "../../../../enviroments/prod";

@Injectable({
        providedIn: 'root'
    })
export class BookService {
private httpClient = inject(HttpClient)

public getBooks(titleFilter?: string) {
    const url = titleFilter ? `${bookUrlApi}?title=${encodeURIComponent(titleFilter)}` : bookUrlApi;
    return this.httpClient.get<BookModel[]>(url);
}
}