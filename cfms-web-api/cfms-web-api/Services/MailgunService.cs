﻿using cfms_web_api.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

namespace cfms_web_api.Services
{
	public class MailgunService : IMailService
    {
        private readonly string _ApiKey;
        private readonly string _Domain;

        public MailgunService(IConfiguration configuration)
        {
            _ApiKey = configuration["Mailgun:ApiKey"];
            _Domain = configuration["Mailgun:Domain"];
        }

        public RestResponse SendMessage(string to, string subject, string message)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", _ApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", _Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@" + _Domain + ">");
            request.AddParameter("to", "<"+to+">");
            request.AddParameter("subject", subject);
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }
    }
}

