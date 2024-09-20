using Api;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//inicio

List<Rol> roles = new List<Rol>
{
    new Rol { IdRol = 1, Nombre = "Admin", Habilitado = true, FechaCreacion = DateTime.Now },
    new Rol { IdRol = 2, Nombre = "User", Habilitado = true, FechaCreacion = DateTime.Now }
};

List<Usuario> usuarios = new List<Usuario>
{
    new Usuario { IdUsuario = 1, Nombre = "Lucas", Email = "lucas@example.com", NombreUsuario = "lucas123", Contraseña = "password", Habilitado = true, FechaCreacion = DateTime.Now },
    new Usuario { IdUsuario = 2, Nombre = "Nahuel", Email = "nahuel@example.com", NombreUsuario = "nahuel123", Contraseña = "password", Habilitado = true, FechaCreacion = DateTime.Now }
};

List<UsuarioRol> usuarioRoles = new List<UsuarioRol>
{
    new UsuarioRol { IdUsuarioRol = 1, IdUsuario = 1, IdRol = 1 },
    new UsuarioRol { IdUsuarioRol = 2, IdUsuario = 2, IdRol = 2 }
};

// Endpoints para Usuario
app.MapGet("/usuario", () =>
{
    return Results.Ok(usuarios);
}).WithTags("Usuario");

app.MapPost("/usuario", ([FromBody] Usuario usuario) =>
{
    usuarios.Add(usuario);
    return Results.Ok(usuarios);
}).WithTags("Usuario");

// Endpoints para UsuarioRol
app.MapGet("/usuariorol", () =>
{
    return Results.Ok(usuarioRoles);
}).WithTags("UsuarioRol");

app.MapPost("/usuariorol", ([FromBody] UsuarioRol usuarioRol) =>
{
    usuarioRoles.Add(usuarioRol);
    return Results.Ok(usuarioRoles);
}).WithTags("UsuarioRol");


//fin


app.Run();