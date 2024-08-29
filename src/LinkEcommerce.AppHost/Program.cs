var builder = DistributedApplication.CreateBuilder(args);

var identidad = builder.AddProject<Projects.Identidad>("identidad")
 .WithExternalHttpEndpoints();
var canasta = builder.AddProject<Projects.Canasta>("canasta");
var ordenes = builder.AddProject<Projects.Ordenes>("ordenes");
var pagos = builder.AddProject<Projects.Pagos>("pagos");

var webapp = builder.AddNpmApp("angular", "../Webs/link-app")
.WithReference(identidad)
.WithHttpEndpoint(env: "PORT")
.WithExternalHttpEndpoints()
.PublishAsDockerFile();



builder.Build().Run();
