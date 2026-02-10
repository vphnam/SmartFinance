import { Routes } from '@angular/router';
import { MainLayoutComponent } from './shared/layouts/components/main-layout-component/main-layout-component';
import { AuthLayoutComponent } from './shared/layouts/components/auth-layout-component/auth-layout-component';

export const routes: Routes = [
    { path: '', 
        component: MainLayoutComponent,
        children: [
        { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
        { path: 'dashboard', loadChildren: () => import('./features/dashboard/dashboard.routes').then(m => m.DASHBOARD_ROUTES)},
        { path: 'customer', loadChildren: () => import('./features/customer/customer.routes').then(m => m.CUSTOMER_ROUTES)},
        ] 
    },
    { path: '', 
        component: AuthLayoutComponent,
        children: [
        { path: 'auth', loadChildren: () => import('./features/auth/auth.routes').then(m => m.AUTH_ROUTES) },
        ] 
    },

];
