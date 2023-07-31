using MýddlewarePracticesAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Bunlarýn hepsi aslýnda middleware
    //middleware'in yazýlým sýrasý önemlidir
    //Genel olarak isimlendirmede Use ile baþlar
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseHello();

app.Run(); //Kendinden sonrakiler normalde çalýþmaz kýsa devre yapar

//app.User(); 

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 1 basladý");
//    await next.Invoke();
//    Console.WriteLine("Middleware 1 sonlandýrýlýyor");
//    //async methodlar normalde sonuç beklemeden arka arkaya çalýþan þeylere denir
//    //burda await eklediðimizde önce sonucu bekle sonra çalýþtýr demiþ oluyoruz bir nevi
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 2 basladý");
//    await next.Invoke();
//    Console.WriteLine("Middleware 2 sonlandýrýlýyor");
//});

