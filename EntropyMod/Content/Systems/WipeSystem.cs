using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace EntropyMod.Content.Systems
{
    public class WipeSystem : ModSystem
    {
        public static bool IsWiping = false;
        private static int wipeX = 0;
        private static int wipeY = 0;
        private static int playerX;
        private static int playerY;
        private const int blockSize = 64;

        public static void StartWipe(Player player)
        {
            if (IsWiping)
                return;

            wipeX = 0;
            wipeY = 0;
            playerX = (int)player.Center.ToTileCoordinates().X;
            playerY = (int)player.Center.ToTileCoordinates().Y;
            IsWiping = true;

            Main.NewText("Iniciando limpieza total del mundo...", 255, 100, 100);
        }

        public override void PostUpdateEverything()
        {
            if (!IsWiping)
                return;

            int worldWidth = Main.maxTilesX;
            int worldHeight = Main.maxTilesY;

            // Limpieza progresiva
            for (int x = wipeX; x < wipeX + blockSize && x < worldWidth; x++)
            {
                for (int y = wipeY; y < wipeY + blockSize && y < worldHeight; y++)
                {
                    Tile tile = Framing.GetTileSafely(x, y);

                    // Conservar ladrillos de oro
                    if (tile.HasTile && tile.TileType == TileID.GoldBrick)
                        continue;

                    tile.ClearEverything();
                }
            }

            wipeX += blockSize;
            if (wipeX >= worldWidth)
            {
                wipeX = 0;
                wipeY += blockSize;
            }

            if (wipeY >= worldHeight)
            {
                IsWiping = false;

                // Eliminar NPCs
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active)
                        Main.npc[i].active = false;
                }

                // Eliminar ítems
                for (int i = 0; i < Main.maxItems; i++)
                {
                    if (Main.item[i].active)
                        Main.item[i].TurnToAir();
                }

                // Eliminar líquidos
                for (int x = 0; x < worldWidth; x++)
                {
                    for (int y = 0; y < worldHeight; y++)
                    {
                        Main.tile[x, y].LiquidAmount = 0;
                    }
                }

                // ✅ Forzar regeneración del minimapa completa
                Main.mapMinX = 0;
                Main.mapMaxX = Main.maxTilesX;
                Main.mapMinY = 0;
                Main.mapMaxY = Main.maxTilesY;
                Main.refreshMap = true;

                Main.NewText("Mundo limpiado con éxito.", 100, 255, 100);
            }
        }
    }
}
