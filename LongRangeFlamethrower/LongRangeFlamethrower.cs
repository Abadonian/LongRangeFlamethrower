using RoR2;
using BepInEx;

namespace LongRangeFlamethrower {
    // Make sure r2api is listed as a dependency
    [BepInDependency("com.bepis.r2api")]
    // Convention for mod title is either "com.<Username>.<ModName> or <Username>.<ModName>"
    [BepInPlugin("Abadonian.LongRangeFlamethrower", "Long Range Flamethrower", "1.0.0")]

    public class LongRangeFlamethrower : BaseUnityPlugin {
        // Happens immediately after initialization
        public void Awake() {
            // Output a debug message to in game chat
            Chat.AddMessage("Loaded Long Range Flamethrower");
            // When the mage would normally use flamethrower, first multiple the distance by 5
            On.EntityStates.Mage.Weapon.Flamethrower.OnEnter += (orig,self) => {
                self.maxDistance *= 5;
                // Run original method after the first part is done
                orig(self);
            };
        }
    }
}