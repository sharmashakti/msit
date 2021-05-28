<h2> Chapter 3. Building a Microservice with ASP.NET Core </h2>
<br>

Source Code Directory Structure <br>

├── src
│ └── StatlerWaldorfCorp.TeamService
│ ├── Models
│ │ ├── Member.cs
│ │ └── Team.cs
│ ├── Program.cs
│ ├── Startup.cs
│ ├── StatlerWaldorfCorp.TeamService.csproj
│ └── TeamsController.cs
└── test
└── StatlerWaldorfCorp.TeamService.Tests
├── StatlerWaldorfCorp.TeamService.Tests.csproj
└── TeamsControllerTest.cs

<h2>1. The Team Service API Project</h2> <br>
Steps to run the Team Service API Project: <br>
1. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core\src\StatlerWaldorfCorp.TeamService) <br>
2. Cmd: dotnet restore <br>
3. Cmd: dotnet run <br>
4. Browse http://localhost:5000/Teams/GetAllTeams in local browser <br>


<h2> 2. Unit Test-First Controller Development Project <h2>
Steps to run the Unit Tests Team Service Project: <br>
1. Open the Command Prompt and navigate to Directory (ch-3-building-a-microservice-with-ASP.NET-Core\test\StatlerWaldorfCorp.TeamService.Tests) <br>
2. Cmd: dotnet restore <br>
3. Cmd: dotnet run <br>
4. Observe the Unit Test Results in the same terminal
Below is the Example output: <br>
<i>Starting test execution, please wait... <br>
A total of 1 test files matched the specified pattern. <br>
<br>
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 11 ms - StatlerWaldorfCorp.TeamService.Tests.dll (netcoreapp3.1) </i> <br>



