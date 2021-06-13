export interface User {
  id: string;
  userName: string;
  email: string;
  emailConfirmed: boolean;
}

export interface UserForCreate {
  userName: string;
  email: string;
  password: string;
}

export interface UserForUpdate {
  id: string;
  userName?: string;
  email?: string;
  password?: string;
  emailConfirmed: boolean;
}
