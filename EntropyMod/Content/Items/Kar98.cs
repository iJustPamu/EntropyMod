using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EntropyMod.Content.Items
{
    public class Kar98 : ModItem
    {


        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 58;
            Item.height = 20;
            Item.useTime = 42;
            Item.useAnimation = 42;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 14f;
            Item.useAmmo = AmmoID.Bullet;

            Item.crit = 6;
            Item.channel = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 2);
        }

        public override void HoldItem(Player player)
        {
            player.scope = true; // Esto activa el zoom si el jugador presiona Shift derecho
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Torch, 40);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Wood, 25);
            recipe2.AddIngredient(ItemID.LeadBar, 10);
            recipe2.AddIngredient(ItemID.Torch, 40);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
        
    }
}
