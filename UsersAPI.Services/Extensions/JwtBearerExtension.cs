﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace UsersAPI.Services.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services)
        {
            //definindo a política de autenticação do projeto
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })                
                .AddJwtBearer(options =>
                {
                    //definindo as preferencias para autenticação com TOKEN JWT
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, //validar o emissor do token
                        ValidateAudience = true, //validar o destinatário do token
                        ValidateLifetime = true, //validar o tempo de expiração do token
                        ValidateIssuerSigningKey = true, //validar a chave secreta utilizada pelo emissor do token
                    };
                });

            return services;
        }
    }
}
