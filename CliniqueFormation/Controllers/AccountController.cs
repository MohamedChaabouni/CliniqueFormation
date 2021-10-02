using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CliniqueFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Login
            // JWT Tokens 
            // Authorization
        // Logout
        // Register
            // Identity -> User management
                 // Register, Reset password, forgot password ..., Login (Web Session) x
            // N-Tier (service, data) 
                // service:
                    // DI (UserManager<ApplicationUser> (create, delete, update, list),
                    //  SignInManager<ApplicationUser> Login, Logout, ... (Web Session) x
                    //  RoleManager<ApplicationUser> : Affect roles to user
                    //      User * ---- * Roles
                // Data UserStore<ApplicationUser> : UserManager<ApplicationUser> uses UserStore<ApplicationUser> 
                    // SQL : requete SQL de la création du User
                    // Postgres : requete SQL  User
                    // MongoDB : insert document, delete, update ...
        // Reset password UserManager<ApplicationUser>
        // Forgot password UserManager<ApplicationUser>
        // List users UserManager<ApplicationUser>
    }
}