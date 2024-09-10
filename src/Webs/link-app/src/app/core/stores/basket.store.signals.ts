import { patchState, signalStore, withMethods, withState } from "@ngrx/signals";
import { PaginatedItems } from "../dtos/paginationResponse.dto"
import { CatalogItem } from "../models/catalogitem.model"
import { setPending, withRequestStatus } from "./state.request.features";
import { BasketServicesService } from "../services/basket.service";
import { inject } from "@angular/core";


type BasketECommerceState ={
  catalogItems: PaginatedItems<CatalogItem[]> | undefined;
  pendingCheckout: boolean;
}


const initialState: BasketECommerceState = {
  catalogItems: undefined,
  pendingCheckout: false
}

export const BasketECommerceStore = signalStore(
  {providedIn:'root'},
  withState(initialState),
  withRequestStatus(),
  withMethods((store, basketService = inject(BasketServicesService))=>({
    addtoCart(catalogItem: CatalogItem){
        patchState(store, setPending());
        basketService
    }
  })));
