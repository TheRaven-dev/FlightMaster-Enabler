using robotManager.Helpful;
using System;
using System.Collections.Generic;
using wManager.Wow.Helpers;

namespace FlightMaster_Enabler.Structure
{
    internal class FlightMasterEventHook
    {
        public static void Start()
        {
            EventsLuaWithArgs.OnEventsLuaStringWithArgs += _FlightMasterHook;
        }

        public static void Stop()
        {
            EventsLuaWithArgs.OnEventsLuaStringWithArgs += _FlightMasterHook;
        }


        private static void _FlightMasterHook(String LuaEvent, List<string> Args)
        {
            if (LuaEvent == "TAXIMAP_OPENED")
            {
                var GetFlightInfo = TaxiLua.FatchInfo();
                if(GetFlightInfo.Count > 0)
                {
                    foreach (var Nodes in Taxi.TaxiList.Nodes)
                    {
                        foreach (var Info in GetFlightInfo)
                        {
                            if(Nodes.Name == Info)
                            {
                                if(!Nodes.Active)
                                {
                                    Nodes.Active = true;
                                    Logging.Write($"Activating node {Nodes.Name}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
