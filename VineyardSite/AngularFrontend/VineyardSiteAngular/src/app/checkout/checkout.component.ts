import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ICartItem } from '../Models/CartItem';
import { CartService } from './cart.service';
import { ICart } from '../Models/Cart';
import { UserService } from '../userService/user.service';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'] // fixed typo from styleUrl to styleUrls
})
export class CheckoutComponent {
  cartItems: any[] = []; // Changed to cartItems to match ICart interface
  user: any;
  totalPrice: number = 0;

  constructor(private cartService: CartService, private userService: UserService) {}

  ngOnInit(): void {
    this.userService.whoAmI().subscribe(
      (resp) => {
        this.user = resp;

        if (this.user && this.user.userName) {
          this.loadCart();
        } else {
          console.error('User data is missing, cannot load cart.');
        }
      },
      (error) => {
        console.error('Failed to get user info:', error);
      }
      
    )

  }

  handleLoad() {
    console.log(this.cartItems)
  }

  loadCart() {

    if (!this.user || !this.user.userName) {
      console.error('No user info available. Cannot load cart.');
      return;
    }

    this.cartService.getCart(this.user.userName).subscribe(
      (resp) => {
        this.cartItems = resp;
        this.totalPrice = this.cartItems.reduce((sum, item) => sum + (item.wineVersion.price * item.quantity), 0);
      }, (error) => {
        console.error('Failed to load cart:', error);
      }
    );
  }
}
