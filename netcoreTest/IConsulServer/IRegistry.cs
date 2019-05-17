using System;
using System.Collections.Generic;
using System.Text;

namespace IConsulServer
{
    public interface IRegistry : IHealthCheck, IReginConsul
    {
    }
}
