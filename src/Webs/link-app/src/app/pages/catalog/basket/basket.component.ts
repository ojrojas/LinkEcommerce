import { Component } from '@angular/core';
import { CardBasketComponent } from "../../../components/card-basket/card-basket.component";

@Component({
  selector: 'app-basket',
  standalone: true,
  imports: [CardBasketComponent],
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.scss'
})
export class BasketComponent {

}
