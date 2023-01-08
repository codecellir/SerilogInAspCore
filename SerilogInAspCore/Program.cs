using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.SystemConsole.Themes;
using System.Collections.ObjectModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(config)
                        .CreateLogger();

//Log.Logger=new LoggerConfiguration()
//    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
//    .MinimumLevel.Error()
//    .CreateLogger();

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File("serilog/log.txt", rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 205, rollOnFileSizeLimit: true,retainedFileCountLimit:null)
//    .MinimumLevel.Error()
//    .CreateLogger();

//var connStr = "Server=.;Database=seriloger;Integrated Security=True;TrustServerCertificate=True";
//var sinkOptions = new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
//{
//    TableName = "LogTbl",
//    AutoCreateSqlTable = true
//};
//var columnOpts = new ColumnOptions();
//columnOpts.Store.Remove(StandardColumn.Properties);
//columnOpts.Store.Add(StandardColumn.LogEvent);
//columnOpts.LogEvent.DataLength = 2048;
//columnOpts.Id.DataType = System.Data.SqlDbType.BigInt;
//columnOpts.AdditionalColumns = new Collection<SqlColumn>
//{
//    new SqlColumn
//    {
//        ColumnName="ReqUri",
//        AllowNull=true,
//        DataType=System.Data.SqlDbType.NVarChar,
//        DataLength=2048,
//        PropertyName="Position"
//    }
//};

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.MSSqlServer(
//    connectionString: connStr,
//    sinkOptions: sinkOptions,
//    columnOptions:columnOpts
//    )
//    .MinimumLevel.Error()
//    .CreateLogger();

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Seq("http://localhost:5341")
//    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
