import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import *as signalR from '@aspnet/signalr';

export class Message {
  public content: string;
  public firstName: string;
  public lastName: string;
}

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  backendResponse: string;

  firstName: string;
  lastName: string;

  message: string;
  messages: Array<Message>;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get("https://localhost:44359/" + "account" + "/getCurrentUser").subscribe(response => {
      this.firstName = (response as any).firstName;
      this.lastName = (response as any).lastName;

      this.refreshMessages();

      var connection = new signalR.HubConnectionBuilder().
        configureLogging(signalR.LogLevel.Information).
        withUrl("https://localhost:44359/message").
        build();

      connection.start();

      connection.on("NewMessage", () => {
        this.refreshMessages();

      })
    },
      error => { });
  }

  refreshMessages() {
    var message = new Message();
    message.content = this.message;
    //message.firstName = "TenSamAUtor";
    //message.author = this.firstName + " " + this.lastName;

    this.http.get<Array<Message>>("https://localhost:44359/" + "kurs" + "/getMessages").subscribe(response => {
      this.messages = response;
    },
      error => {
        this.backendResponse = error;
      }
    )
  }

  sendRequestToBackend() {
  var message = new Message();
    message.content = this.message;
    message.firstName = this.firstName;
    message.lastName = this.lastName;

  this.http.post<Message>("https://localhost:44359/" + "kurs" + "/sendMessage", message).subscribe(response => {
    this.backendResponse = response.content;
    this.message = "";
    },
      error => {
        this.backendResponse = error;
      }
    )
  }

}
