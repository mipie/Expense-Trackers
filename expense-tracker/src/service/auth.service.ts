import { Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { Users } from "../model/users";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    constructor(private http: HttpClient){}


    Signup(user: Users): Observable<any> {

        return this.http.post(`${environment.apiUrl}/auth/signup`, user); 
    }

    signIn(email: string, password: string): Observable<any> {
        
        return this.http.post(`${environment.apiUrl}/auth/signin`, {email, password})
    }
}