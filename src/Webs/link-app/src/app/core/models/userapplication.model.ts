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
  Name: string;
  MiddleName: string;
  LastName: string;
  SurName: string;
  identificationType: IdentificationType;
  IdentificationTypeId: string;
  IdentificationNumber: string;
  BirthDate: Date;
  address: string;
  contact: string;
  card: Card;
  cardId: string;
}
