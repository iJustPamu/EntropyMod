using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EntropyMod.Content.Systems;

namespace EntropyMod.Content.Items
{
    public class Obliterator : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.width = 28;
            Item.height = 30;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item74;
        }

        public override bool CanUseItem(Player player)
        {
            return !WipeSystem.IsWiping;
        }

        public override bool? UseItem(Player player)
        {
            // Colocar dos bloques de ladrillo de oro bajo el jugador
            int px = (int)(player.Center.X / 16f);
            int py = (int)(player.Center.Y / 16f);

            WorldGen.PlaceTile(px, py + 1, TileID.GoldBrick, true, true);
            WorldGen.PlaceTile(px, py + 2, TileID.GoldBrick, true, true);

            WipeSystem.StartWipe(player);
            return true;
        }
    }
}
