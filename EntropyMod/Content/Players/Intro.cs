using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TuMod.Players
{
    public class Intro : ModPlayer
    {
        private bool firstJoin = true;
        private bool showWelcomeMessage = false;
        private int messageTimer = 0;

        public override void OnEnterWorld()
        {
            if (firstJoin)
            {
                Main.NewText("Bienvenido, aventurero...", 200, 200, 255); // Color azul claro
                showWelcomeMessage = true;
                messageTimer = 0;
                firstJoin = false;
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag["firstJoin"] = firstJoin;
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("firstJoin"))
            {
                firstJoin = tag.GetBool("firstJoin");
            }
        }

        public override void PostUpdate()
        {
            if (showWelcomeMessage)
            {
                messageTimer++;
                if (messageTimer == 180) // 3 segundos (60 FPS * 3)
                {
                    Main.NewText("El mundo que está ante ti es una prueba que debes superar.", 255, 180, 100); // Color dorado suave
                    showWelcomeMessage = false;
                }
            }
        }
    }
}