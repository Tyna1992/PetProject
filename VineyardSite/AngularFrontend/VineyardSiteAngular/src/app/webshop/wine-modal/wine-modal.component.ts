import { Component, Input, Output, EventEmitter  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../../checkout/cart.service';

@Component({
  selector: 'app-wine-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './wine-modal.component.html',
  styleUrl: './wine-modal.component.css'
})
export class WineModalComponent {
  @Input() data: any;
  @Input() userData: any;
  @Output() closeModal = new EventEmitter<void>();
  
  constructor(private cartService: CartService) {}

  addToCart() {
    const quantity = 1;
    this.cartService.addCartItem(this.data.DrinkId, quantity, this.userData.userName).subscribe(
      (response: string) => {
        console.log("success", response)
      }
    )
  }

  close() {
    this.closeModal.emit();
  }
}

