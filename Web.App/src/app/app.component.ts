import { Component, OnInit } from '@angular/core';
import { AuthService, User } from './auth.service';
import { TestApiService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(public auth: AuthService, public apiService: TestApiService) {
  }

  messages: string[] = [];
  get currentUserJson() : string {
    return JSON.stringify(this.currentUser, null, 2);
  }
  currentUser : User;

  ngOnInit(): void {
    this.auth.getUser().then(user => {
      this.currentUser = user;

      if (user){
        this.addMessage("User Logged In");
      }
      else {
        this.addMessage("User Not Logged In");
      }
    }).catch(err => this.addError(err));
  }

  clearMessages() {
    while (this.messages.length) {
      this.messages.pop();
    }
  }
  addMessage(msg: string) {
    this.messages.push(msg);
  }
  addError(msg: string | any) {
    this.messages.push("Error: " + msg && msg.message);
  }

  public onLogin() {
    this.auth.login().catch(err => {
      this.addError(err);
    });
  }

  public onCallAPI() {
    this.apiService.callApi().then(result => {
      this.addMessage("API Result: " + JSON.stringify(result));
    }, err => this.addError(err));
  }

  public onRenewToken() {
    this.auth.renewToken()
      .then(user=>{
        this.currentUser = user;
        this.addMessage("Silent Renew Success");
      })
      .catch(err => this.addError(err));
  }
}
