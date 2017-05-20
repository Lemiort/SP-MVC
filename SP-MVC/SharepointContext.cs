using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SP_MVC
{
    public class SharepointContext:IDisposable
    {
        ClientContext _context = new ClientContext(__sharepointUrl);
        static string __sharepointUrl => ConfigurationManager.AppSettings["SharepointUrl"];

        /*Web web = clientContext.Web;
        List siteUserInfoList = web.SiteUserInfoList;
        CamlQuery query = new CamlQuery();
        query.ViewXml = "";
                IEnumerable<ListItem> itemColl = clientContext.LoadQuery(siteUserInfoList.GetItems(query));
        clientContext.ExecuteQuery();
                foreach (var item in itemColl)
                {
                    Console.WriteLine("ID:{0}  Email:{1} Title:{2}",item.Id,item["EMail"],item["Title"]);
                }*/

    public IEnumerable<ListItem> GetUserCollection()
        {
            List siteUserInfoList = _context.Web.SiteUserInfoList;
            CamlQuery query = new CamlQuery();
            query.ViewXml = "";
            IEnumerable<ListItem> itemColl = _context.LoadQuery(siteUserInfoList.GetItems(query));
            _context.ExecuteQuery();

            return itemColl;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~SharepointContext() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        void IDisposable.Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}