import { UserRole } from '../../enums';

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
}
