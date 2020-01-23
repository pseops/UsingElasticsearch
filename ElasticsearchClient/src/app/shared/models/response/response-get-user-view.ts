import { UserRole } from '../../enums';
import { UsersPermissionsModel } from '..';

export class ResponseGetUserView {
  items: ResponseGetUserItemView[];
  constructor() {
    this.items = new Array<ResponseGetUserItemView>();
  }
}

export class ResponseGetUserItemView {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    status: boolean;
    role: UserRole;
    permissions: UsersPermissionsModel[];
}
