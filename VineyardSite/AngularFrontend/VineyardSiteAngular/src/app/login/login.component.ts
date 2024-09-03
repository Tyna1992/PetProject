import { Component } from '@angular/core';
import { FormControl,ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username = new FormControl('');
  password = new FormControl('');

  onSubmit() {
    const loginData = {
      username: this.username.value,
      password: this.password.value
    }
    console.log('Form Submitted', loginData);
    console.log('Form Submitted');
    console.log('Username:', this.username.value);
    console.log('Password:', this.password.value);
  }

}
