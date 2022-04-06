using JHipster.NetLite.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJHipsterLite();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var logger = scope.ServiceProvider.GetService<ILogger<Program>>();

logger.LogInformation(@$"  {AnsiColor.GREEN}      ██╗{AnsiColor.RED} ██╗   ██╗ ████████╗ ███████╗   ██████╗ ████████╗ ████████╗ ███████╗ {AnsiColor.MAGENTA}   ███╗   ██╗███████╗████████╗
  {AnsiColor.GREEN}      ██║{AnsiColor.RED} ██║   ██║ ╚══██╔══╝ ██╔═══██╗ ██╔════╝ ╚══██╔══╝ ██╔═════╝ ██╔═══██╗{AnsiColor.MAGENTA}   ████╗  ██║██╔════╝╚══██╔══╝
  {AnsiColor.GREEN}      ██║{AnsiColor.RED} ████████║    ██║    ███████╔╝ ╚█████╗     ██║    ██████╗   ███████╔╝{AnsiColor.MAGENTA}   ██╔██╗ ██║█████╗     ██║   
  {AnsiColor.GREEN}██╗   ██║{AnsiColor.RED} ██╔═══██║    ██║    ██╔════╝   ╚═══██╗    ██║    ██╔═══╝   ██╔══██║ {AnsiColor.MAGENTA}   ██║╚██╗██║██╔══╝     ██║   
  {AnsiColor.GREEN}╚██████╔╝{AnsiColor.RED} ██║   ██║ ████████╗ ██║       ██████╔╝    ██║    ████████╗ ██║  ╚██╗{AnsiColor.MAGENTA}██╗██║ ╚████║███████╗   ██║   
  {AnsiColor.GREEN} ╚═════╝ {AnsiColor.RED} ╚═╝   ╚═╝ ╚═══════╝ ╚═╝       ╚═════╝     ╚═╝    ╚═══════╝ ╚═╝   ╚═╝{AnsiColor.MAGENTA}╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝   
{AnsiColor.WHITE}█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
{AnsiColor.BRIGHT_BLUE}:: JHipster.Net 🤓  :: Running ASP.Net Core 'The best version' ::
:: http://jhipster.github.io ::{AnsiColor.DEFAULT}");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class AnsiColor {

        public const string RESET = "\u001b[0m";
        public const string DEFAULT = "\u001b[39m";

        public const string BLACK = "\u001b[30m";
        public const string RED = "\u001b[31m";
        public const string GREEN = "\u001b[32m";
        public const string YELLOW = "\u001b[33m";
        public const string BLUE = "\u001b[34m";
        public const string MAGENTA = "\u001b[35m";
        public const string CYAN = "\u001b[36m";
        public const string WHITE = "\u001b[37m";

        public const string BRIGHT_BLACK = "\u001b[90m";
        public const string BRIGHT_RED = "\u001b[91m";
        public const string BRIGHT_GREEN = "\u001b[92m";
        public const string BRIGHT_YELLOW = "\u001b[93m";
        public const string BRIGHT_BLUE = "\u001b[94m";
        public const string BRIGHT_MAGENTA = "\u001b[95m";
        public const string BRIGHT_CYAN = "\u001b[96m";
        public const string BRIGHT_WHITE = "\u001b[97m";

    }