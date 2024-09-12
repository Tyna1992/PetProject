import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IWine } from '../../Models/Wine';
@Injectable({
  providedIn: 'root'
})
export class WineFormService {

  constructor(private http: HttpClient) { }

  addWine(wineData: IWine): Observable<IWine> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<IWine>('/api/Wine/addWine', wineData, {headers});
  }

  getAllWines(): Observable<IWine[]> {
    return this.http.get<IWine[]>('/api/Wine/GetAllWine');
  }
}
