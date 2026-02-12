import { Component } from '@angular/core';
import { RegisterComponentForm } from './register-component.form';
import { ReactiveFormsModule } from '@angular/forms';
import { FormValidatorService } from '../../../services/form-validator.service';

@Component({
  selector: 'app-register-component',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register-component.html',
  styleUrl: './register-component.css',
})
export class RegisterComponent {

  constructor(protected formValidator: FormValidatorService) {}
  registerForm = new RegisterComponentForm().setForm();
  onSubmit() {
    console.log(this.registerForm);
  }
}
