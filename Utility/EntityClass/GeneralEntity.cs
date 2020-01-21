using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImoStatemiddleware.Data.AuthenticationModel;
using ImoStatemiddleware.Utility.DBContext;
using NLog;

namespace ImoStatemiddleware.Utility.EntityClass
{
    public class GeneralEntity
    {
        public GeneralEntity()
        { }

        Logger logger = LogManager.GetCurrentClassLogger();

        internal bool isClientAuthenticated(AuthenticationRequest authenticationRequest)
        {
            try
            {
                using (var db = new AuthenticationUtilityDBContext())
                {
                    //var rspVariable = db.AuthenticationRequests.Where(d => d.AppID == authenticationRequest.AppID && d.AppID == authenticationRequest.Appkey && d.ClientIP == authenticationRequest.ClientIP).FirstOrDefault();
                    var rspVariable = db.AuthenticationRequests.Where(d => d.AppID == authenticationRequest.AppID && d.Appkey == authenticationRequest.Appkey).FirstOrDefault();
                    return (rspVariable != null);
                }
            }
            catch (Exception ex)
            {
                logger.Error("isClientAuthenticated :" + ex.Message);
                return false;
            }
        }
    }
}
