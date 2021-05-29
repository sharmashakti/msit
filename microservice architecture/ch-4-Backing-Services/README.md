## 1. Location Service Api Project
<br>
Follow below steps to run the Location Service <br> 
1. Open command prompt and navigate to directory (ch-4-Backing-Services\locationservice\src\StatlerWaldorfCorp.LocationService) <br>
2. Cmd: dotnet restore <br>
3. Cmd: dotnet run <br>

**Verification Steps**:
1. Post a New Location object using Postman or Powershell with below command <br>
2. > Url: http://localhost:5000/locations/0edaf3d2-5f5f-4e13-ae27-a7fbea9fccfc
3. PowerShell Command:
    ``` 
    $headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
    $headers.Add("Content-Type", "application/json")

    $body = "{`"id`": `"55bf35ba-deb7-4708-abc2-a21054dbfa15`", `"latitude`": 22.56, `"longitude`": 45.567, `"altitude`": 1200, `"timestamp`" : 1476029596, `"memberId`": `"0edaf3d2-5f5f-4e13-ae27-a7fbea9fccfc`" }"

    $response = Invoke-RestMethod 'http://localhost:5000/locations/0edaf3d2-5f5f-4e13-ae27-a7fbea9fccfc' -Method 'POST' -Headers $headers -Body $body
    $response | ConvertTo-Json
    ```
 4. Expected Outcome of the above Post Call:
    ```
    {
      "id": "55bf35ba-deb7-4708-abc2-a21054dbfa15",
      "latitude": 22.56,
      "longitude": 45.567,
      "altitude": 1200,
      "timestamp": 1476029596,
      "memberID": "0edaf3d2-5f5f-4e13-ae27-a7fbea9fccfc"
    }
    ```

5. Run below Url to get Get the above added Location either in Url or PostMan tool
   > http://localhost:5000/locations/0edaf3d2-5f5f-4e13-ae27-a7fbea9fccfc 

