import { Component, OnInit } from '@angular/core';
import { CarModelService } from '../../services/car-model.service'; // Adjust the path as needed
import { CarModel } from '../../models/car-model.model'; // Adjust the path as needed

@Component({
  selector: 'app-car-models',
  templateUrl: './car-models.component.html',
  styleUrls: ['./car-models.component.css']
})
export class CarModelsComponent implements OnInit {
  carModels: CarModel[] = [];

  constructor(private carModelService: CarModelService) { }

  ngOnInit(): void {
    this.carModelService.getAllCarModels().subscribe(data => {
      this.carModels = data;
    });
  }

  calculateCommissions(): void {
    this.carModelService.calculateCommissions().subscribe(() => {
      alert('Commissions calculated successfully!');
    });
  }
}
