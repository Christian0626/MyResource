using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.NaturalMotion;
using Mono.CSharp;
using static CitizenFX.Core.Native.API;
using MenuAPI;

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


        

           

                //SetPlayerWantedLevel(LocalPlayer.ServerId, 0, false);
                if (LocalPlayer.WantedLevel > 0)
                {
                    SetMaxWantedLevel(0);
                    SetPlayerWantedLevel(Game.Player.Handle, 0, false);
                    SetPlayerWantedLevelNow(Game.Player.Handle, false);
                }

                Vehicle[] vehicles = World.GetAllVehicles();
                Vector3 playerPos = LocalPlayer.

                if (vehicles != null && vehicles.Length > 0)
                {
                    Vehicle closestCar = World.GetClosest<Vehicle>(playerPos, vehicles);
                    Debug.WriteLine(closestCar.DisplayName);
                }
                


                int handle = 0;
                bool isAiming = API.GetEntityPlayerIsFreeAimingAt(Game.Player.Handle, ref handle);
                
                
                if (isAiming && handle != 0)
                {
                    Entity entity = Entity.FromHandle(handle);
                    if (entity is Vehicle vehicle)
                    {
                        vehicle.ApplyForce(Vector3.Up, Vector3.Zero, ForceType.MaxForceRot);
                        Debug.WriteLine(vehicle.DisplayName);
                    }
                }
                    




                if (LocalPlayer.GetTargetedEntity() != null)
                {
                    
                    Entity entity = LocalPlayer.GetTargetedEntity();
                    if (entity is Ped ped)
                    {
                        ped.Ragdoll(5000, RagdollType.Normal);
                        ped.ApplyForce(Vector3.Up, Vector3.Zero, ForceType.MaxForceRot2);
                    }
                }
                else
                {

                }

                /*
                if (LocalPlayer.Character.IsInVehicle())
                {
                    if (vehicle.Speed * 2.23694f > 60 && vehicle.HasCollided)
                    {
                        TaskLeaveVehicle(GetPlayerPed(-1), vehicle.Handle, 16);
                    }
                }
                */


                if (IsControlJustPressed(0, 51))
                {
                    LocalPlayer.Character.Ragdoll(5000, RagdollType.Normal);
                    API.GiveWeaponToPed(LocalPlayer.Character.Handle, (uint)WeaponHash.AssaultShotgun, 2000, false, true);
                    //Menu menu = new Menu("Test Menu");
                    //MenuController.AddMenu(menu);
                    //menu.Visible = true;

                }



            
                return Task.FromResult(0);

            
        }
    }
}