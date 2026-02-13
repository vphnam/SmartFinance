import { Injectable } from "@angular/core";
import { AbstractControl } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class FormValidatorService {

    hasError(control: AbstractControl): boolean {
        return !!(control && control.errors && control.touched);
    }

    hasErrorName(control: AbstractControl, errorName: string): boolean {
        return !!(control && control.errors && control.touched && control.errors?.[errorName]);
    }

    getErrorMessages(control: AbstractControl): string | null{
        if(!control || !control.errors || !control.touched)
            return null;

        var errorMessages = control.errors; 
        console.log(errorMessages);
        const firstError = Object.keys(errorMessages)[0];

        return this.buildErrorMessage(firstError, errorMessages[firstError]);
    }

    buildErrorMessage(errorKey: string, errorValue: any): string {
        switch(errorKey) {
            case 'required':
                return 'This field is required.';
            case 'email':
                return 'Please enter a valid email address.';
            case 'minlength':
                return `Minimum length is ${errorValue.requiredLength} characters.`;
            case 'maxlength':
                return `Maximum length is ${errorValue.requiredLength} characters.`;
            case 'pattern':
                return 'The input format is invalid.';
            case 'passwordMismatch':
                return 'The passwords do not match.';
        }
        return '';
    }
}