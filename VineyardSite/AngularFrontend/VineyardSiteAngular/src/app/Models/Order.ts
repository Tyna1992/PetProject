import { IOrderItem } from "./OrderItem";
import { IUser } from "./User";

export interface IOrder {
    Id: string,
    OrderItems: IOrderItem[],
    TotalPrice: number,
    Date: Date,
    Address: string,
    DeliveryType: string,
    PaymentType: string,
    Status: string,
    Notes: string,
    Email: string,
    User: IUser,
    UserId: string
}
