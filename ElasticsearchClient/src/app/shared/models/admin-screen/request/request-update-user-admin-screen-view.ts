import { UserRole } from 'src/app/shared/enums';
import { UsersPermissionsModel } from '../..';

export class RequestUpdateUserAdminScreenView {
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
