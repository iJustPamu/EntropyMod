using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EntropyMod.Content.Items; 


namespace EntropyMod.Content.Items
{
    public class SMG : ModItem
    {
      

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 52;
            Item.height = 22;
            Item.useTime = 5; // Muy rápido
            Item.useAnimation = 30; // Controla la ráfaga
            Item.reuseDelay = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1f;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 0f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10); 
            recipe.AddIngredient(ModContent.ItemType<Items.EntropyScrap>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
