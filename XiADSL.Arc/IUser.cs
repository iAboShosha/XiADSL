using System;
using System.Collections.Generic;
using System.Text;

namespace XiADSL.Arc
{
    public interface IUser
    {
        string Name { get; }
        string LoginName { get; }
        int Id { get; }

        string[] Roles { get; }

        bool HasRole(string role);

    }
}
