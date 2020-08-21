export interface IAccount {
  id: number;
  accountNo?: string;
  clientId?: number;
  name?: string;
  balance?: number;
  accountTypeId?: number;
  isMain?: boolean; //One client can have multiple account
  firstName?: string;
  middleName?: string;
  lastName?: string;
  phone?: string;
  email?: string;
  address1?: string;
  address2?: string;
  state?: string;
  zipCode?: string;
  relationshipId?: string; //Relationship with main account
  sortId?: number;
  isActive?: boolean;
}

export interface IAccountToSave {
  accountNo?: string;
  clientId?: number;
  name?: string;
  balance?: number;
  accountTypeId?: number;
  isMain?: boolean; //One client can have multiple account
  firstName?: string;
  middleName?: string;
  lastName?: string;
  phone?: string;
  email?: string;
  address1?: string;
  address2?: string;
  state?: string;
  zipCode?: string;
  relationshipId?: string; //Relationship with main account
  sortId?: number;
  isActive?: boolean;
}
