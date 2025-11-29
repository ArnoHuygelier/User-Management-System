using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<UserManagement_Api>("usermanagement-api");
builder.AddProject<UserManagement_Ui_Blazor_Wasm>("usermanagement-ui-blazor-wasm");

var app = builder.Build();

await app.RunAsync();
