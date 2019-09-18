using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.ArabicView;
using ObjectHelper;
using BALHelper;
using CommonHelper;
using System.Windows.Forms;

namespace BumedianBM.ViewHelper
{
   public class ServerConnViewHelper
    {

       public string server;
       public  string UserId ;
        public string password;
       
       LoginBALHelper objBalClass;
        
       public ServerConnViewHelper()
       {
         //  From = from;
           objBalClass = new LoginBALHelper();
           objBalClass.SetCommonObject();
        

       }

       public LoginBALHelper ObjBalClass
       {
           get { return objBalClass; }
           set { objBalClass = value; }
       }

       public List<string> GetActiveServers()
       {
           return objBalClass.GetActiveServers();
       }
       public List<string> GetServerDatabases()
       {
            
           return objBalClass.GetServerDatabases(server, UserId, password);
       }

      public void CheckTechConn()
      {
          if (objBalClass.CheckActiveConnection(server, UserId, password))
          {
              GeneralFunction.Information("ConnectionSucceeded", ActionType.DBConnection.ToString());
          }
          else
          {
              GeneralFunction.Information("ConnectionFailed", ActionType.DBConnection.ToString());
          }
      }

      public bool SaveConnection()
      {
          if (objBalClass.ObjLoginObject.Database == string.Empty)
          {
              GeneralFunction.Information("SelectDBName", ActionType.DBConnection.ToString());
              return false;
          }
          else if (objBalClass.CheckActiveConnection(server, UserId, password))
          {
              //Obj_Dal.LogOut_User(GeneralFunction.UserId);
              string database=objBalClass.ObjLoginObject.Database;
              System.Collections.Generic.Dictionary<string, string> hshConfig = new System.Collections.Generic.Dictionary<string, string>();
              hshConfig.Add("Server", objBalClass.ObjLoginObject.Server);
              hshConfig.Add("Database", objBalClass.ObjLoginObject.Database);
              hshConfig.Add("UserId", objBalClass.ObjLoginObject.UName);
              hshConfig.Add("Password", objBalClass.ObjLoginObject.Password);
              GeneralFunction.SetConfigValue(hshConfig);
              //GeneralFunction.SetConnection(server,UserId,password,database);
              return true;
          }
          else
              return false;
      }
      
    }
}
