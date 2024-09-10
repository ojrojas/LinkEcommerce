import { Injectable, isDevMode } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  grpcClient!: Request
  constructor() { }

  getBasket(customerid: string) {
  }
}
