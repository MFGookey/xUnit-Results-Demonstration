Set-Location ./src/xUnit-Result-Demonstration.Tests/
dotnet restore
dotnet xunit -configuration "Release" -diagnostics -stoponfail -xml "TestResults.xml"