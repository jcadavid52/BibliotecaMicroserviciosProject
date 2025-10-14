import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavMaster } from './core/components/nav-master/nav-master';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavMaster],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('LibraryWebApp');
}
