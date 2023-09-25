using Microsoft.Xna.Framework;
using OneLastkiss.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using OneLastkiss.System;

namespace OneLastkiss.Projectles
{
    abstract class OneLastKissProjctle : ModProjectile
    {
        public Player player { get { return Main.player[Projectile.owner]; }}
        public StateType State;
        public static float Time_E = 0;
        public static float Time_Q = 0;
        public enum StateType
        {
            Melee = 1,
            Ranged = 2,
            Magic = 3
        }
        public virtual void SetState()
        {
            StateAi();
        }
        public virtual void StateAi()
        {

        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            State =StateType.Melee;
        }
        public override void AI()
        {
            SetState();
            
            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            Vector2 E_pos = new Vector2(Projectile.Center.X - Projectile.width, Projectile.Center.Y);
           // Main.EntitySpriteDraw()
        }
    }
}
