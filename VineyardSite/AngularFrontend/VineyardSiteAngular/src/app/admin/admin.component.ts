import { Component } from '@angular/core';
import { WineFormComponent } from './wineForm/wineForm.component';
import { WineVariantFormComponent } from './wineVariantForm/wineVariantForm.component';
import { InventoryFormComponent } from './inventory/inventory-form/inventory-form.component';
import { InventoryDetailsFormComponent } from './inventory/inventory-details-form/inventory-details-form.component';
import { InventoryTableComponent } from './inventory-table/inventory-table.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule ,WineFormComponent, WineVariantFormComponent, InventoryFormComponent, InventoryDetailsFormComponent, InventoryTableComponent],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  selectedComponent: string = '';

  showComponent(component: string) {
    if (this.selectedComponent === component) {
      this.selectedComponent = '';
    } else {
      this.selectedComponent = component;
    }
  }
}
