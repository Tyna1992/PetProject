import { ICartItem } from "./CartItem";
import { IUser } from "./User";


export interface ICart {
    CartId: number,
    CartItems: ICartItem[],
    UserId: string,
    User: IUser
}
