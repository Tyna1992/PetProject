import { IOrder } from "./Order";
import { IWineVariant } from "./WineVariant";

export interface IOrderItem {
    Id: string,
    WineVariant: IWineVariant,
    WineVariantId: number,
    Quantity: number,
    Order: IOrder,
    OrderId: string
}
