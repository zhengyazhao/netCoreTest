using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core.Iserver
{
   public interface IRabbitMqService:IMessageService,IConnectionServer
    {
    }
}
