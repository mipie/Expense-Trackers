import { Injectable } from "@angular/core";
import { AuthResponse, createClient, SupabaseClient } from "@supabase/supabase-js";
import { environment } from "../environments/environment";
import { Users } from "../model/users";

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private supabase: SupabaseClient = createClient(
        environment.supabaseUrl,
        environment.supabaseKey
    )

    constructor() {

    }

    async Signup(user: Users): Promise<AuthResponse> {
        const response = await this.supabase.auth.signUp({
            email: user.email,
            password: user.password,
            options: {
                data: {
                    first_name: user.firstname,
                    last_name: user.lastname,
                    created_at: new Date().toISOString()
                }
            }
        });

        return response;
    }

    async signIn(email: string, password: string): Promise<AuthResponse | undefined> {
        console.log('Tentative de connexion avec :', { email, password });
        const response = await this.supabase.auth.signInWithPassword({
            email: email,
            password: password
        });

        if (response.error) {
            console.error('Erreur Supabase :', response.error.message);
            return;
        }

        return response;
    }
}