import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderComponent } from './order/order.component';
import { LogInComponent } from './user/log-in/log-in.component';
import { AuthGuard } from './auth/auth.guard';
import { OrderRecieptComponent } from './order/order-reciept/order-reciept.component';

const routes: Routes = [
  {
    path: "",
    component: LogInComponent,
    pathMatch: "full"
  }
  ,
  {
    path: "new-order",
    component: OrderComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "order-reciept",
    component: OrderRecieptComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
