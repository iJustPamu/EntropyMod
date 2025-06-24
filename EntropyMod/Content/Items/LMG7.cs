using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace EntropyMod.Content.Items
{
    public class LMG7 : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 60;
            Item.height = 24;
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.reuseDelay = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1f;
            Item.value = Item.buyPrice(gold: 3);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            Item.noMelee = true;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.Bullet;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true; 
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) 
            {
                Item.useTime = 40;
                Item.useAnimation = 40;
                Item.reuseDelay = 20;
                Item.shoot = ProjectileID.Grenade;
                Item.useAmmo = AmmoID.None;
                Item.shootSpeed = 6f;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = false;
            }
            else 
            {
                Item.useTime = 8;
                Item.useAnimation = 8;
                Item.reuseDelay = 0;
                Item.shoot = ProjectileID.Bullet;
                Item.useAmmo = AmmoID.Bullet;
                Item.shootSpeed = 10f;
                Item.UseSound = SoundID.Item11;
                Item.autoReuse = true;
            }

            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source,
                                   Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10));
                    Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                }
                return false; 
            }

            return true; 
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 25);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Torch, 40);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }

}
