import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IInventoryItem } from '../../Models/InventoryItem';
import { InventoryService } from '../inventory/inventory-service.service';
import { IInventoryStock } from '../../Models/InventoryStock';

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [ CommonModule ],
  templateUrl: './inventory-table.component.html',
  styleUrls: ['./inventory-table.component.css']
})
export class InventoryTableComponent implements OnInit {
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
