import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { BookModel } from "../models/book-model";

@Injectable({
        providedIn: 'root'
    })
export class BookService {
private httpClient = inject(HttpClient)
private url: string = "http://localhost:5015/api/Book";

public getBooks(titleFilter?: string) {
    const url = titleFilter ? `${this.url}?title=${encodeURIComponent(titleFilter)}` : this.url;
    return this.httpClient.get<BookModel[]>(url);
}
}