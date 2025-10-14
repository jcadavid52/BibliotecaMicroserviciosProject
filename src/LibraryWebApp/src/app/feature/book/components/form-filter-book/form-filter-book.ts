import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'form-filter-book',
    templateUrl: './form-filter-book.html'
})
export class FormFilterBook{

@Input()
  initialValue: string = '';

@Output()
searchTitle = new EventEmitter<string>();

onSearchChange(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    const searchTerm = inputElement.value;
    console.log('Término de búsqueda:', searchTerm);
    this.searchTitle.emit(searchTerm);
  }
}