import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICart } from '../Models/Cart';
import { IWineVariant } from '../Models/WineVariant';
import { ICartItem } from '../Models/CartItem';


@Injectable({
  providedIn: 'root'
})
export class CartService {
  private apiUrl = '/api/Cart';

  constructor(private http: HttpClient) {}

  getCart(userName: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetCart/${userName}`);
  }

  addCartItem(drinkId: number, quantity: number, userName: string): Observable<string> {
    return this.http.post(`${this.apiUrl}/AddCartItem/${drinkId}/${quantity}/${userName}`, {}, { responseType: 'text' });
  }
}
