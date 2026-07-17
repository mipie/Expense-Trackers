import { Component, inject } from "@angular/core";
import { InputGroup } from "primeng/inputgroup";
import { InputGroupAddon } from "primeng/inputgroupaddon";
import { User } from '@primeicons/angular/user';
import { InputText } from "primeng/inputtext";
import { Users } from "../../model/users";
import { FormsModule } from "@angular/forms";
import { IconField } from "primeng/iconfield";
import { InputIcon } from "primeng/inputicon";
import { InputPassword } from "primeng/inputpassword";
import { Eye } from "@primeicons/angular/eye";
import { EyeSlash } from "@primeicons/angular/eye-slash";
import { Lock } from '@primeicons/angular/lock';
import { AuthService } from "../../service/auth.service";
import { Router } from "@angular/router";
import { AuthResponse } from "@supabase/supabase-js";

@Component({
    selector: 'login',
    standalone: true,
    templateUrl: 'login.html',
    imports: [InputGroup, InputGroupAddon, User, InputText, FormsModule, IconField, InputIcon, InputPassword, Eye, EyeSlash, Lock ],

})
export class Login {
    authService = inject(AuthService);
    router = inject(Router);
    errorMessage = ''

    user: Users = {
        firstname: '',
        lastname: '', 
        email:'',
        password:'',
        confirmPassword:''
    };
    mask: boolean = true;

    async onSubmit() {
        const {data, error} = await this.authService.signIn(this.user.email, this.user.password) as AuthResponse;

        if (error) {
            this.errorMessage = error.message;
        } else {
            console.log(data);
            this.router.navigate(['/home']);
        }
    }
}
