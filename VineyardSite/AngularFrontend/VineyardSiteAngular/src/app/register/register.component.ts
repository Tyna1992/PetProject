import { Component } from '@angular/core';
import { FormControl,ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  username = new FormControl('');
  email = new FormControl('');
  password = new FormControl('');

  onSubmit() {
    const loginData = {
      username: this.username.value,
      email: this.email.value,
      password: this.password.value
    }
    console.log('Form Submitted', loginData);
  }
}
