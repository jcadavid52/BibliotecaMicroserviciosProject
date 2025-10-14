import { Component, inject, OnInit } from "@angular/core";
import { FormFilterBook } from "../form-filter-book/form-filter-book";
import { ActivatedRoute, Router } from "@angular/router";
import { of, switchMap } from "rxjs";
import { BookService } from "../../services/book-service";
import { BookModel } from "../../models/book-model";
import { UnitBook } from "../unit-book/unit-book";

@Component({
    selector: 'list-book',
    templateUrl: './list-book.html',
    imports: [FormFilterBook,UnitBook]
})
export class ListBook implements OnInit {

    public books: BookModel[] = [];

    private route = inject(ActivatedRoute);
    private router = inject(Router);
    private bookService = inject(BookService);

    ngOnInit(): void {
        console.log('Componente ListBook inicializado');

        this.route.queryParams.pipe(
            switchMap(params => {
                const query = params['title'] || '';
                this.onFilter(query)
                return of(null);
            })
        ).subscribe();
    }

    onFilter(title: string): void {
        const titleFilter = title.toLowerCase().trim();
        this.onGetBooks(titleFilter);
    }

    onSearch(title: string): void {
        console.log('Búsqueda recibida en ListBook:', title);
        this.router.navigate([], {
            relativeTo: this.route,
            queryParams: { title: title || null },
            queryParamsHandling: 'merge',
        });
    }

    onGetBooks(titleFilter?: string){
        this.bookService.getBooks(titleFilter).subscribe({
            next: (books) => {
                console.log('Libros obtenidos:', books);
                this.books = books;
            },
            error: (error) => {
                console.error('Error al obtener los libros:', error);
            }
        });
    }
}