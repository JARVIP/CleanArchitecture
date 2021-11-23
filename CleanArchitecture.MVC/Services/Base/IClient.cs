using System.Net.Http;

namespace CleanArchitecture.MVC.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
