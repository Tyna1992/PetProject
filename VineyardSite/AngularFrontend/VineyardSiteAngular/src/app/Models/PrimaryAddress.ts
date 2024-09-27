import { IUser } from "./User";


export interface IPrimaryAddress {
    PrimaryAddressId: number,
    Street: string,
    HouseNumber: string,
    ZipCode: string,
    City: string,
    Country: string,
    User: IUser,
    UserId: string,
}
