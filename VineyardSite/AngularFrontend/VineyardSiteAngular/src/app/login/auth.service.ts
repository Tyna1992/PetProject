import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = '/api/auth/login';
  private isLoggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) {}

  login(credentials: { username: string; password: string }): Observable<any> {
    return this.http.post<any>(this.apiUrl, credentials).pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
        this.setLoginStatus(true);
      }),
      catchError(error => {
        console.error('Login error', error);
        return of(null);
      })
    );
  }

  loginSet(){
    this.setLoginStatus(true);
  }

  isLoggedIn$(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  setLoginStatus(status: boolean) {
    this.isLoggedIn.next(status);
  }

  logout() {
    this.setLoginStatus(false);
  }

  isAuthenticated(): boolean {
    return this.isLoggedIn.value;
  }
}
