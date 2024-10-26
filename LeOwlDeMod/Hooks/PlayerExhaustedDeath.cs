using System;
using UnityEngine;

namespace LeOwlDeMod.Hooks
{
    public class PlayerExhaustedDeath
    {
        internal static void PlayerControllerB_Update(Action<GameNetcodeStuff.PlayerControllerB> original, GameNetcodeStuff.PlayerControllerB self)
        {
            // Code here runs before the original method
            original(self); // Call the original method with its arguments
                        // Code here runs after the original method

            // isExhausted is a boolean field of PlayerControllerB which
            // is set to true after running out of stamina. 
            if (self.isExhausted)
            {
                // KillPlayer is a method of PlayerControllerB which
                // kills the player instance.
                // This method takes in multiple arguments, but the only
                // required argument is the velocity as a Vector3 for the
                // spawned dead body object, which we'll specify as zero.
                self.KillPlayer(Vector3.zero);
            }
        }
    }
}
