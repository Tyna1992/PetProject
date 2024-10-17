import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../userService/user.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { OrderComponent } from '../../order/order.component';

@Component({
  selector: 'app-profile-data',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, OrderComponent],
  templateUrl: './profile-data.component.html',
  styleUrls: ['./profile-data.component.css']
})
export class ProfileDataComponent implements OnInit {
  user: any;
  userData: any;
  primaryAddress: any = null;
  primaryForm: FormGroup;
  public primaryFormOpen = false;

  constructor(private userService: UserService, private fb: FormBuilder) {
    this.primaryForm = this.fb.group({
      street: ['', Validators.required],
      houseNumber: ['', Validators.required],
      zipCode: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.userService.whoAmI().subscribe(
      (resp) => {
        this.user = resp;
      },
      (error) => {
        console.error('Failed to get user info:', error);
      }
    );
  }

  loadProfileData() {
    this.userService.getUserDetails(this.user.id).subscribe(
      (resp) => {
        this.userData = resp;
      },
      (error) => {
        console.error('Failed to get user details:', error);
      }
    );
    console.log(this.userData);
  }

  loadPrimaryAddress() {
    this.userService.getAddress(this.user.id).subscribe(
      (resp) => {
        this.primaryAddress = resp[0] || false; 
      },
      (error) => {
        console.error('Failed to get primary address:', error);
        this.primaryAddress = false;
      }
    );
    console.log(this.primaryAddress);
  }

  openPrimaryForm() {
    this.primaryFormOpen = true;
  }

  onPrimarySubmit() {
    if (this.primaryForm.valid) {
      this.primaryAddress = {
        Street: this.primaryForm.value.street,
        HouseNumber: this.primaryForm.value.houseNumber,
        ZipCode: this.primaryForm.value.zipCode,
        City: this.primaryForm.value.city,
        Country: this.primaryForm.value.country,
        UserId: this.user.id
      }
      this.userService.addPrimaryAddress(this.user.id,this.primaryAddress).subscribe(
        (resp) => {
          console.log("Primary address successfully added:", resp);
          this.primaryFormOpen = false;
          this.primaryForm.reset();
        }, (error) => {
          console.error(error);
        }
      )
    }
  }
}
