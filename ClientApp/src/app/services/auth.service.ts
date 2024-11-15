import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, firstValueFrom, Observable, tap } from "rxjs";
import { UserResponseDTO } from "../generated-api-client";
import { AccountsService } from "../generated-api-client/api/accounts.service";

@Injectable({
    providedIn: 'root',
})
export class AuthService {

    private _currentUser: BehaviorSubject<UserResponseDTO | null> = new BehaviorSubject<UserResponseDTO | null>(null);
    public readonly currentUser: Observable<UserResponseDTO | null> = this._currentUser.asObservable();
    
    constructor(
        private accountService: AccountsService
    ) {
        this.setUser(this.getUser());
     }


    login(data: any) {
        return this.accountService.apiAccountsLoginPost(data)
            .pipe(tap((res) => {
                this.setAccessToken(res.accessToken!);
                this.setUser(res.user!);
            }));
    }

    public logout(): void {
        localStorage.removeItem('access_token');
        localStorage.removeItem('user');
        this.setUser(null);
    }

    isLoggedIn() {
        return localStorage.getItem('user') !== null;
    }

    public setAccessToken(accessToken: string): void {
        localStorage.setItem('access_token', accessToken);
    }

    public getAccessToken(): string | null {
        return localStorage.getItem('access_token');
    }

    public setUser(user: UserResponseDTO | null): void {
        if (user != null)
            localStorage.setItem('user', JSON.stringify(user));
        this._currentUser.next(user);
    }

    public getUser(): UserResponseDTO | null {
      const userJson = localStorage.getItem('user');
      return JSON.parse(userJson!) as UserResponseDTO;
    }
}