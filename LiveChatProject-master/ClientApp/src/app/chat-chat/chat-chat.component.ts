import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageObj } from '../models/message-obj.model';

export class Message {
  public content: string;
  public author: string;
}

@Component({
  selector: 'app-chat-chat',
  templateUrl: './chat-chat.component.html',
  styleUrls: ['./chat-chat.component.css']
})
export class ChatChatComponent implements OnInit {

  messageObject = new MessageObj();
  public resultOfSendingChatMessage: string;

  firstName: string;
  lastName: string;

  backendResponse: string;

  message: string;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get("https://localhost:44359/" + "account" + "/getCurrentUser").subscribe(response => {
      this.firstName = (response as any).firstName;
      this.lastName = (response as any).lastName;
    },
      error => { });
  }

  sendMessageToBackend() {
    var message = new Message();
    message.content = this.message;
    message.author = this.firstName + " " + this.lastName;

    this.http.post("https://localhost:44359/" + "kurs" + "/sendMessage", message).subscribe(response => {
      this.backendResponse = (response as any).content;
    },
      error => {
        this.backendResponse = error;
      }
    )
  }

}
