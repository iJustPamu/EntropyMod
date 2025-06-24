using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EntropyMod.Content.Items; 

namespace EntropyMod.Content.Items.Accesories
{
    public class SolarisRing : ModItem
    {
      
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 5);
            Item.defense = 4; 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Melee) += 10f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ModContent.ItemType<EntropyScrap>(), 10); 
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
