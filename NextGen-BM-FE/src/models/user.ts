export interface User {
  userId: number;
  firstName: string;
  lastName: string;
  role: string;
  properties: UserProperties[];
  email: string;
}

export interface UserProperties {
  propertyId: number;
  role: string;
  startDate: Date;
  endDate: Date;
}

export interface AuthToken {
  tokenType: string;
  accessToken: string;
  expiresIn: number;
  refreshToken: string;
}

export interface LoginModel {
  email: string;
  password: string;
}

export interface GoogleLoginModel {
  access_token: string;
  expires_is: number;
  id_token: string;
  refresh_token: string;
  scope: string;
  token_type: string;
}
