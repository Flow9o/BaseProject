import {inject, Injectable} from '@angular/core';
import {Car, CarGeneratedService} from '@api/baseproject';

@Injectable()
export class CarService {
  private readonly carService = inject(CarGeneratedService);

  createCar(carToCreate : Car) {
   return this.carService.createCar(carToCreate);
  }
}
