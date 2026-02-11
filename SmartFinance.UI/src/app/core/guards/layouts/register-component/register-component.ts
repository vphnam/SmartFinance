import { Component } from '@angular/core';
import { RegisterComponentForm } from './register-component.form';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-register-component',
  imports: [ReactiveFormsModule],
  templateUrl: './register-component.html',
  styleUrl: './register-component.css',
})
export class RegisterComponent {
  registerForm = new RegisterComponentForm().setForm();

  onSubmit() {}
}
