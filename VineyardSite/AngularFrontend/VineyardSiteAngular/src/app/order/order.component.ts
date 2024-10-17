import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderService } from '../orderService/order.service';


@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  @Input() user: any;
  orders: any[] = [];
  public orderShow = false;
  constructor(private orderService: OrderService) {}

  loadOrders() {
    this.orderService.getOrders(this.user.id).subscribe(
      (resp) => {
        this.orders = resp || false;
        console.log(this.orders)
      }, 
      (error) => {
        console.error(error);
      }
    )

    this.orderShow = true;
  }
}
