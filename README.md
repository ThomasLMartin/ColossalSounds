![image](https://user-images.githubusercontent.com/60017318/76902633-d6f28580-6872-11ea-8580-cdb73616704b.png)

A database management app for a store owner, in this instance an instrument music store, that can also function as a way for customers to view products available for sale at the store, and their essential information.

## Table of Contents
* [Introduction](#introduction)
* [Technologies](#technologies)
* [Installation](#installation)
* [Functions](#functions)
* [Resources](#resources)


## Introduction
This was a class project designed to give us hands on experience building out an API, working together as a team, and utilizing GitHub for as our version control software. Instruments were a common connection between the four of us, so we decided to tackle a project that would benefit an owner of a music store. Thinking more along the lines of a mom and pop type store.

Our goal was to provide the owner with a multifunctional application that allowed them have the ability to create and manage a database for their inventory, customers, and transacations. While at the sametime giving them a platform to display their inventory online so that customers would be able to browser their products, leave reviews, and ratings that would allow an interactive shopping experience.

## Technologies 
Project is created with:
* .Net Framework - ASP.Net Web Application
* C# 
* Created in Visual Studio
* GitHub was used as a collaborative version control tool
* Postman was utilized to test endpoints 


## Installation
To run this application 
```
1. Click on this link: https://github.com/ThomasLMartin/ColossalSounds
2. Go to the "clone/download" and pick the option you would like
3. If you choose to run in Visual Studio
      - Open the start window 
      - Click the "Clone or check out code" option
      - Paste in the link in the "Respository Location" box 
```

## Functions
- Create, update, and delete instruments, accessories, customers, reviews, ranking, transactions, and admin users
  - Our instrument and customer update fuctions include the flexibility to update all feilds at once or one at a time. 
      
- Instruments and accessories can be associated with overarching categories (woodwind, brass etc.) and instrument type (saxophone, guitar etc.)

- Viewing options include:
  - See all instruments
  - See all instruments by category or instrument type
  - Look up instrument by brand, model name, experience level, and by Id
  - See all accessories 
  - See all accessories by instrument type
  - Look up accessory by Id
  - See all customers
  - Look up customer by phone number
  - Reviews and Ratings are created by customers and attached to the specific instrument or accessory
  - Transaction function includes the ability iterate through a customers products to calculate subtotal and total (including tax)

## Resources
- Creating User Roles (note these tutorials are for ASP.NET Core so we had to adapt the principles to ASP.NET Web API)
  - [Extending UserIdentity](https://www.youtube.com/watch?v=NV734cJdZts&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=78&t=0s)
  - [Creating Roles](https://www.youtube.com/watch?v=TuJd2Ez9i3I&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=79&t=0s)
  
- Displaying value of an Enum instead of the index number: [Json Converter](https://exceptionnotfound.net/serializing-enumerations-in-asp-net-web-api/)
- Getting all values inside an Enum in ASP.NET Web API: [Returning Enum Values](https://exceptionnotfound.net/getting-all-valid-enum-values-in-asp-net-web-api/)

- The starting wireframe database tables for our project: [Colossal Sounds WireFrame](https://dbdiagram.io/d/5e5fc17b4495b02c3b87ca9e)









