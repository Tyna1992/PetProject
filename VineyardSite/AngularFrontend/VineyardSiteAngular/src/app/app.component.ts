import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, ReactiveFormsModule],
  templateUrl: './navbar/navbar.component.html',
  styleUrl: './navbar/navbar.component.css'
})
export class AppComponent {
  title = 'VineyardSiteAngular';
}
