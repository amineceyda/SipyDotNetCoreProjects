using M�ddlewarePracticesAPI.Middlewares;

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
    //Bunlar�n hepsi asl�nda middleware
    //middleware'in yaz�l�m s�ras� �nemlidir
    //Genel olarak isimlendirmede Use ile ba�lar
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseHello();

app.Run(); //Kendinden sonrakiler normalde �al��maz k�sa devre yapar

//app.User(); 

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 1 baslad�");
//    await next.Invoke();
//    Console.WriteLine("Middleware 1 sonland�r�l�yor");
//    //async methodlar normalde sonu� beklemeden arka arkaya �al��an �eylere denir
//    //burda await ekledi�imizde �nce sonucu bekle sonra �al��t�r demi� oluyoruz bir nevi
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Middleware 2 baslad�");
//    await next.Invoke();
//    Console.WriteLine("Middleware 2 sonland�r�l�yor");
//});

