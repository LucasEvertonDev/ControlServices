import { FormControl } from "@angular/forms";

export interface FormLogin {
    login: FormControl<string>;
    password: FormControl<string>;
}