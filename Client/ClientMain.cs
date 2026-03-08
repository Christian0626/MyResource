using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace MyResource.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Hi from MyResource.Client!");
            
        }

        [Tick]
        public Task OnTick()
        {
            

            string resource_name = "MyResource";
            string resourceState = GetResourceState(resource_name);

            if(resourceState.Equals("started", StringComparison.OrdinalIgnoreCase))
            {
                
               //SetPlayerWantedLevel(LocalPlayer.ServerId, 0, false);
               if(LocalPlayer.WantedLevel > 0) {
                    SetMaxWantedLevel(0);
                    SetPlayerWantedLevel(Game.Player.Handle, 0, false);
                    SetPlayerWantedLevelNow(Game.Player.Handle, false);
                } 
               

                if(IsControlJustPressed(0, 51))
                {
                    Debug.WriteLine("V has been pressed");
                    GiveWeaponToPed(GetPlayerPed(-1), ((uint)WeaponHash.RayPistol), 5000, false, true);
                }



            }
            

            return Task.FromResult(0);
        }
    }
}