import { IWineVariant } from "./WineVariant";


export interface IInventoryItem {
    Id: number,
    WineVariantId: number,
    WineVersion: IWineVariant,
    Quantity: number
}