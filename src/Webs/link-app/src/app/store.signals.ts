import { patchState, signalStore, withMethods, withState } from '@ngrx/signals'
import { BasketCatalogItem } from './core/models/basketcatalogitem.model'
import { CatalogItem } from './core/models/catalogitem.model';
import { UserViewModel } from './core/models/userapplication.model';
import { Token } from './core/dtos/token.response.dto';

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
  withMethods((store) => ({
    getAllProducts(): void {
    }
  }))
);
