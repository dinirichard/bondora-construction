import { Component, OnInit, Inject } from '@angular/core';
import { ApiOrderService } from 'src/app/shared/api-order.service';
import { Invoice } from 'src/app/models/invoice';
import { Product } from 'src/app/models/Inventory';
import { MatTableDataSource, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CdkTable } from '@angular/cdk/table';

@Component({
  selector: 'app-order-reciept',
  templateUrl: './order-reciept.component.html',
  styleUrls: ['./order-reciept.component.css']
})
export class OrderRecieptComponent implements OnInit {
  panelOpenState = false;
  invoiceId: number;

  reciept: Invoice = { id: 0, TotalPrice: 0, BonusPoints: 0, PurchaseDate: 0, UserId: 0, Inventories: null }

  displayedColumns: string[] = ['Name', 'Days', 'Cost'];

  inventories: Product[] = this.reciept.Inventories;

  public dataSource = new MatTableDataSource<Product>();

  constructor(private orderService: ApiOrderService,
    private dialogRef: MatDialogRef<OrderRecieptComponent>,

    @Inject(MAT_DIALOG_DATA) data: any) {

    this.reciept = data.reciept;
    console.log("Dialog receipt : ", this.reciept);
    // this.dataSource.data = this.reciept.Inventories;
    this.dataSource.connect().next(this.reciept.Inventories);

  }

  ngOnInit() {
    // this.invoiceId = Number.parseInt(localStorage.getItem('recieptID'));
    // console.log(this.invoiceId);
    // this.orderService.getReceipt(Number.parseInt(localStorage.getItem('recieptID'))).subscribe(
    //   (res: Invoice) => {
    //     this.reciept = res;
    //   },
    //   err => {
    //     if (err == 400) {
    //       console.log(err);
    //     }
    //   }
    // )



  }

  save() {
    this.dialogRef.close();
  }



  close() {
    this.dialogRef.close();
  }

}
