using System;
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
        private int _portalID = PortalController.Instance.GetCurrentPortalSettings().PortalId;

        [HttpGet]
        [DnnAuthorize(StaticRoles = "Administrators")]
        public HttpResponseMessage GetContacts(int pId)
        {
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

            return Request.CreateResponse(HttpStatusCode.OK,(from c in crm.Vignahara_Contact where c.PortalID == _portalID select c)) ;
        }

        [HttpGet]
        [DnnAuthorize(StaticRoles = "Administrators")]
        public HttpResponseMessage GetUsers()
        {
            List<DNNUser> userList = new List<DNNUser>() ;
            foreach (UserInfo ui in UserController.GetUsers(_portalID)) {
                userList.Add(new DNNUser() {
                    DisplayName = ui.DisplayName,
                    Email = ui.Email,
                    UserID = ui.UserID,
                    UserName = ui.Username,
                    LastModifiedByUserID = ui.LastModifiedByUserID,
 
                }) ;
            } ;
            
            return Request.CreateResponse(HttpStatusCode.OK,  userList);
        }


        public class DNNUser
        {
            public int UserID { get; set; }
            public string DisplayName { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public DateTime LastModifiedOnDate { get; set; }
            public int LastModifiedByUserID { get; set; }
        }
    }
}
