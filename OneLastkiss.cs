using OneLastkiss.Items;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OneLastkiss
{
	public class OneLastkiss : Mod
	{

	}
	public class OnePlayer : ModPlayer 
	{
        public override void OnEnterWorld()
        {
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            return false;

        }
    }
	
}