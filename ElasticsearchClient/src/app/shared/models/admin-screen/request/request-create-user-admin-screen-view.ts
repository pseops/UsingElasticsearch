import { UserRole } from 'src/app/shared/enums';

export class RequestCreateUserAdminScreenView {
  userName: string;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  status: boolean;
  role: UserRole;
}
