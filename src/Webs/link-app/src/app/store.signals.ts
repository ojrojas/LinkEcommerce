import { patchState, signalStore, withMethods, withState } from '@ngrx/signals'
import { BasketCatalogItem } from './core/models/basketcatalogitem.model'
import { CatalogItem } from './core/models/catalogitem.model';
import { UserViewModel } from './core/models/userapplication.model';
import { Token } from './core/dtos/token.response.dto';
import { inject } from '@angular/core';
import { IdentityService } from './core/services/identity-services.service';

type ECommerceState =
  {
    basket: BasketCatalogItem[];
    catalogItems: CatalogItem[];
    isLoading: boolean;
    user: UserViewModel | undefined;
    token: Token | undefined;
  };

const initialState: ECommerceState = {
  basket: [],
  catalogItems: [],
  isLoading: false,
  user: undefined,
  token: undefined
};

export const ECommerceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, identityService = inject(IdentityService)) => ({
    setToken(token: Token){
      patchState(store, { token: token });
    },
    loginApp() {
      identityService.signIn("authorize", "implicit").subscribe(
        result => {
          if (result != undefined && result.url != undefined)
            console.log("REsult http", result);
            window.location.href = result.url!;
        }
      );
    },
    logoutApp(){
      identityService.logout();
    },
    getUserInfo(token:string){
      identityService.getInfoUser(token).subscribe(result => {
        const response = result.body as {user: UserViewModel, correlationid: string}
        patchState(store, {user: response.user});
      });
    }
  }))
);
