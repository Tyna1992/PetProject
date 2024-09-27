import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WineModalComponent } from '../wine-modal/wine-modal.component';
import { CartService } from '../../checkout/cart.service';
import { UserService } from '../../userService/user.service';

@Component({
  selector: 'app-webshop-wine-card',
  standalone: true,
  imports: [CommonModule, WineModalComponent],
  templateUrl: './webshop-wine-card.component.html',
  styleUrl: './webshop-wine-card.component.css'
})
export class WebshopWineCardComponent {
  @Input() wine: any;
  user: any;
  constructor(private cartService: CartService, private userService: UserService) {}

  showModal = false;

  ngOnInit(): void {
    this.userService.whoAmI().subscribe(
      (resp) => {
        this.user = resp;
      },
      (error) => {
        console.error('Failed to get user info:', error);
      }
    )

  }
  handleMoreDetails() {
    this.showModal = true;
  }

  addToCart() {
    const quantity = 1;
    this.cartService.addCartItem(this.wine.DrinkId, quantity, this.user.userName).subscribe(
      (response: string) => {
        console.log("success", response)
      }
    )
  }

  closeModal() {
    this.showModal = false;
  }
}

