using ImoStatemiddleware.Data.AuthenticationModel;
using ImoStatemiddleware.Utility.EntityClass;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ImoStatemiddleware.BussinessLogic
{
    public class AccessAuthentication
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public AccessAuthentication() { }

        internal bool AuthenticateAccess(string[] auth, string clientIP)
        {
            var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;
            AuthenticationRequest authenticationRequest = new AuthenticationRequest();
            authenticationRequest.AppID = auth[0];
            authenticationRequest.Appkey = auth[1];
            authenticationRequest.ClientIP = clientIP;
            GeneralEntity generalEntity = new GeneralEntity();
            return generalEntity.isClientAuthenticated(authenticationRequest) ? true : false;
        }
    }
}
