1.This solution contains both front end (Angular) and Back end(.Net core Web APi) code.
2.user need to run the web application.(may need to check the port on which the website will run)
3.The solution is divided into different projects(Web, Model,Business and data)
4.User first needs to login and after that the application will check for any present ides and assign them to different users
5.The logged in user will see the ideas assigned to him/her.
6.The user can evaluate the ideas.
7.The approch used here is that after any of the users logs in then, to check for any ideas which are not yet assigned to any user and then assign them to different users.
8.One idea will be available for evluation to three different users.
9.From Angular side Login and idea-evaluate components are added.
10.From API side the Login and Idea Evaluator controllers are added.
11.Dependancy injection is used
12.Entity framework core is used for all the data related operation
13.SQL SERVER is used to store the data.
