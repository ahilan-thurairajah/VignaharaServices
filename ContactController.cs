using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using System.Collections.Generic ;
using DotNetNuke.Entities.Users;
using System.Linq;
using DotNetNuke.Entities.Portals;
using System.Data.Entity.Core.EntityClient;

namespace VignaharaServices
{
    public class ContactController : DnnApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public List<VignaharaServices.App_Code.User> GetContacts(int pId)
        {
            
            int portalID = PortalController.Instance.GetCurrentPortalSettings().PortalId;
            List<Contact> uiList = new List<Contact>() ;
            VignaharaServices.App_Code.VignaharaDNNEntities crm = new VignaharaServices.App_Code.VignaharaDNNEntities();
            /*
            DbConnectionHelper connHelper = new DbConnectionHelper();
            VignaharaDNNEntities crm = new VignaharaDNNEntities(connHelper.GetConnection().ConnectionString);
            foreach (UserInfo ui in UserController.GetUsers(portalID)) {


                uiList.Add(new Contact() {  UserID=ui.UserID, 
                                            DisplayName=ui.DisplayName,
                                            Email = ui.Email,
                                            UserName = ui.Username });
            }
            */

            //return connHelper.GetConnection().ConnectionString;

            return (from c in crm.Users select c).ToList() ;
        }

        public class Contact
        {
            public int UserID { get; set; }
            public string DisplayName { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }

        }
    }
}
