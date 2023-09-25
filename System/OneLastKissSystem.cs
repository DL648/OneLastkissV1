using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace OneLastkiss.System
{
    public class OneLastKissSystem : ModSystem
    {
        public static ModKeybind Skill_Mouse2 { get; private set; }
        public static ModKeybind Skill_Q { get; private set; }
        public override void Load()
        {
            Skill_Mouse2 = KeybindLoader.RegisterKeybind(Mod, "元素战技", "Mouse2");
            Skill_Q = KeybindLoader.RegisterKeybind(Mod, "元素爆发", "Q");
        }
        public override void Unload()
        {
            Skill_Mouse2  = null;
            Skill_Q = null;
        }
    }
}
