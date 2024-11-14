namespace RockPaperScissorsLizardSpock.Application
{
    public static class ConfigureCorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(this WebApplicationBuilder builder)
        {
            var origins = new List<string> { builder.Configuration["AppSettings:RandomNumberClientUrl"] };
            if (builder.Environment.IsDevelopment())
            {
                origins.Add(builder.Configuration["AppSettings:ClientAppUrl"]);
            }

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "RockPaperScissorsLizardSpock",
                                  policy => {
                                      policy.WithOrigins(origins.ToArray());
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                  });
            });
        }
    }
}
