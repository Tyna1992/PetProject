import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { AuthService } from './login/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, ReactiveFormsModule, CommonModule],
  templateUrl: './navbar/navbar.component.html',
  styleUrl: './navbar/navbar.component.css'
})
export class AppComponent {
  title = 'VineyardSiteAngular';
  isLoggedIn$: Observable<boolean>;

  constructor(private authService: AuthService) {
    this.isLoggedIn$ = this.authService.isLoggedIn$();
  }
}
