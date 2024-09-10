import { patchState, signalStore, withMethods, withState } from '@ngrx/signals'
import { UserViewModel } from '../models/userapplication.model';
import { Token } from '../dtos/token.response.dto';
import { inject } from '@angular/core';
import { IdentityService } from '../services/identity-services.service';
import { CatalogService } from '../services/catalog-services.service';
import { setFulfilled, setPending, withRequestStatus } from './state.request.features';

type IdentityECommerceState =
  {
    user: UserViewModel | undefined;
    token: Token | undefined;
    isLogged: boolean;

  };

const initialState: IdentityECommerceState = {
  user: undefined,
  token: undefined,
  isLogged: false
};

export const IdentityECommerceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withRequestStatus(),
  withMethods((store, identityService = inject(IdentityService), catalogService = inject(CatalogService)) => ({
    setToken(token: Token) {
      patchState(store, setPending());
      patchState(store, { token: token }, setFulfilled());
    },
    loginApp() {
      patchState(store, setPending());
      identityService.signIn("authorize", "implicit").subscribe(
        result => {
          if (result != undefined && result.url != undefined)
            console.log("REsult http", result);
          patchState(store, setFulfilled());
          window.location.href = result.url!;
        }
      );
    },
    logoutApp() {
      patchState(store, setPending());
      identityService.logout();
      patchState(store, initialState, setFulfilled());
    },
    getUserInfo(token: string) {
      identityService.getInfoUser(token).subscribe(result => {
        const response = result.body as { user: UserViewModel, correlationid: string }
        patchState(store, { user: response.user, isLogged: true });
      });
    }
  }))
);
