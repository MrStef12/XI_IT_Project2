# Assignment 1 - Internet Technology
### Steffen Hansen (stefh14)

This project is built using ASP.NET Core MVC, and a couple of client side libraries to enhance the user experience.

## To open the project
Simply open Visual Studio 2017 and open the solution of the project.

## Pages
* Frontpage
    * **Controller**: GalleryController -> Index()
    * **View**: Gallery/Index.cshtml
* Add new gallery item
    * **Controller**: GalleryController -> New()
    * **View**: Gallery/New.cshtml
* Gallery overview
    * **Controller**: GalleryController -> Overview()
    * **View**: Gallery/Overview.cshtml
* About
    * **Controller**: AboutController -> Index()
    * **View**: About/Index.cshtml
* Login
    * **Controller**: AccountController -> Login()
    * **View**: Account/Login.cshtml
* Register
    * **Controller**: AccountController -> Register()
    * **View**: Account/Register.cshtml

It was decided that the homepage defaults to the gallery controller index, so that the gallery is the front page.

## Entity Framwork
This project uses the Entity Framework for database migraion and communication. It uses a local database.

The *Image* model, found under Models/Image.cs represents a Image in the gallery and holds validations rules for when creating a new Imange in the *Add new gallery item* page.

## Layouts
The project has a global shared layout file. It defines the header, navbar, footer and scripts-section.

## Libraries
This project uses a couple of clientside libraries to enhance the user experience. They are as follows along with their usages:

* Bootstrap
    * To style the pages and make it responsive
* Viewer.js
    * To show the gallery as a proper gallery, where you can click on an image to view it.
* JQuery
    * Used to ease form validation when registering a new user.

## CSS and JavaScript
CSS and JavaScript files can be found in the wwwroot folder.