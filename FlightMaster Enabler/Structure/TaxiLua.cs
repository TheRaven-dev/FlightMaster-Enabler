using robotManager.Helpful;
using System;
using System.Collections.Generic;
using System.Linq;
using wManager.Wow.Helpers;

namespace FlightMaster_Enabler.Structure
{
    internal class TaxiLua
    {
        private static bool TaxiFrame()
        {
            return Lua.LuaDoString<bool>("return TaxiFrame:IsVisible();");
        }

        private static List<String> FatchAllFlightPaths()
        {
            return Lua.LuaDoString<List<String>>(@"local FlightPointsTable = {}
                                                    for i = 0, NumTaxiNodes() do
                                                        local Points = TaxiNodeName(i);
                                                        tinsert(FlightPointsTable, Points..'^');
                                                    end
                                                    return unpack(FlightPointsTable);".Replace("FlightPointsTable", Others.GetRandomString(Others.Random(3, 8))));
        }

        public static List<string> FatchInfo()
        {
            List<String> FlightPaths = new List<string>();
            if(TaxiFrame())
            {
                var _FlightIndex = FatchAllFlightPaths();
                foreach (var i in _FlightIndex)
                {
                    var info = i.Split('^');
                    if (!info.Contains("INVALID"))
                    {
                        FlightPaths.Add(info[0]);
                    }
                }
            }
            return FlightPaths;
        }

    }
}
