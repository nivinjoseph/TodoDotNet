Perquisites:
- Docker

Steps:
1. Open terminal

2. Git clone the repo

3. cd into the repo directory

4. Execute the following command

docker build -t todo-api -f ./Dockerfile . && docker run -d -p 5000:5000 todo-api && docker build -t todo-app -f ./TodoApp/Dockerfile ./TodoApp && docker run -d -p 4000:4000 todo-app

Command can take over 5 mins to finish running the first time around. Please be patient.

5. After the command has finished executing, navigate to http://localhost:4000/ in your browser.