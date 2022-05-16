// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServerInMemory;
using IdentityServerInMemory.Controllers;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;

        // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
        options.EmitStaticAudienceClaim = true;
    })
    // in-memory, code config
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    //Add Test Users
    .AddTestUsers(TestUsers.Users)
    //Add PCKE
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication()
    // .AddGoogle(options =>
    // {
    //     options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
    //
    //     // register your IdentityServer with Google at https://console.developers.google.com
    //     // enable the Google+ API
    //     // set the redirect URI to https://localhost:5001/signin-google
    //     options.ClientId = "copy client ID from Google here";
    //     options.ClientSecret = "copy client secret from Google here";
    // })
    .AddCertificate(options =>
    {
        options.AllowedCertificateTypes = CertificateTypes.All;
        options.RevocationMode = X509RevocationMode.NoCheck;
    });

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    IdentityModelEventSource.ShowPII = true;
}

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
app.Run();