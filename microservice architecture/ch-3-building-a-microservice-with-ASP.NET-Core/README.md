<h2> Chapter 3. Building a Microservice with ASP.NET Core </h2>
<br>

<b>Source Code Directory Structure</b> <br>

├── src <br>
│ └── StatlerWaldorfCorp.TeamService  <br>
│ ├── Models  <br>
│ │ ├── Member.cs  <br>
│ │ └── Team.cs <br>
│ ├── Program.cs <br>
│ ├── Startup.cs <br>
│ ├── StatlerWaldorfCorp.TeamService.csproj <br>
│ └── TeamsController.cs <br>
└── test <br>
└── StatlerWaldorfCorp.TeamService.Tests <br>
├── StatlerWaldorfCorp.TeamService.Tests.csproj <br>
└── TeamsControllerTest.cs <br>

<h2>1. The Team Service API Project</h2> <br>
<b>Steps to run the Team Service API Project: </b> <br>
1. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core\src\StatlerWaldorfCorp.TeamService) <br>
2. Cmd: <b>dotnet restore</b> <br>
3. Cmd: <b>dotnet run</b> <br>
4. Browse http://localhost:5000/Teams/GetAllTeams in local browser <br>


<h2> 2. Unit Test-First Controller Development Project </h2>
<b>Steps to run the Unit Tests Team Service Project: </b><br>
1. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core\test\StatlerWaldorfCorp.TeamService.Tests) <br>
2. Cmd: <b>dotnet restore</b> <br>
3. Cmd: <b>dotnet test</b> <br>
4. Observe the Unit Test Results in the same terminal  <br>
Below is the Example output: <br>
<i>Starting test execution, please wait... <br>
A total of 1 test files matched the specified pattern. <br>
<br>
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 11 ms - StatlerWaldorfCorp.TeamService.Tests.dll (net5.0) </i> <br>

<h2> 3. Create a CI Pipeline (Not Done Yet) </h2>

<br>
<h2> 4. Integration Testing (Integration .NetCore Project)</h2>
<br>
<b>Steps to run the Integration Test Team Service Project</b>
1. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core\test\StatlerWaldorfCorp.TeamService.Tests.Integration) <br>
2. Cmd: <b>dotnet restore</b> <br>
3. Cmd: <b>dotnet test</b> <br>
4. Observe the Unit Test Results in the same terminal  <br>
Below is the Example output: <br>
<i>Starting test execution, please wait... <br>
A total of 1 test files matched the specified pattern. <br>
<br>
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 11 ms - StatlerWaldorfCorp.TeamService.Tests.dll (net5.0) </i> <br>

<br>
<h2>5. Runing the Team Service Main Application Docker Image</h2>
<br>
Note**: Since for now, we have configured Continous Integration with wercker.yml, so will locally build and run the Docker Image
1. Ensure, that Docker Desktop tool is running (Refer Chapter 2 README.md for installation and check Docker Configurations
2. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core) <br>
3. Run command:  docker build -t aspnetcore-teamsservice-webapi:1.0 .
4. Now run docker image, command: docker run -p 80:80 aspnetcore-teamsservice-webapi:1.0

<b>Verification Steps</b>: <br> 
1. Initially No Teams Present, for that just run http://localhost/Teams/GetAllTeams <br>
    Ensure empty [] result is coming back <br>
2. Post a Team object at http://localhost/Teams/CreateTeam [POST] <br>
3.  Since this is Post request, either use PostMan tool or run below command in PowerShell <br>
      $headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"  <br>
      $headers.Add("Content-Type", "application/json")  <br>
<br>
      $body = "{`"id`":`"e52baa63-d511-417e-9e54-7aab04286281`",  <br>
      `n`"name`":`"Team Zombie`"}"  <br>
<br>
      $response = Invoke-RestMethod 'http://localhost/Teams/CreateTeam' -Method 'POST' -Headers $headers -Body $body  <br>
      $response | ConvertTo-Json  <br>

3. Now call again http://localhost/Teams/GetAllTeams  [GET] in your browser. And you shoudl see below result <br>
   { <br>
    "name ": "Team Zombie", <br>
    "id": "e52baa63-d511-417e-9e54-7aab04286281", <br>
    "members": []  <br>
    } <br>




