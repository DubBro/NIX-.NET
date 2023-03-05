﻿global using System.Net;
global using Microsoft.AspNetCore.Mvc;
global using Infrastructure;
global using Infrastructure.Identity;
global using Infrastructure.Services;
global using Infrastructure.Services.Interfaces;
global using Infrastructure.Filters;
global using Infrastructure.Extensions;
global using Infrastructure.RateLimit.Extensions;
global using Infrastructure.RateLimit.Cache.Services.Interfaces;
global using Infrastructure.RateLimit.Cache.Services;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.Extensions.Options;