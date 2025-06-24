using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EntropyMod.Content.Items
{
    public class EntropyScrap : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 15;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.White;
        }

         public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 5); 
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }

}