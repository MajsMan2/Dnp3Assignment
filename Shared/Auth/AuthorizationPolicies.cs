﻿namespace Shared.Auth;

public static class AuthorizationPolicies
{
   // public static void AddPolicies(IServiceCollection services)
    //{
     //   services.AddAuthorizationCore(options =>
      //  {
       //     options.AddPolicy("GetAsAuthorized", a =>
        //        a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "4", "5"));
         //   options.AddPolicy("SecurityLevel2OrAbove", a =>
         //       a.RequireAuthenticatedUser().RequireAssertion(context =>
           //     {
             //       Claim? levelClaim = context.User.FindFirst(claim => claim.Type.Equals("SecurityLevel"));
              //      if (levelClaim == null) return false;
               //     return int.Parse(levelClaim.Value) >= 2;
               // }));
       // });
   // }
}