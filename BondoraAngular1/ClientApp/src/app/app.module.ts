import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { MaterialModule } from "./material/material.module";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderComponent } from './order/order.component';


import { MatNativeDateModule } from '@angular/material';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LogInComponent } from './user/log-in/log-in.component';
import { NavBarComponent } from './user/nav-bar/nav-bar.component';
import { ApiOrderService } from './shared/api-order.service';
import { AuthInterceptor } from './auth/auth.interceptor';
import { OrderRecieptComponent } from './order/order-reciept/order-reciept.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderComponent,
    LogInComponent,
    NavBarComponent,
    OrderRecieptComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatNativeDateModule
  ],
  providers: [
    // ApiOrderService, {
    // provide: HTTP_INTERCEPTORS,
    // useClass: AuthInterceptor,
    //   multi: true
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
