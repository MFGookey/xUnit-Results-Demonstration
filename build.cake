  string id = "xUnit-Result-Demonstration";
	string config = "Release";
	string outputDir = "./publish/";
	
	string target = Argument("target", "Release");
	target = target == "Default" ? "Release" : target;
	
	Task("Release")
	  .IsDependentOn("Clean")
	  .IsDependentOn("Pack");
	
	Task("Restore")
	  .Does(() => {
	    DotNetCoreRestore(string.Format("src/{0}.sln", id));
	  });
	
	Task("Clean")
	  .Does(() => {
	    EnsureDirectoryExists(outputDir);
	    CleanDirectory(outputDir);
	    CleanDirectories("./src/**/bin");
	    CleanDirectories("./src/**/obj");
	    //DeleteFiles(GetFiles("./src/*.Tests/Test*.xml"));
	  });
  
	Task("Test")
	  .IsDependentOn("Clean")
	  .IsDependentOn("Restore")
	  .Does(() => {
	    DotNetCoreTool(
	      projectPath: string.Format("./src/{0}.Tests/{0}.Tests.csproj", id),
	      command: "xunit",
	      arguments: "-configuration \"Release\" -diagnostics -stoponfail -xml \"TestResults.xml\""
	    );
	  });

	Task("Pack")
	  .IsDependentOn("Clean")
	  .IsDependentOn("Restore")
	  .IsDependentOn("Test")
	  .Does(() => {
	    var settings = new DotNetCorePackSettings
	    {
	      ArgumentCustomization = args => args
	        .Append("--include-symbols")
	        .Append("--include-source")
	        .Append("--configuration " + config),
	      OutputDirectory = outputDir
	    };
	
	    DotNetCorePack(string.Format("./src/{0}/{0}.csproj", id), settings);
	  });
	
	RunTarget(target);