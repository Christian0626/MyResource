using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace MyResource.Server
{
    
    public class ServerMain : BaseScript
    {
        public void RegisterCommand()
        {
            
        }
    
        public ServerMain()
        {
            Debug.WriteLine("Hi from MyResource.Server!");
            
            
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");
        }


        


    }
}