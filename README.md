# DigitalCharacterSheetAPI

DigitalCharacterSheetAPI is an API for accessing the Characters and Attributes tables used in my DigitalCharacterSheet2 web app. 
It allows for full CRUD functionality on both tables. 

Unfortunately, I am no longer hosting this web app online
# Getting Started

I coded this web app on Microsoft Visual Studio 2017 using the asp.net core api template, created the database with Microsoft SQL Server Management Studeio 2017, and hosted it on Microsoft Azure. I would recomend anyone using this code to download these tools.

# bonus marks

In the DBConnect.cs file, under the Models folder, starting at line 24, you will find a function that I think qualifies this assignment for the two bonus marks outlined in the rubric. 
It is a function that allows me to use fluent API (a concept I needed to teach myself) to assign a composite primary key on the AttributeModel. 
This was nessessary for my API to function properly because I require two primary keys for my database to function properly, and ASP.NET Core does not allow for the assignment of composite primary keys the same way that ASP.NET MVC does. 

# Documentation

Below are the list of commands for this API.

Characters: 

- To access the characters table, send requests to this link: https://digital-character-sheet-api.azurewebsites.net/api/characters  
  
- the id used for CRUD functionality on this table is the character name (ex: https://digital-character-sheet-api.azurewebsites.net/api/characters/Nic
  
Attributes:  
  
- To access the attributes table, send requests to this link: https://digital-character-sheet-api.azurewebsites.net/api/attributes  
  
- there are two id's used for CRUD functionality on this table; the first is the character's name, the second is the attribute's name, seperated by a comma and a space (ex: https://digital-character-sheet-api.azurewebsites.net/api/attributes/Also Nic, atr 1)

# Authors

Nicholas Gardner student of Computer Studies at Georgian College
Code partially based off the Music Store API in class project, made by Rich Freeman, the professor for my Monday afternoon COMP2084 Server-Side Scripting course.
