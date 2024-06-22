import { Component, OnInit } from '@angular/core';
import { CarModelService } from '../services/car-model.service'; // Ensure this path is correct based on your folder structure
import { CarModel } from '../models/car-model.model'; // Ensure this path is correct based on your folder structure

@Component({
  selector: 'app-car-models',
  templateUrl: './car-models.component.html',
  styleUrls: ['./car-models.component.css']
})
export class CarModelsComponent implements OnInit {
  carModels: CarModel[];

  constructor(private carModelService: CarModelService) { }

  ngOnInit(): void {
    this.getCarModels();
  }

  getCarModels(): void {
    this.carModelService.getAllCarModels().subscribe(carModels => {
      this.carModels = carModels;
    });
  }

  calculateCommissions(): void {
    this.carModelService.calculateCommissions().subscribe(() => {
      console.log('Commissions calculated successfully');
    });
  }
}
