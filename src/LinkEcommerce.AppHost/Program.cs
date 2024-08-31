var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");
var rabbitMq = builder.AddRabbitMQ("eventbus");
var postgres = builder.AddPostgres("postgres")
.WithImage("ankane/pgvector")
.WithImageTag("latest")
.WithPgAdmin();

var catalogDb = postgres.AddDatabase("catalogdb");
var identityDb = postgres.AddDatabase("identitydb");
var orderDb = postgres.AddDatabase("orderingdb");

var identity = builder.AddProject<Projects.Identity>("identity-ecommerce")
.WithReference(identityDb)
 .WithExternalHttpEndpoints();

var basket = builder.AddProject<Projects.Basket>("basket-ecommerce")
.WithReference(redis)
 .WithExternalHttpEndpoints();

var orders = builder.AddProject<Projects.Orders>("orders-ecommerce")
.WithReference(orderDb)
 .WithExternalHttpEndpoints();

var catalogs = builder.AddProject<Projects.Catalogs>("catalogs-ecommerce")
.WithReference(catalogDb)
.WithExternalHttpEndpoints();

var payments = builder.AddProject<Projects.Payments>("payments-ecommerce");

var webapp = builder.AddNpmApp("angular", "../Webs/link-app")
.WithReference(identity)
.WithHttpEndpoint(env: "PORT")
.WithExternalHttpEndpoints()
.PublishAsDockerFile();

identity.WithEnvironment("IdentityApiClient", identity.GetEndpoint("http"))
.WithEnvironment("BasketApiClient", basket.GetEndpoint("http"))
.WithEnvironment("OrderingApiClient", orders.GetEndpoint("http"))
.WithEnvironment("Identity__Url", identity.GetEndpoint("http"))
.WithEnvironment("CatalogApiClient", catalogs.GetEndpoint("http"));

builder.Build().Run();
