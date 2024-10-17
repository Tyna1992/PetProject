import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileDataComponent } from './profile-data/profile-data.component';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, ProfileDataComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

}
