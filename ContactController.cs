using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using System.Collections.Generic ;
using DotNetNuke.Entities.Users;
using System.Linq;
using DotNetNuke.Entities.Portals;

namespace VignaharaServices
{
    public class ContactController : DnnApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public List<Contact> GetContacts(int pId)
        {
            int portalID = PortalController.Instance.GetCurrentPortalSettings().PortalId;
            List<Contact> uiList = new List<Contact>() ;

            foreach (UserInfo ui in UserController.GetUsers(portalID)) {
                uiList.Add(new Contact() {  UserID=ui.UserID, 
                                            DisplayName=ui.DisplayName,
                                            Email = ui.Email,
                                            UserName = ui.Username });
            }

            return uiList ;
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
