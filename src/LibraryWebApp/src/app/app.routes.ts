import { Routes } from '@angular/router';
import { NavBook } from './feature/book/components/nav-book/nav-book';
import { BookLayout } from './layout/book-layout/book-layout';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./core/pages/presentation-page').then(c => c.PresentationPage)
    },
    {
        path: 'books',
        component:BookLayout,
        children: [
            {
                path: '',
                pathMatch: 'full',
                redirectTo: 'home'
            },
            {
                path: 'home',
                loadComponent: () => import('./feature/book/pages/home-book-page').then(c => c.HomeBookPage)
            },
            {
                path: 'create',
                loadComponent: () => import('./feature/book/pages/create-book-page').then(c => c.CreateBookPage)
            },
            {
                path: 'reservations',
                loadComponent: () => import('./feature/book/pages/reservation-book-page').then(c => c.ReservationBookPage)
            }
        ]
    },
    {
        path: 'auth',
        children: [
            {
                path: '',
                pathMatch: 'full',
                redirectTo: 'login'
            },
            {
                path: 'login',
                loadComponent: () => import('./feature/auth/pages/login-page').then(c => c.LoginPage)
            }
        ]
    }
];
