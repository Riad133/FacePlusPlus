using Microsoft.Extensions.DependencyInjection;

namespace FacePlusPlus.Web.Extentions
{
    public static partial class DiExtensions
    {
        public static void AddIdentityServer(this IServiceCollection services, string connectionString)
        {
            // services.AddDbContext<ApplicationDbContext>();
            // services.AddOpenIddict()
            //     .AddCore(options =>
            //     {
            //         // Configure OpenIddict to use the Entity Framework Core stores and models.
            //         // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
            //         options.UseEntityFrameworkCore()
            //             .UseDbContext<ApplicationDbContext>();
            //     }).AddServer(options =>
            //     {
            //         // Enable the authorization, logout, token and userinfo endpoints.
            //         options.SetAuthorizationEndpointUris("/connect/authorize")
            //             .SetLogoutEndpointUris("/connect/logout")
            //             .SetTokenEndpointUris("/connect/token")
            //             .SetIntrospectionEndpointUris("/connect/introspect")
            //             .SetUserinfoEndpointUris("/connect/userinfo");
            //         
            //
            //         // Mark the "email", "profile" and "roles" scopes as supported scopes.
            //         options.RegisterScopes(OpenIddictConstants.Scopes.Email, OpenIddictConstants.Scopes.Profile,
            //             OpenIddictConstants.Scopes.Roles);
            //
            //         // Note: this sample only uses the authorization code flow but you can enable
            //         // the other flows if you need to support implicit, password or client credentials.
            //         options.AllowAuthorizationCodeFlow().RequireProofKeyForCodeExchange();
            //         options.AllowClientCredentialsFlow();
            //         options.AllowPasswordFlow();
            //         options.AllowRefreshTokenFlow();
            //
            //         // Register the signing and encryption credentials.
            //         options.AddDevelopmentEncryptionCertificate();
            //         //     .AddDevelopmentSigningCertificate();
            //
            //         // Encryption and signing of tokens
            //         options.AddEphemeralEncryptionKey()
            //             .AddEphemeralSigningKey();
            //
            //         options.RegisterScopes(ApplicationConstants.Scopes.MobileApplication);
            //         options.RegisterScopes(ApplicationConstants.Scopes.AtmApplication);
            //         options.RegisterScopes(ApplicationConstants.Scopes.AdminApplication);
            //
            //         options.SetAccessTokenLifetime(TimeSpan.FromMinutes(15));
            //         options.SetIdentityTokenLifetime(TimeSpan.FromMinutes(15));
            //         options.SetRefreshTokenLifetime(TimeSpan.FromHours(1));
            //
            //         // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
            //         options.UseAspNetCore()
            //             //todo remove the disable transport layer security
            //             .DisableTransportSecurityRequirement()
            //             .EnableAuthorizationEndpointPassthrough()
            //             .EnableLogoutEndpointPassthrough()
            //             .EnableTokenEndpointPassthrough()
            //             .EnableUserinfoEndpointPassthrough()
            //             .EnableStatusCodePagesIntegration();
            //
            //         options.DisableAccessTokenEncryption();
            //     })
            //     .AddValidation(options =>
            //     {
            //         // Import the configuration from the local OpenIddict server instance.
            //        options.UseLocalServer();
            //        
            //        // For applications that need immediate access token or authorization
            //        // revocation, the database entry of the received tokens and their
            //        // associated authorizations can be validated for each API call.
            //        // Enabling these options may have a negative impact on performance.
            //        options.EnableAuthorizationEntryValidation();
            //        options.EnableTokenEntryValidation();
            //        
            //         // Register the ASP.NET Core host.
            //         options.UseAspNetCore();
            //     });
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            // services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            //     {
            //         // options.Tokens.ChangePhoneNumberTokenProvider =
            //         //     ApplicationIdentityConstants.TokenProviders.PhoneNumber;
            //         options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //         options.Lockout.AllowedForNewUsers = true;
            //         options.Lockout.MaxFailedAccessAttempts = 5;
            //     })
            //     .AddEntityFrameworkStores<ApplicationDbContext>()
            //     .AddDefaultTokenProviders();
            //
            // services.Configure<IdentityOptions>(options =>
            // {
            //     // the values we assign here to claim type should be the same value we use when retrieving id or username
            //     //
            //     options.ClaimsIdentity.UserNameClaimType = OpenIddictConstants.Claims.Name;
            //     options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
            //     options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
            //     options.Password.RequireDigit = true;
            //     options.Password.RequiredLength = 6;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = false;
            //     options.Password.RequireLowercase = false;
            //     // options.SignIn.RequireConfirmedPhoneNumber = true;
            //     // options.User.RequireUniqueEmail = true;
            //     // options.SignIn.RequireConfirmedEmail = true;
            //     // options.SignIn.RequireConfirmedAccount = true;
            // });
            //
            // services.Configure<DataProtectionTokenProviderOptions>(opt =>
            //     opt.TokenLifespan = TimeSpan.FromMinutes(5));
            //
            // //checks if users are logged in every 3 minute
            // services.Configure<SecurityStampValidatorOptions>(options =>
            // {
            //     options.ValidationInterval = TimeSpan.FromMinutes(3);
            // });
        }
    }
}