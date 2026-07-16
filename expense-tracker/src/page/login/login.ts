import { Component } from "@angular/core";
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

@Component({
    selector: 'login',
    standalone: true,
    templateUrl: 'login.html',
    imports: [InputGroup, InputGroupAddon, User, InputText, FormsModule, IconField, InputIcon, InputPassword, Eye, EyeSlash, Lock ],

})
export class Login {
    user: Users = {
        firstname: '',
        lastname: '', 
        email:'',
        password:'',
        confirmPassword:''
    };
    mask: boolean = true;

    onSubmit() {
        
    }
}
