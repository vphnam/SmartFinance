import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../../core/guards/layouts/login-component/login-component';
import { RegisterComponent } from '../../core/guards/layouts/register-component/register-component';

export const AUTH_ROUTES: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent}
    
];