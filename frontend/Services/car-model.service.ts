import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarModel } from '../models/car-model.model'; 

@Injectable({
    providedIn: 'root'
})
export class CarModelService {
    private apiUrl = 'http://localhost:5000/api/carmodels'; 

    constructor(private http: HttpClient) { }

    getAllCarModels(): Observable<CarModel[]> {
        return this.http.get<CarModel[]>(this.apiUrl);
    }

    getCarModelById(id: number): Observable<CarModel> {
        return this.http.get<CarModel>(`${this.apiUrl}/${id}`);
    }

    addCarModel(carModel: CarModel): Observable<void> {
        return this.http.post<void>(this.apiUrl, carModel);
    }

    updateCarModel(id: number, carModel: CarModel): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${id}`, carModel);
    }

    deleteCarModel(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }

    calculateCommissions(): Observable<void> {
        return this.http.post<void>(`${this.apiUrl}/calculate-commissions`, {});
    }
}
