import { ICart } from "./Cart";
import { IWineVariant } from "./WineVariant";

export interface ICartItem {
    Id: number,
    CartId: number,
    Cart: ICart,
    WineVariantId: number,
    WineVersion: IWineVariant,
    Quantity: number
}
