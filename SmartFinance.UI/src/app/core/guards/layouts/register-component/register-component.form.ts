import { FormControl, FormGroup, Validators } from "@angular/forms";

export class RegisterComponentForm {

    private registerForm = new FormGroup({
        emailAddress: new FormControl('', {
            nonNullable: true,
            validators : [Validators.required, Validators.email, Validators.maxLength(100)]
        }),
        userName: new FormControl('', {
            nonNullable: true,
            validators : [Validators.required, Validators.minLength(4), Validators.maxLength(200)]
        }),
        phoneNumber: new FormControl('', {
            nonNullable: true,
            validators: [Validators.required, Validators.pattern('^\\+?[1-9]\\d{1,14}$'), Validators.maxLength(20)]
        }),
        brokerNumber: new FormControl('', {
            nonNullable: true,
            validators: [Validators.required, Validators.minLength(5), Validators.maxLength(20)]
        }),
    });

    public setForm()
    {
        return this.registerForm;
    }
}