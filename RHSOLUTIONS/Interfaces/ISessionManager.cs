using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMIVRH.Interfaces
{
    public interface ISessionManager
    {
        void Set(string key, string value);
        string Get(string key);
    }
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }
    }
}
