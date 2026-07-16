import { Component, inject } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { InputTextModule } from "primeng/inputtext";
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { User } from '@primeicons/angular/user';
import { InputPasswordModule } from 'primeng/inputpassword';
import { Lock } from '@primeicons/angular/lock';
import { InputIconModule } from 'primeng/inputicon';
import { IconFieldModule } from 'primeng/iconfield';
import { Eye } from '@primeicons/angular/eye';
import { EyeSlash } from '@primeicons/angular/eye-slash';
import { CheckCircle } from '@primeicons/angular/check-circle';
import { MessageService } from 'primeng/api';
import { MessageModule } from 'primeng/message';
import { Users } from "../../model/users";


@Component({
    selector: 'sign-up',
    standalone: true,
    templateUrl: 'sign-up.html',
    imports: [MessageModule, InputTextModule, FormsModule, InputGroupModule, InputGroupAddonModule, User, InputPasswordModule, InputIconModule, Lock, IconFieldModule, Eye, EyeSlash, CheckCircle] 
})

export class Signup {
    messageService = inject(MessageService);
    
    user: Users =  {
        firstname: '',
        lastname: '',
        email:'',
        password: '',
        confirmPassword: ''
    };

    mask: boolean = true;

    requirements = [
        { id: 'minLength', label: 'At least 12 characters', test: (v: string) => v.length >= 12 },
        { id: 'uppercase', label: 'Contains uppercase letter', test: (v: string) => /[A-Z]/.test(v) },
        { id: 'lowercase', label: 'Contains lowercase letter', test: (v: string) => /[a-z]/.test(v) },
        { id: 'number', label: 'Contains number', test: (v: string) => /[0-9]/.test(v) },
        { id: 'symbol', label: 'Contains special character', test: (v: string) => /[^a-zA-Z0-9]/.test(v)}
    ]

    onSignUp() {
        console.log(this.user)
    }
}