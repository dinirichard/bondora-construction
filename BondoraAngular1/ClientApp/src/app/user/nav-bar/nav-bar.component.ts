import { Component, OnInit } from '@angular/core';
import { ApiOrderService } from '../../shared/api-order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private orderService: ApiOrderService,
    private router: Router) { }

  ngOnInit() {
    this.isAuthenticated();
  }

  isAuthenticated() {
    return this.orderService.isAuthenticated();
  }

  logout() {
    this.orderService.logout();
    this.router.navigate(['']);
  }

}
