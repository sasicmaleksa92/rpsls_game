# RockPaperScissorsLizardSpock game project

This project is implemented using .NET Core 8 for the backend and Angular (version-18.2.1) for the frontend.

The application has the following functionalities and uses cases:
#### Guest and Registered User Access:
When a player first accesses the application, they have the option to continue as a guest or register and log in. Once successfully logged in, the player's username will appear on the scoreboard, along with a record of all previously played rounds and scores.

![Alt text](/Images/Screenshot-Guest.png?raw=true "Optional Title")
#### Round Records and Scoring:
All completed rounds are displayed in a table, with the most recent round listed at the top. The scores are calculated and reflected on the scoreboard.
#### Guest User Limitations:
For guest users, the rounds played are only active during the current session and are not stored in the database.
#### Persistent Data for Registered Users:
For logged-in users, both played rounds and scores are stored in the database. This ensures the data remains intact even if the page is refreshed or the user logs out.

![Alt text](/Images/Screenshot-Player.png?raw=true "Optional Title")
#### Score Reset Option:
Both guest and registered users have the option to reset their scores. This action clears all previously played rounds and resets the score to zero.


## Running the Project - WebApi

To run the project perform the following steps:

Open a new command window in the web api project - RockPaperScissorsLizardSpock.WebApi:

```
dotnet restore
dotnet build
dotnet watch run
```

## Running the Project - ClientApp
You'll find the Angular code for the project in the `ClientApp` folder.

To run the project perform the following steps:
1. Install Node.js 20 or higher - https://nodejs.org
2. Install ASP.NET core 8 - https://dot.net
3. Install the Angular CLI:
    `npm install -g @angular/cli`
4. Open a command prompt and `cd` into the project's `ClientApp` folder
5. Run `npm install`
6. Run `npm run start` to start the Angular build process and the application.
8. Visit http://localhost:4200 in the browser

## Docker support - Running the Project - WebApi
1. [Install Docker Compose](https://docs.docker.com/compose/install/)
2. Clone this repository
3. Run all containers with `docker-compose up -d`
4. Refresh `localhost:8080` a few times in your web browser to generate some traces. 


## Additional notes:

* CORS is enabled in the `Startup.cs` file. You'll more than likely want to lock-down some of the settings for it though.
* The frontend part, especially one for the register/login activities is created just to allow testing the multiple users uses cases and can be better implemented

