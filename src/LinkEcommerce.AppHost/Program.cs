var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis")
.WithImageTag("latest");

var rabbitMq = builder.AddRabbitMQ("eventbus");

var postgres = builder.AddPostgres("postgres")
.WithImage("ankane/pgvector")
.WithImageTag("latest")
.WithPgAdmin();

var seq = builder.AddSeq("seq").ExcludeFromManifest();

var catalogDb = postgres.AddDatabase("catalogdb");
var identityDb = postgres.AddDatabase("identitydb");
var orderDb = postgres.AddDatabase("orderingdb");

var identity = builder.AddProject<Projects.Identity>("identity-ecommerce")
.WithReference(identityDb)
.WithReference(seq)
.WithEnvironment("SeqEndpoint", seq.GetEndpoint("http"))
.WithExternalHttpEndpoints();

var basket = builder.AddProject<Projects.Basket>("basket-ecommerce")
.WithReference(redis)
.WithReference(seq)
.WithEnvironment("SeqEndpoint", seq.GetEndpoint("http"))
.WithEnvironment("Identity__Url", identity.GetEndpoint("http"))
.WithExternalHttpEndpoints();

var orders = builder.AddProject<Projects.Orders>("orders-ecommerce")
.WithReference(orderDb)
.WithReference(seq) 
.WithEnvironment("SeqEndpoint", seq.GetEndpoint("http"))
.WithExternalHttpEndpoints();

var catalogs = builder.AddProject<Projects.Catalogs>("catalogs-ecommerce")
.WithReference(catalogDb)
.WithReference(seq)
.WithEnvironment("SeqEndpoint", seq.GetEndpoint("http"))
.WithEnvironment("IdentityApiClient", identity.GetEndpoint("http"))
.WithEnvironment("Identity__Url", identity.GetEndpoint("http"))
.WithExternalHttpEndpoints();

var payments = builder.AddProject<Projects.Payments>("payments-ecommerce");

var webapp = builder.AddNpmApp("angular", "../Webs/link-app")
.WithReference(identity)
.WithReference(catalogs)
.WithReference(basket)
.WithEnvironment("Algo", "12336")
.WithHttpEndpoint(env: "PORT")
.WithExternalHttpEndpoints()
.PublishAsDockerFile();

identity.WithEnvironment("IdentityApiClient", identity.GetEndpoint("http"))
.WithEnvironment("BasketApiClient", basket.GetEndpoint("http"))
.WithEnvironment("OrderingApiClient", orders.GetEndpoint("http"))
.WithEnvironment("Identity__Url", identity.GetEndpoint("http"))
.WithEnvironment("CatalogApiClient", catalogs.GetEndpoint("http"));

builder.Build().Run();
