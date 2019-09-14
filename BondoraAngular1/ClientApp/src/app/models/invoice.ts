import { Product } from './Inventory';

export interface Invoice {
    id: number;
    TotalPrice: number;
    BonusPoints: number;
    PurchaseDate: number;
    UserId: number;
    Inventories: Product[];
}