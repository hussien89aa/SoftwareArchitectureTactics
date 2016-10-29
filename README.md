
#Software Architecture Tactics.
###Assignment No. 3
###Members: Hussein Talib and Bladimir Baez.
###We are implementing the Secure Session Managment tactic that manages the Car App login system from the server side. So, users can login to this web portal with their authetication credentials to manage the bus system by adding new bus or update the bus information.

##Implementation
###1- We developed this database table for the login and account type and car information.
###Secure session
![url](http://attach.alruabye.net/SoftwareArchitectureTactics/SSMDataBase.png)

###We define three different account types, such as:
####A- Manager: Will be able to delete and update the car information.
####B- Driver: Cannot do anything, his access will be limited.
####C- Control: Can add a new car and a driver name. Also this actor can view the list of cars and their drivers.


###2-  We build the web portal to manage user tasks and give specific tasks for every account type, within the system.
 
##----------------------------------------------------------------------
##How to Run the App
##---------------------------------------------------

####1- Install Visual Studio 2015.
####2- Open the "Authentication" folder.
####3- Open Authentication file in Visual Studio.
####4- Run the application.
####5- Register new  users with different account types. 
####6- Login with a different account to see tasks for every account type.
$###Note that the database is online, so the app already connects with it.
####see the branches
##----------------------------------------------------------------------
--
 
