using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using OneLastkiss.Projectles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Terraria.DataStructures;

namespace OneLastkiss.Items
{
    internal class Dadalia : OneLastKissItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 22;
            Item.height = 32;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 10;
            Item.knockBack = 5;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.channel = true;
            Item.noMelee = true;
            Item.useTurn = true;
            Item.noUseGraphic = true;
        }
        public override void HoldItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<DadaliaMainProjct>()] < 1)
            {
                Projectile.NewProjectileDirect(
                    null,
                    player.Center,
                    Vector2.Zero,
                    ModContent.ProjectileType<DadaliaMainProjct>(),
                    0, 0
                    );
                CombatText.NewText(player.getRect(), Color.White, "真让我好等");

            }
        }
    }
}
