import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
// import { JwtHelperService } from '@auth0/angular-jwt';
// import decode from 'jwt-decode';


import { Inventory, Product } from '../models/Inventory';
import { User } from '../models/user';
import { Invoice } from '../models/invoice';
import { isNull } from 'util';

@Injectable({
  providedIn: 'root'
})
export class ApiOrderService {
  private BASE_URL = "https://localhost:5001/api";
  public GET_INVENTORY_URL = `${this.BASE_URL}\\inventory`;
  public INVOICE_URL = `${this.BASE_URL}\\reciept`;
  public GET_INVOICE_URL = `${this.BASE_URL}\\reciept\\`;
  private LOGIN_URL = "https://localhost:5001/api/user/";

  constructor(private http: HttpClient,
    private router: Router) { }

  getInventory(): Observable<Inventory[]> {
    return this.http.get<Inventory[]>(this.GET_INVENTORY_URL);
  }

  login(user: User) {

    return this.http.post(this.LOGIN_URL, user);

  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['']);
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    // return !this.jwtHelper.isTokenExpired(token);
    return !isNull(token);
  }

  getUserProfile() {
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get(this.LOGIN_URL, { headers: tokenHeader });
    // return this.http.get(this.LOGIN_URL);
  }

  postReceipt(invoice: Invoice) {
    localStorage.setItem('recieptID', invoice.id.toString());
    return this.http.post(this.INVOICE_URL + "/post", invoice);
  }

  getReceipt(invoiceID: number) {
    return this.http.get(this.GET_INVOICE_URL + invoiceID);
  }


}
