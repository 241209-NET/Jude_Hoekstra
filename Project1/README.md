# Text adventure game

This is a Full Stack Web App made in .NET as a demo of a text adventure game

## Project Members
- Jude Hoekstra

## Project Requirements
- The application should be ASP.NET Core application
- The application should build and run
- The application should have unit tests and at least 20% coverage (at least 5 unit tests that tests 5 different methods/functionality of your code)
- The application should communicate via HTTP(s) (Must have POST, GET, DELETE)
- The application should be RESTful API
- The application should persist data to a SQL Server DB
- The application should communicate to DB via EF Core (Entity Framework Core)

## Tech Stack

- C# (Back End Programming Language)
- SQL Server (Azure Hosted)
- HTML, CSS

## User Stories
- User should be able to login/logout if they already have an account
- User should be able to register if they do not have an account
- User should be able to view room that they are in
- User should be able to pick up items in room
- User should be able to equip items
- User should be able to fight enemy in room

## Tables
![Database ER diagram (crow's foot)](https://github.com/user-attachments/assets/6a21e140-a37d-4fe8-948f-a0fd9d5da8f5)


## MVP Goals
- Ability to traverse across multiple rooms
- Funcionality for non weapon/armor items
- Enemy behavior (moving from rooms, attacking player first)

## Stretch Goals
- Implement login/logout and register functionality to allow for multiple users
- User authentication and password encryption
- Login using google, facebook account
