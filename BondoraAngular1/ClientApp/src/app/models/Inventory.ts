export interface Inventory {
    id: number;
    name: string;
    type: string;
    rentDays: number;
    cost: number;
    selected: boolean;
}

export class Product {
    public id: number;
    public name: string;
    public type: string;
    public rentDays: number;
    public cost: number;
    constructor(id: number, name: string, type: string, rentDays: number, cost: number) {
        this.id = id;
        this.name = name;
        this.type = type;
        this.rentDays = rentDays;
        this.cost = cost;
    }

}

