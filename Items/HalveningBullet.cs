using Terraria.ID;
using Terraria.ModLoader;

namespace OneRing.Items
{
    public class HalveningBullet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Halvening Bullet");
            Tooltip.SetDefault("Halvening enemy's life");
        }

        public override void SetDefaults() {
            item.damage = 1;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.maxStack = 1;
            item.consumable = false;
            item.knockBack = 2f;
            item.value = 76000;
            item.rare = 6;
            item.shoot = mod.ProjectileType("HalveningBullet");
            item.shootSpeed = 3.5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}