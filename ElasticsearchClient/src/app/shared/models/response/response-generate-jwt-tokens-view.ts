import { Page } from '../../enums';

export class ResponseGenerateJwtTokensView {
  accessToken: string;
  refreshToken: string;
  firstName: string;
  lastName: string;
  email: string;
  role: string;
  permissions: Array<UsersPermissionsModel>;
}

export class UsersPermissionsModel {
  id: number;
  canEdit: boolean;
  canView: boolean;
  userId: string;
  page: Page;
}
