var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.UserManagement_Api>("usermanagement-api");

builder.AddProject<Projects.UserManagement_Dto>("usermanagement-dto");

builder.Build().Run();
