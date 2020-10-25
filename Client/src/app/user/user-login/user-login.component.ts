import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {

  constructor(private authService : AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  onLogin(loginForm : NgForm){
    const token = this.authService.authUser(loginForm.value);
    if (token){
      localStorage.setItem('token', token.userName);
      this.alertify.success("Login successful!");
    }else{
      this.alertify.error("Login failed!");
    }
  }

}
