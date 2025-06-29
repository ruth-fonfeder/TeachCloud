export interface RegisterDto {
    fullName: string;
    email: string;
    password: string;
    role: number;
    userType: string;
  }
  
  export interface LoginDto {
    email: string;
    password: string;
  }
  