import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { WineFormService } from './wine-form.service';
@Component({
  selector: 'app-admin-wine-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './wineForm.component.html',
  styleUrl: './wineForm.component.css',
})
export class WineFormComponent implements OnInit {
  wineForm!: FormGroup;

  constructor(private fb: FormBuilder , private wineFormService: WineFormService) {}

  ngOnInit(): void {
    this.wineForm = this.fb.group({
      Name: ['', Validators.required],        
      Type: ['', Validators.required],        
      Sweetness: ['', Validators.required],   
      Description: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.wineForm.valid) {
      this.wineFormService.addWine(this.wineForm.value).subscribe(
        (response) => {
          console.log(this.wineForm.value);
          console.log("Wine is successfully added");
          alert("Wine is successfully added");
        },
        (error) => {
          console.error(error);
        }
      )
    }
  }
}
