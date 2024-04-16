# EventHubExample

## Description
This project demonstrates the integration of Azure Functions with Azure Event Hubs in .NET, processing data events.

## Project Structure
- **EventHubExample.sln**: Project solution.
- **FunctionApp1**: Function app directory with necessary code and configuration.

## Configuration

### EventHubExample
1. Install `Microsoft.Azure.EventHubs` package.
2. In `Program.cs`, set `EventHubConnectionString` to the `Connection string–primary key` found in the Azure Event Hubs instance under `Shared access policies`.
3. ![image](https://github.com/felixjimcal/EventHubExample/assets/8387061/9bf41a67-ff88-4a63-9ed1-42870d222075)
4. Set `EventHubName` to the name of your Event Hub.

### FunctionApp1
1. In `local.settings.json`, add `"AzureWebJobsStorage": "UseDevelopmentStorage=true"`.
2. Add `"AzureEventHubConnectionString"` with the same value as `EventHubConnectionString` from EventHubExample.
3. Add `"APPINSIGHTS_INSTRUMENTATIONKEY"`: `Your Instrumentation Key` from Application Insights.
4. ![image](https://github.com/felixjimcal/EventHubExample/assets/8387061/19370aa9-2e55-4259-bcc5-2fcdf9686fb1)
5. Navigate to `connected services`, in Visual Studio, and connect to the corresponding Application Insights.

## Run it
You are ready to go.
