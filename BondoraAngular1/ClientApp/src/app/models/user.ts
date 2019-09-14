export interface User {
    id: number;
    FirstName: string;
    LastName: string;
    Address: string;
    Email: string;
    Password: string;
}

export class User {
    constructor(
        id: number,
        FirstName: string,
        LastName: string,
        Address: string,
        Email: string,
        Password: string
    ) { }
}