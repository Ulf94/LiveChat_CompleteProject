import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginDto } from '../models/user-login-dto.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLoginDto = new UserLoginDto();
  public loggedUser: string;
  public result: string;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  sendRequestToBackend() {

    this.http.post("https://localhost:44359/" + "account" + "/login", this.userLoginDto).subscribe(response => {
      this.router.navigate(['/test'])
      this.result = "Login successfully!";
    },
      error => {

        this.result = "Failed to login!";
      }
    )
  }

}
