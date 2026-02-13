import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { ApiService } from './api.service';

export interface AuthCredentials {
    username: string; 
    password: string;
}

export interface AuthToken {
    accessToken: string;
    refreshToken: string;
    expiresIn: number;
}

export interface RegisterCredentials{
    
}

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiUrl = '/auth';
    private currentUserSubject = new BehaviorSubject<any>(null);
    public currentUser$ = this.currentUserSubject.asObservable();
    private _apiService: ApiService;

    constructor(private http: HttpClient, private apiServiceInstance: ApiService) {
        this._apiService = apiServiceInstance;
        this.loadUser();
    }

    login(credentials: AuthCredentials): Observable<AuthToken> {
        return this.http.post<AuthToken>(`${this.apiUrl}/login`, credentials).pipe(
            tap(token => this.storeToken(token))
        );
    }

    register(credentials: RegisterCredentials): Observable<any> {
        console.log(`${this.apiUrl}/register`)
        return this._apiService.post(`${this.apiUrl}/register`, credentials).pipe(
            map(response => response)
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