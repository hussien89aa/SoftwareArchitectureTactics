Instructions:
-------------
1- Download and extract the ZIP file.
2- Open the "Heartbeat tactic" folder.
3- Open "FileApps" (where the executable files are available).
4- Click and execute "CarServer.exe".
5- It will prompt which server you want to work with; select "1" (Main server).
6- If there's a Windows firewall alert, click "Allow Access", and the message in the command line will say "Main server is started. Server working".
7- Then, execute the "CarApp.exe" process. It will show that 'Car App is working'.
8- Open or execute "HeartBeatTactic.exe" and it will show the user port used and if everything is working properly it will keep displaying 'Im alive' every X seconds. After, the "CarServer" process will send the user locations every X seconds.

Quality attributes:

1-If the GPS process  fails, notify the monitor deletes it, then the monitor will restart the gps in 1 secs.
2-If the client app “Sending location process” fail to send data to server, monitor  detects it, and switches to backup server.


Domain: Car Tracking System

Source of stimulus:
Random event.

Stimulus:
A process fails.

Environment:
While the car is turned on and moving.

Response:
The failure is detected and the process will be switched for another operation.

Response measure:
Failure is detected in 2 seconds. The process is restarted to make it working again.

A process may fail due to internal circumstances.
If there is some failure and the process is stopped, the heartbeat tactic comes into play.
A failure may occur every 2-3 minutes.
The system may be out for like X seconds/minutes.
The system will notify whenever a process is stopped or resumed.
