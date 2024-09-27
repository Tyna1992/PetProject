import { IAddress } from "./Address";
import { ICart } from "./Cart";
import { IOrder } from "./Order";
import { IPrimaryAddress } from "./PrimaryAddress";


export interface IUser {
    PrimaryAddressId: number,
    AddressId: number,
    Cart: ICart,
    CartId: number,
    Orders: IOrder[],
    PrimaryAddress: IPrimaryAddress,
    Addresses: IAddress[]
}
