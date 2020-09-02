import { UserType, LoginModel } from './../../models/login-model';
import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;
  constructor(private authService: AuthService) { }

  ngOnInit(): void {

  }

  submit(): void {
    console.log(this.username);
    console.log(this.password);
    // call service method, pass params
    this.authService.login(this.username, this.password).subscribe(result => {
      //1. store token and user in localstorage
      localStorage.setItem('token', result["token"]);
      localStorage.setItem('role', result["userType"]);
      //2. navigate to admin/user
      alert('login successful');
    }, err => {
      console.log(err);
      alert(err);
    });
  }
}