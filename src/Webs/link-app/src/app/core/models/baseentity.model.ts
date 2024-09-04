export interface BaseEntity
{
  id:string;
  createdBy: string;
  createdDate: Date;
  modifiedBy: string;
  modifiedDate: Date;
  state:boolean;
}
