using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiADSL.Arc;

namespace XiADSL.Web
{
    public class WebUser : IUser
    {
        public string Name { get; private set; }
        public string LoginName { get; private set; }
        public int Id { get; private set; }
        public string[] Roles { get; private set; }
        public bool HasRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    public class WebLog : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class WebContext : IContext
    {
        public IUser User { get; private set; }
        public ILogger Logger { get; private set; }
    }
}