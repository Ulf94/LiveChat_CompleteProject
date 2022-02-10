# Live Chat Project

This project includes all basisc CRUD processes and it's focused on backend. It allows user to register, login and start <b>live chatting</b> with other all users. 

Backend is made mainly in C# and TypeScript, frontend relays on Angular, but like I said, project is focused on backend development, so fronted looks... "heavy". 

Technologies/frameworks used in project:
- Entity Framework Core - to communicate with database, store and read all messages and to register, login and get all users,
- SignalR - to keep chat live without refreshing the page,
- AspNetCore Identity - to manage users
- Project follows DDD philosophy

Below, you can find example of basics pages in the application and part of the code behind !

<h2>1. Register</h2>

From frontend, throught POST request, backend expects userRegisterDto to create new user.
<div class="row">
  <div class="column" style="width:100%">
  <img src=https://user-images.githubusercontent.com/79094141/143820000-e3a71c17-92da-4945-839a-cd596bc6a913.png>
  </div>
  <div class="column" style="width:100%">
  <img src=https://user-images.githubusercontent.com/79094141/143820512-4e1c8cfb-9292-4697-a272-842eeed9a394.png>
  </div>
</div>


<h2>2. Login </h2>
Logging in works more less in the same way - POST request sends a body with user name and password, if user is found and password is ok, user is logged in.
<div class="row">
  <div class="column" style="width:100%">
  <img src=https://user-images.githubusercontent.com/79094141/143821219-9821dcab-e885-464e-be77-d033a75948df.png>
  </div>
  <div class="column" style="width:100%">
  <img src=https://user-images.githubusercontent.com/79094141/143779611-7a8afdde-4d45-4cdf-abdf-da5abd1ee88d.png>
  </div>
</div>


<h2>3. Chat </h2>
Main goal of the app is a live chat communicator between all users. Every user can see all messages stored in database.

<img src=https://user-images.githubusercontent.com/79094141/144188064-f10b7033-43ae-4d49-a5ae-22b4522ef318.png>
Here is how the chat looks like. I used three different browser session to be able to log in with three different accounts. 
<img src=https://user-images.githubusercontent.com/79094141/144188133-1cce1b64-62d3-44aa-b76d-ff431dc7d496.png>

<h2>4. Email sender </h2>
Application has also email sender implemented. It's purpouse is to send an email with a confirmation when an account is created. For debug purpouses, application doesn't send any email, but it was testes and works ! :) 

<h2>4. Logger </h2>
To be done
