import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IWineVariant } from '../../Models/WineVariant';


@Injectable({
  providedIn: 'root'
})
export class WineVariantFormService {

  constructor(private http: HttpClient) { }
  
  addWineVariant(wineVariantData: IWineVariant): Observable<IWineVariant> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<IWineVariant>(`/api/Variant/AddWineVariant/${wineVariantData.Wine.Name}/${wineVariantData.Price}/${wineVariantData.AlcoholContent}/${wineVariantData.Year}`, null, {headers})
  }
}
