import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  whoAmI(): Observable<any>{ 
    return this.http.get('/api/Auth/WhoAmI');
  }
}
