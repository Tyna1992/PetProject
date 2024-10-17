import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CartService } from './cart.service';
import { UserService } from '../userService/user.service';
import { OrderService } from '../orderService/order.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  cartItems: any[] = [];
  user: any;
  totalPrice: number = 0;
  addressForm: FormGroup;
  orderForm: FormGroup;
  orderReq: any;
  public showOrder = false;
  address: any[] =[];

  constructor(private fb: FormBuilder, private cartService: CartService, private userService: UserService, private orderService: OrderService) {
    this.addressForm = this.fb.group({
      street: ['', Validators.required],
      houseNumber: ['', Validators.required],
      zipCode: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required]
    });

    this.orderForm = this.fb.group({
      Address: ['', Validators.required],
      DeliveryType: ['', Validators.required],
      Payment: ['', Validators.required],
      Notes: ['']
    })
  }

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

  onOrder() {
    this.userService.getAddress(this.user.id).subscribe(
      (resp) => {
        this.address = resp || false;
      },
      (error) => {
        console.error('Failed to get address:', error);
      }
    )
    this.showOrder = true;
    
  }

  sendOrder() {
    if (this.orderForm.valid) {
      this.orderReq = {
        UserId: this.user.id,
        DeliveryType: this.orderForm.value.DeliveryType,
        PaymentType: this.orderForm.value.Payment,
        Notes: this.orderForm.value.Notes
      }

      this.orderService.sendOrder(this.orderReq).subscribe(
        (resp) => {
          console.log(resp)
        }, 
        (error) => {
          console.error('Failed to send order', error);
        }
      )
    }
  }
  onOrderSubmit() {
    if (this.addressForm.valid) {
      this.address[0] = {
        Street: this.addressForm.value.street,
        HouseNumber: this.addressForm.value.houseNumber,
        ZipCode: this.addressForm.value.zipCode,
        City: this.addressForm.value.city,
        Country: this.addressForm.value.country,
        UserId: this.user.id
      }
      this.userService.addPrimaryAddress(this.user.id,this.address[0]).subscribe(
        (resp) => {
          console.log("Primary address successfully added:", resp);
          this.addressForm.reset();
          this.showOrder = false;
        }, (error) => {
          console.error(error);
        }
      )
    }
  }
}
