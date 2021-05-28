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
2. Cmd: dotnet restore <br>
3. Cmd: dotnet run <br>
4. Browse http://localhost:5000/Teams/GetAllTeams in local browser <br>


<h2> 2. Unit Test-First Controller Development Project </h2>
<b>Steps to run the Unit Tests Team Service Project: </b><br>
1. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core\test\StatlerWaldorfCorp.TeamService.Tests) <br>
2. Cmd: dotnet restore <br>
3. Cmd: dotnet run <br>
4. Observe the Unit Test Results in the same terminal <b> <br>
Below is the Example output: <br>
<i>Starting test execution, please wait... <br>
A total of 1 test files matched the specified pattern. <br>
<br>
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 11 ms - StatlerWaldorfCorp.TeamService.Tests.dll (net5.0) </i> <br>



