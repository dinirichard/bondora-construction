import { Component, OnInit } from '@angular/core';
import { ApiOrderService } from '../../shared/api-order.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../models/user';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  loginForm: FormGroup;
  returnUrl: string;
  submitted = false;
  user: User = { id: 0, Email: "", Password: "", Address: "", FirstName: "", LastName: "" }

  constructor(private orderService: ApiOrderService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  get f() { return this.loginForm.controls; }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    if (localStorage.getItem('token') != null) {
      this.router.navigateByUrl('/new-order');
    }
  }


  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }

    console.log(this.f.username.value);
    console.log(this.f.password.value);

    this.user.Email = this.f.username.value;
    this.user.Password = this.f.password.value;

    console.log(this.user);

    this.orderService.login(this.user)
      .pipe(first())
      .subscribe(
        (res: any) => {
          console.log(res);
          localStorage.setItem('token', res.token);
          this.router.navigate(['/new-order']);
        },
        error => {
          if (error.status === 400) {
            window.location.reload();
          }
        });
  }
}
