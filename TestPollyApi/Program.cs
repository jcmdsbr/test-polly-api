var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/sleep", async (int? time) =>
{
    var timeToSleep = time ?? 5;
    await Task.Delay(TimeSpan.FromSeconds(timeToSleep));
    return Results.Ok();
}).WithName("SleepApi");


app.MapGet("/fail",  () => Results.BadRequest()).WithName("FailApi");

app.MapGet("/intermittent", () =>
{
    var rand = new Random();
    var number = rand.Next(0, 10);
    return number % 2 == 0 ? Results.Ok() : Results.BadRequest();
}).WithName("IntermittentApi");

app.Run();
