import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  sendOrder(orderRequest: any): Observable<any> {
    return this.http.post('/api/Order/AddOrder', orderRequest);
  }

  getOrders(id: any): Observable<any> {
    return this.http.get(`/api/Order/GetOrdersByUserId/${id}`);
  }
}
