import { BaseEntity } from "./baseentity.model";

export interface Card extends BaseEntity {
  number: string;
  expirationDate: Date;
  cardType: CardType;
}

export interface CardType extends BaseEntity {
  name: string;
}

export interface IdentificationType extends BaseEntity {
  name: string;
}

export interface UserViewModel {
  id: string;
  name: string;
  middleName: string;
  lastName: string;
  surName: string;
  identificationType: IdentificationType;
  identificationTypeId: string;
  identificationNumber: string;
  birthDate: Date;
  address: string;
  contact: string;
  card: Card;
  cardId: string;
}
