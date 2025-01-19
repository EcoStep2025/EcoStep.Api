﻿using EcoStep.Application.Services.Interfaces;
using FirebaseAdmin.Auth;

namespace EcoStep.Application.Services.Classes;

public class FirebaseAuthenticationService : IAuthenticationService
{
    public async Task<string?> VerifyTokenAsync(string token)
    {
        try
        {
            var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
            return decodedToken.Uid;
        }
        catch
        {
            return null;
        }
    }
}