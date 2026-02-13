import { Component } from '@angular/core';
import { RegisterComponentForm } from './register-component.form';
import { ReactiveFormsModule } from '@angular/forms';
import { FormValidatorService } from '../../../services/form-validator.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-register-component',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register-component.html',
  styleUrl: './register-component.css',
})
export class RegisterComponent {

  constructor(protected formValidator: FormValidatorService, private authService: AuthService) {}
  registerForm = new RegisterComponentForm().setForm();
  onSubmit() {
      console.log(this.registerForm.value);
      this.authService.register(this.registerForm.value).subscribe({
        next: (response) => {
          console.log('Registration successful', response);
        }
      });
  }


}
