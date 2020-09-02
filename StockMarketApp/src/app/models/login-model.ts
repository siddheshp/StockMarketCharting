export class LoginModel {
    Token: string;
    UserType: UserType
};

export enum UserType {
    Admin = 1,
    User
}