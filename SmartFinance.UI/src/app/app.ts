import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './shared/layouts/components/navbar-component/navbar-component';
import { AuthLayoutComponent } from './shared/layouts/components/auth-layout-component/auth-layout-component';
import { MainLayoutComponent } from './shared/layouts/components/main-layout-component/main-layout-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('SmartFinance.UI');
}
