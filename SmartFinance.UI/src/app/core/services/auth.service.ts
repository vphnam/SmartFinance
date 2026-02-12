import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap, map } from 'rxjs/operators';

export interface AuthCredentials {
    username: string; 
    password: string;
}

export interface AuthToken {
    accessToken: string;
    refreshToken: string;
    expiresIn: number;
}

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiUrl = '/api/auth';
    private currentUserSubject = new BehaviorSubject<any>(null);
    public currentUser$ = this.currentUserSubject.asObservable();

    constructor(private http: HttpClient) {
        this.loadUser();
    }

    login(credentials: AuthCredentials): Observable<AuthToken> {
        return this.http.post<AuthToken>(`${this.apiUrl}/login`, credentials).pipe(
            tap(token => this.storeToken(token))
        );
    }

    logout(): void {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        this.currentUserSubject.next(null);
    }

    isAuthenticated(): boolean {
        return !!localStorage.getItem('accessToken');
    }

    getToken(): string | null {
        return localStorage.getItem('accessToken');
    }

    private storeToken(token: AuthToken): void {
        localStorage.setItem('accessToken', token.accessToken);
        localStorage.setItem('refreshToken', token.refreshToken);
    }

    private loadUser(): void {
        if (this.isAuthenticated()) {
            this.http.get(`${this.apiUrl}/me`).subscribe(
                user => this.currentUserSubject.next(user)
            );
        }
    }
}