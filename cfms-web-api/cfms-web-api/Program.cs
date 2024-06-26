﻿using cfms_web_api.Controller;
using cfms_web_api.Controllers.v2;
using cfms_web_api.Data;
using cfms_web_api.Interfaces;
using cfms_web_api.Repositories;
using cfms_web_api.Services;
using cfms_web_api.SwaggerConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.DocumentFilter<SwaggerDocumentFilter>();
    options.OperationFilter<SwaggerOperationFilter>();

    var docFile = $"{typeof(Program).Assembly.GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, docFile));
});

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IMailService, MailgunService>();
builder.Services.AddScoped<NotificationController>();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigOptions>();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers();

var app = builder.Build();

var versionDescProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelExpandDepth(2);
        options.DefaultModelRendering(ModelRendering.Model);
        options.DisplayOperationId();
        options.DisplayRequestDuration();
        options.DocExpansion(DocExpansion.None);
        options.ShowExtensions();

        // Specify Swagger endpoints for each API version
        foreach (var desc in versionDescProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
                $"Customer Feedback API v{desc.GroupName.ToUpper()}{(desc.IsDeprecated ? " (deprecated)" : "")}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
