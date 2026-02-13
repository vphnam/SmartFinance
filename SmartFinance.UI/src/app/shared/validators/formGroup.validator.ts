import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export const passwordMatchValidator: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
    const password = group.get('password')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;
    const confirmControl = group.get('confirmPassword');

    if(!password || !confirmPassword){
        return null;
    }

    if(password === '' || confirmPassword === ''){
        return null;
    }

    if(password !== confirmPassword){
        const existingErrors = group.get('confirmPassword')?.errors || {};

         confirmControl?.setErrors({
        ...existingErrors,
        passwordMismatch: true
        });
    }
    else
    {
        if(confirmControl?.hasError('passwordMismatch')){
            const { passwordMismatch, ...remainingErrors } =
            confirmControl?.errors || {};

            confirmControl?.setErrors(
                Object.keys(remainingErrors).length > 0 ? remainingErrors : null
            );
        }


    }
    return null;
}