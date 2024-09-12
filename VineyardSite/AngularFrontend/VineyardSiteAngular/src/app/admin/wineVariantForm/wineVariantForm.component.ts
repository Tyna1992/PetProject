import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { IWine } from '../../Models/Wine';
import { IWineVariant } from '../../Models/WineVariant';
import { WineFormService } from '../wineForm/wine-form.service';
import { WineVariantFormService } from './wine-variant-form.service';
@Component({
  selector: 'app-admin-wineVariant-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './wineVariantForm.component.html',
  styleUrl: './wineVariantForm.component.css',
})
export class WineVariantFormComponent implements OnInit {
  wineVariantForm!: FormGroup;
  wineName: IWine[] = [];

  constructor(
    private fb: FormBuilder,
    private wineFormService: WineFormService,
    private wineVariantFormService: WineVariantFormService
  ) {}

  ngOnInit(): void {
    this.wineVariantForm = this.fb.group({
      Name: ['', Validators.required],
      Price: [null, [Validators.required, Validators.min(0)]],
      Alcohol: [null, [Validators.required, Validators.min(0)]],
      Year: [
        null,
        [
          Validators.required,
          Validators.min(1900),
          Validators.max(new Date().getFullYear()),
        ],
      ],
    });

    this.wineFormService.getAllWines().subscribe(
      (response: any[]) => {
        this.wineName = response.map((wine) => ({
          Id: wine.id,
          Name: wine.name,
          Type: wine.type,
          Sweetness: wine.sweetness,
          Description: wine.description,
        }));
        console.log('Wines fetched:', this.wineName);
      },
      (error) => {
        console.error('Error fetching wines:', error);
      }
    );
  }

  onSubmit() {
    if (this.wineVariantForm.valid) {
      const selectedWineId = this.wineVariantForm.value.Name;
      const selectedWine = this.wineName.find((wine) => wine.Id == selectedWineId);
      console.log(typeof(selectedWineId))

      if (!selectedWine) {
        console.error('Selected wine is not found');
        alert('Selected wine is not found');
        return; 
      }

      const wineVariantData: IWineVariant = {
        Id: 0, 
        Wine: selectedWine, 
        WineId: selectedWine.Id,
        Price: this.wineVariantForm.get('Price')?.value,
        AlcoholContent: this.wineVariantForm.get('Alcohol')?.value,
        Year: this.wineVariantForm.get('Year')?.value
      };

      this.wineVariantFormService
        .addWineVariant(wineVariantData)
        .subscribe(
          (response) => {
            alert('Wine vintage is successfully added');
          },
          (error) => {
            console.error(error);
          }
        );
    }
  }
}
