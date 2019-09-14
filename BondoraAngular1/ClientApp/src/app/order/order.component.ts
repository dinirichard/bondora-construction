import { Component, OnInit } from '@angular/core';
import { ApiOrderService } from '../shared/api-order.service';
import { Inventory, Product } from '../models/Inventory';
import { ErrorStateMatcher } from '@angular/material/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { forEach } from '@angular/router/src/utils/collection';
import { User } from '../models/user';
import { Invoice } from '../models/invoice';
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from "@angular/material";
import { OrderRecieptComponent } from './order-reciept/order-reciept.component';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})

export class OrderComponent implements OnInit {
  inventories: Inventory[] = [];
  selectedProducts: Product[] = [];

  selectProduct: Product = { id: 0, name: "", type: "", rentDays: 0, cost: 0 }
  userDetails: User;

  receipt: Invoice = { id: 0, TotalPrice: 0, BonusPoints: 0, PurchaseDate: 0, UserId: 0, Inventories: null }

  formCheck = 0;
  formCheckbool = false;

  // private onModelChange: any;

  matcher = new MyErrorStateMatcher();

  constructor(private orderService: ApiOrderService,
    private router: Router,
    private dialog: MatDialog) { }


  ngOnInit() {
    this.getInventory();
    this.formBool();

    this.orderService.getUserProfile().subscribe(
      (res: User) => {
        this.userDetails = res;
        console.log(this.userDetails);
      },
      error => {
        console.log(error);
      }
    );
  }

  public getInventory() {
    this.orderService.getInventory().subscribe(
      res => {
        this.inventories = res;
        this.inventories.forEach((nos) => { // foreach statement  
          nos.selected = false;
        });
      },
      error => {
        alert("An error has occured while getting notes");
      }
    );

  }

  updateTopping(product: Inventory) {
    if (product.selected) {
      product.selected = false;
      this.formCheck = this.formCheck - 1;
    } else {
      product.selected = true;
      this.formCheck = this.formCheck + 1;
    }
    this.formBool();
  }

  formBool() {
    if (this.formCheck > 0) {
      this.formCheckbool = true;
    } else {
      this.formCheckbool = false;
    }
  }

  openDialog() {
  }

  onSubmit() {
    console.log("Selected Inventories: ", this.selectedProducts);

    this.inventories.forEach((nos) => { // foreach statement  
      if (nos.selected) {

        this.selectProduct.id = nos.id;
        this.selectProduct.name = nos.name;
        this.selectProduct.type = nos.type;
        this.selectProduct.rentDays = nos.rentDays;

        this.selectedProducts.push(new Product(nos.id, nos.name, nos.type, nos.rentDays, nos.cost));


      }
    });

    console.log("Final Inventories: ", this.selectedProducts);



    this.receipt.id = Math.floor(100000 + Math.random() * 900000);
    this.receipt.UserId = this.userDetails.id;
    this.receipt.Inventories = this.selectedProducts;

    this.orderService.postReceipt(this.receipt).subscribe(
      (res: Invoice) => {
        console.log("Reciept data : ", res);
        console.log("Reciept data.valueOf() : ", res.valueOf());
        this.receipt = res;

        // Begin Dialog Control

        const dialogConfig = new MatDialogConfig();

        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;

        dialogConfig.position = {
          top: '0px',
          left: '0px'
        }

        dialogConfig.width = '900px';

        dialogConfig.data = {
          reciept: this.receipt
        };

        this.dialog.open(OrderRecieptComponent, dialogConfig);

        // const dialogRef = this.dialog.open(OrderRecieptComponent, dialogConfig);

        // dialogRef.afterClosed().subscribe(
        //   (data: Invoice) => console.log("Dialog data:", data)
        // );

        // End Dialog Control

      },
      err => {
        console.log(err);
      }
    )

    console.log("After post: ", this.receipt);



  }

}
