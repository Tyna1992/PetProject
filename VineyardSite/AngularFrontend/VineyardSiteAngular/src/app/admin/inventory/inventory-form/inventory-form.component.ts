import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators  } from '@angular/forms';
import { InventoryService } from '../inventory-service.service';
import { CommonModule } from '@angular/common';
import { WineFormService } from '../../wineForm/wine-form.service';
import { IWine } from '../../../Models/Wine';

@Component({
  selector: 'app-inventory-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './inventory-form.component.html',
  styleUrl: './inventory-form.component.css'
})
export class InventoryFormComponent implements OnInit {
  inventoryForm!: FormGroup;
  wineName: IWine[] = [];

  constructor(private fb: FormBuilder, private inventoryService: InventoryService, private wineService: WineFormService) {}

  ngOnInit(): void {
    this.inventoryForm = this.fb.group({
      Name: ['', Validators.required],
    });

    this.wineService.getAllWines().subscribe((data: any[]) => {
      this.wineName = data;
    });

    this.wineService.getAllWines().subscribe(
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

  onSelectWine(): void {
    if (this.inventoryForm.valid) {
      const selectedWineId = parseInt(this.inventoryForm.value.Name);
      console.log(selectedWineId)
      this.inventoryService.getVintageByWineId(selectedWineId);
    }
  }
}