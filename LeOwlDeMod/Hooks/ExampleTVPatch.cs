using System;

namespace LeOwlDeMod.Hooks
{
    public class ExampleTVPatch
    {
        internal static void SwitchTVPatch(Action<TVScript> original, TVScript self)
        {
            /*
             *  When the method is called, the TV will be turning off when we want to
             *  turn the lights on and vice-versa. At that time, the TV's tvOn field
             *  will be the opposite of what it's doing, ie it'll be on when turning off.
             *  So, we want to set the lights to what the tv's state was
             *  when this method is called.
             */
            StartOfRound.Instance.shipRoomLights.SetShipLightsBoolean(self.tvOn);

            // Call Original Method
            original(self);
        }
    }
}
