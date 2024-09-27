import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WebshopWineCardComponent } from './webshop-wine-card/webshop-wine-card.component';
import { InventoryService } from '../admin/inventory/inventory-service.service';
import { IInventoryStock } from '../Models/InventoryStock';

@Component({
  selector: 'app-webshop',
  standalone: true,
  imports: [CommonModule, WebshopWineCardComponent],
  templateUrl: './webshop.component.html',
  styleUrl: './webshop.component.css'
})
export class WebshopComponent implements OnInit {
  inventory: IInventoryStock[] = [];
  constructor(private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.inventoryService.getInventory().subscribe(
      (data: any[]) => {
        this.inventory = data.map(item => ({
          DrinkId: item.drinkId,
          Name: item.name,
          Year: item.year,
          Price: item.price,
          AlcoholContent: item.alcoholContent,
          Quantity: item.quantity,
          Description: item.description
        }));
        console.log('Fetched inventory:', this.inventory);
      },
      (error) => {
        console.error('Error fetching inventory:', error);
      }
    );
  }
}
