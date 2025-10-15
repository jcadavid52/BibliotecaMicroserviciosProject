import { Routes } from '@angular/router';
import { NavBook } from './feature/book/components/nav-book/nav-book';
import { BookLayout } from './layout/book-layout/book-layout';
import { loginGuard } from './core/guards/login-guard';
import { createBookGuard } from './core/guards/create-book-guard';
import { reservationBookGuard } from './core/guards/reservations-book-guard';

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
                loadComponent: () => import('./feature/book/pages/create-book-page').then(c => c.CreateBookPage),
                canActivate: [createBookGuard]
            },
            {
                path: 'reservations',
                loadComponent: () => import('./feature/book/pages/reservation-book-page').then(c => c.ReservationBookPage),
                canActivate: [reservationBookGuard]
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
                loadComponent: () => import('./feature/auth/pages/login-page').then(c => c.LoginPage),
                canActivate: [loginGuard]
            },
            {
                path: 'register',
                loadComponent: () => import('./feature/auth/pages/register-page').then(c => c.RegisterPage)
            }
        ]
    }
];
