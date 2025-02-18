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
