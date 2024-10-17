import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isLoggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  whoAmI(): Observable<any>{ 
    return this.http.get('/api/Auth/WhoAmI');
  }

  isLoggedIn$(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  setLoginStatus(status: boolean) {
    this.isLoggedIn.next(status);
  }

  login() {
    this.setLoginStatus(true);
  }

  logout() {
    this.setLoginStatus(false);
  }

  getUserDetails(id: any): Observable<any>{
    return this.http.get(`/api/User/GetUserDetails/${id}`);
  }

  getAddress(id: any): Observable<any> {
    return this.http.get(`/api/User/GetAllAddress/${id}`);
  }

  addPrimaryAddress(id: any, data: any): Observable<any> {
    console.log('body: ', data)
    return this.http.post(`/api/User/AddAddress/${id}`, data);
  }
}
