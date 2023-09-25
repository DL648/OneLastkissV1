using Microsoft.Xna.Framework;
using OneLastkiss.Items;
using Terraria;
using Terraria.ModLoader;
using OneLastkiss;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel.DataAnnotations;
using OneLastkiss.System;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace OneLastkiss.Projectles
{
    internal class DadaliaMainProjct : OneLastKissProjctle
    {
        public int KissTime = 0;
        public int ShootTime = 30;
        public Texture2D texture_Ranged = null;
        public Texture2D texture_Melee = null;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 18;
            Projectile.height = 40;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 60;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            State = StateType.Ranged;
            texture_Ranged = Mod.Assets.Request<Texture2D>("Projectles/DadaliaMainProjct").Value;
            texture_Melee = Mod.Assets.Request<Texture2D>("Projectles/DadaliaMelee").Value;
        }
        public override void AI()
        {
            base.AI();

            Projectile.rotation = (Main.MouseWorld - Projectile.Center).ToRotation();
            if (player.HeldItem.type == ModContent.ItemType<Dadalia>())
            {
                Projectile.timeLeft = 60;
            }
            if (player.channel)
            {
                player.itemTime = 10;
                player.itemAnimation = 10;
                if (State == StateType.Ranged)
                {
                    Projectile.Center = Vector2.Lerp(Projectile.Center, player.Center + Vector2.Normalize(Main.MouseWorld - player.Center) * 50f, 0.1f);

                    KissTime++;
                    if (KissTime == ShootTime)
                    {
                        KissTime = 0;
                        Vector2 pos = Projectile.Center + Vector2.Normalize(Main.MouseWorld - Projectile.Center) * 30f;
                        Vector2 vel = Vector2.Normalize(Main.MouseWorld - player.Center) * 20f;
                        Projectile.NewProjectile(
                            null, pos, vel,
                            ModContent.ProjectileType<DadaliaRangedProjct>(),
                            player.HeldItem.damage, player.HeldItem.knockBack);

                        if (ShootTime > 10) ShootTime--;
                    }
                }
            }
            else
            {
                Projectile.Center = Vector2.Lerp(Projectile.Center, player.Center + new Vector2(0, -50), 0.1f);

                KissTime = 0;
                ShootTime = 30;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 E_pos = new Vector2(Projectile.Center.X - Projectile.width*4,Projectile.Center.Y-Projectile.height);
            String E_str = "E:" +(int)(Time_E/60f); 
            Terraria.Utils.DrawBorderString(Main.spriteBatch,E_str, E_pos - Main.screenPosition, Color.BlueViolet);
            if (State == StateType.Ranged)
            {
                Main.EntitySpriteDraw(texture_Ranged, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, Projectile.Size/2, 1, SpriteEffects.None);
            }
            if (State == StateType.Melee)
            {
                Main.EntitySpriteDraw(texture_Melee, Projectile.Center - Main.screenPosition, null, Color.White, (float)(Projectile.rotation+MathHelper.PiOver4), Projectile.Size/2, 1, SpriteEffects.None);
            }
            return false;
        }
        public override void StateAi()
        {
            if (State == StateType.Melee)
            {
                if (Time_E < 45f * 60)
                {
                    Time_E++;
                }
                else
                {
                    State = StateType.Ranged;
                }
            }
            if (State == StateType.Ranged && Time_E > 0)
            {
                Time_E--;
            }
        }
        public override void SetState()
        {
            base.SetState();
            if (OneLastKissSystem.Skill_Mouse2.JustPressed&&player.HeldItem.type==ModContent.ItemType<Dadalia>())
            {
                if (State == StateType.Ranged && Time_E == 0)
                {
                    Time_E = 7f * 60f;
                    State = StateType.Melee;
                    Projectile.width = 32;
                    Projectile.height = 32;
                    CombatText.NewText(Projectile.getRect(),Color.White,"势如狂澜");
                }
                else if (State == StateType.Melee)
                {
                    State = StateType.Ranged;
                    Projectile.width = 18;
                    Projectile.height = 40;
                    CombatText.NewText(Projectile.getRect(), Color.White, "呼");
                }
            }
        }
    }
}
