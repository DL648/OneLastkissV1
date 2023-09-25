using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OneLastkiss.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace OneLastkiss.Projectles
{
    class DadaliaRangedProjct:OneLastKissProjctle
    {
        public Texture2D texture=null;
        public Vector2 Scale = new Vector2(1,2f);
        public override void SetDefaults()
        {
            Projectile.width = 3;
            Projectile.height = 3;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 120;
            texture = Mod.Assets.Request<Texture2D>("Projectles/DadaliaRangedProjct").Value;
        }
        public override void AI()
        {
            Projectile.rotation = (float)(Projectile.velocity.ToRotation() + Math.PI/2f);
            Player player = Main.player[Projectile.owner];
           
                       
          
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawpos = Projectile.Center - Main.screenPosition;
            Main.EntitySpriteDraw(texture, drawpos,null,Color.White,Projectile.rotation,Projectile.Size,Scale,SpriteEffects.None);
            lightColor = Color.White;
            Lighting.AddLight(Projectile.Center, new Vector3(0, 0.08f, 0.2f));
            return false;
        }
    }
}
