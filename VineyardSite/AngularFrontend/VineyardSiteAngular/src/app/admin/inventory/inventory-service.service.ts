import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IInventoryItem } from '../../Models/InventoryItem';
import { IWineVariant } from '../../Models/WineVariant';
import { IInventoryStock } from '../../Models/InventoryStock';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  private selectedWineVintage = new BehaviorSubject<any[]>([]);
  selectedWineVintage$ = this.selectedWineVintage.asObservable();

  constructor(private http: HttpClient) {}

  getVintageByWineId(wineId: number): void {
    this.http.get<IWineVariant[]>(`/api/Variant/GetVariants/${wineId}`).subscribe(
      (data: IWineVariant[]) => {
        this.selectedWineVintage.next(data);
      },
      (error) => {
        console.error('Error fetching wine variants:', error);
      }
    );
  }

  addStock(inventoryItem: IInventoryItem): Observable<IInventoryItem> {
    return this.http.post<IInventoryItem>(`/api/Inventory/AddInventory/${inventoryItem.WineVersion.Wine}/${inventoryItem.WineVersion.Year}/${inventoryItem.Quantity}/${inventoryItem.WineVersion.AlcoholContent}`, {});
  }

  getInventory(): Observable<IInventoryStock[]> {
    return this.http.get<IInventoryStock[]>('/api/Inventory/GetInventory');
  }
}
