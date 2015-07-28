using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuf
{

    public enum RemoteServers
    {
        JEANVALJEAN,
        JAVERT,
        COSETTE
    }

    public class RemoteObjectAttribute : Attribute
    {
        
        public RemoteObjectAttribute(RemoteServers server)
        {
            this.server = server;
        }
        private RemoteServers server;
        public RemoteServers Server
        {
            get { return server; }
            set { server = value; }
        }
    }

    [RemoteObject(RemoteServers.COSETTE)]
    class MyRemotableClass
    {
            static void Main(string[] args)
            {

                Type type = typeof(MyRemotableClass);

                foreach (Attribute attr in type.GetCustomAttributes(false))
                {
                    RemoteObjectAttribute remoteAttr = attr as RemoteObjectAttribute;
                    if (remoteAttr != null)
                    {
                        Console.WriteLine("Create this object on" + remoteAttr.Server);
                    }
                }

                Console.Read();
          }
    }


}
