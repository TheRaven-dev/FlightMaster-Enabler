using FlightMaster_Enabler.Structure;
using wManager.Plugin;

public class Main : IPlugin
{
   
    public void Initialize()
    {
        FlightMasterEventHook.Start();
    }

    public void Settings()
    {
    }

    public void Dispose()
    {
        FlightMasterEventHook.Stop();
    }
}
