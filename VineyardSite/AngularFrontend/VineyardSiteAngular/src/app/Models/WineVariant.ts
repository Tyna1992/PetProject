import { IWine } from "./Wine"

export interface IWineVariant  {
    Id: number,
    Wine: IWine,
    WineId: number,
    AlcoholContent: number,
    Price: number,
    Year: number
}