using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestNugetCore5.Models;

namespace TestNugetCore5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly ITokenAcquisition _tokenAcquisition;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
            //ITokenAcquisition tokenAcquisition
        {
            _logger = logger;
            _configuration = configuration;
            //_tokenAcquisition = tokenAcquisition;
        }

        public IActionResult Index()
        {
            //var token = _tokenAcquisition.GetAccessTokenForUserAsync(new string[] { "User.ReadBasic.All", "User.Read" }).Result;
            //GraphServiceClient graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0",
            //new DelegateAuthenticationProvider(
            //    request =>
            //    {
            //        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            //        return Task.CompletedTask;
            //    }));

            //var usersList = graphClient.Users.Request().Select(x => x.DisplayName).GetAsync().Result;

            var clientId = _configuration.GetValue<string>("AzureAd:ClientId");
            var tenantId = _configuration.GetValue<string>("AzureAd:TenantId");
            var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");
            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredential);
            var users = graphServiceClient.Users.Request().Select(x => x.DisplayName).GetAsync().Result;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
