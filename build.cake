var revision = Argument("revision", "0");
var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");
var solution = "./Source/Azure.sln";
var assemblyInfoPath = "./Source/Azure/Properties/AssemblyInfo.cs";

Task("Build")
	.IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild(solution, s => 
        s.SetConfiguration(configuration));
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    NuGetRestore(solution);
});

Task("Package")
	.IsDependentOn("WriteAssemblyInfo")
	.IsDependentOn("Build")
	.Does(() => {
		
		if( revision == "0") {
			throw new Exception("Pass a revision > 0");
		}

		var assemblyInfo = ParseAssemblyInfo(assemblyInfoPath);

		Console.WriteLine(assemblyInfo);

		var nuGetPackSettings   = new NuGetPackSettings {
                                Id                      = "AzureFormationBuilder",
                                Version                 = "0.1.1." + revision,
                                Title                   = "To build azure resources in a declarative way.",
                                Authors                 = new[] {"Tom Staijen", "Mark Willems"},
                                Owners                  = new[] {"Isatis Health"},
                                Description             = "The description of the package",
                                Summary                 = "Excellent summary of what the package does",
                                ProjectUrl              = new Uri("https://github.com/tomstaijen/AzureResourceFormation"),
                                IconUrl                 = new Uri("http://cdn.rawgit.com/SomeUser/TestNuget/master/icons/testnuget.png"),
                                LicenseUrl              = new Uri("https://github.com/SomeUser/TestNuget/blob/master/LICENSE.md"),
                                Copyright               = "Tom Staijen 2016",
                                ReleaseNotes            = new [] {"Bug fixes", "Issue fixes", "Typos"},
                                Tags                    = new [] {"Azure", "Resource", "Manager", "Deploy", "Provision"},
                                RequireLicenseAcceptance= false,
                                Symbols                 = false,
                                NoPackageAnalysis       = true,
                                Files                   = new [] {
                                                                     new NuSpecContent {Source = "**", Target = ""},
                                                                  },
                                BasePath                = "./Source/Pipeline/bin/release",
                                OutputDirectory         = "./nuget"
                            };

	CreateDirectory("nuget");
	CleanDirectory("nuget");
	NuGetPack(nuGetPackSettings);
});

Task("WriteAssemblyInfo")
.Does(() => {
	if( revision == "0") {
		throw new Exception("Pass a revision > 0");
	}	
		
	var assemblyInfo = ParseAssemblyInfo(assemblyInfoPath);
	Information("Version: {0}", assemblyInfo.AssemblyVersion);

	var parts = assemblyInfo.AssemblyVersion.Split('.');

	var version = string.Format("{0}.{1}.{2}", parts[0], parts[1], revision);

	CreateAssemblyInfo(assemblyInfoPath, new AssemblyInfoSettings {
		Product = "Pipeline",
		Version = version,
		FileVersion = version,
		Copyright = string.Format("Copyright (c) Isatis Health {0}", DateTime.Now.Year)
	});
});


Task("Test")
 .IsDependentOn("Build")
 .Does(() => {
	XUnit2("Source/Pipeline.Test/bin/Debug/Pipeline.Test.dll");
 });

Task("Default")
  .IsDependentOn("Package");

RunTarget(target);
