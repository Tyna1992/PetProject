import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators  } from '@angular/forms';
import { InventoryService } from '../inventory-service.service';
import { CommonModule } from '@angular/common';
import { IInventoryItem } from '../../../Models/InventoryItem';
import { IWineVariant } from '../../../Models/WineVariant';

@Component({
  selector: 'app-inventory-details-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './inventory-details-form.component.html',
  styleUrl: './inventory-details-form.component.css'
})
export class InventoryDetailsFormComponent implements OnInit {
  detailsForm!: FormGroup;
  wineVintage: any[] = [];

  constructor(private fb: FormBuilder, private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.detailsForm = this.fb.group({
      Year: ['', Validators.required],
      Quantity: [null, [Validators.required, Validators.min(1)]]
    });
  
    this.inventoryService.selectedWineVintage$.subscribe((data: IWineVariant[]) => {
      this.wineVintage = data;
    });
  }

  onAddStock(): void {
    if (this.detailsForm.valid && this.wineVintage.length > 0) {
      const selectedVariant = this.getSelectedVariant();

      const inventoryItem: IInventoryItem = {
        Id: 0, 
        WineVariantId: selectedVariant.id, 
        WineVersion: selectedVariant, 
        Quantity: this.detailsForm.value.quantity
      };
      
      this.inventoryService.addStock(inventoryItem);
      alert("Wine vintage successfully added to the inventory")
    }
  }

  getSelectedVariant(): any {
    const selectedValue = this.detailsForm.value.Year.split(' ')[0];
    return this.wineVintage.find(vintage => vintage.year === parseInt(selectedValue, 10));
  }
}
