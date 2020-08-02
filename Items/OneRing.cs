using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OneRing.Items
{
	public class OneRing : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.width = 22;
			item.height = 44;

			item.value = 10000;
			item.rare = 3;
			item.defense = 6;
			item.accessory = true;
			item.consumable = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The One Ring");
			Tooltip.SetDefault("Triple all damage. Super speed. 10 minions. Many buffs.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedCrit += 90;
			player.meleeCrit += 90;
			player.magicCrit += 90;
			player.thrownCrit += 90;
			player.allDamageMult += 2f;
			player.maxMinions += 10;
			player.armorPenetration += 4000;
			player.manaCost = 0.5f;
			player.moveSpeed += 0.5f;
			player.accRunSpeed += 30f;
			player.maxRunSpeed += 0.1f;
			int[] array = new int[10]{1,2,4,6,8,9,11,12,15,17};
			foreach (int i in array)
			{
				player.AddBuff(i, 2, true);
			}
			Mod calamity = ModLoader.GetMod("CalamityMod");
			if (calamity != null)
			{
				ModBuff ceaselessHunger = calamity.GetBuff("CeaselessHunger");
				player.AddBuff(ceaselessHunger.Type, 2, true);
			}
			if (hideVisual)
			{
				player.longInvince = true;
				player.immuneTime = 2;
				player.endurance += 0.99f;
				player.statLifeMax2 += 500;
				player.statDefense += 9999;
				if (calamity != null)
				{
					ModBuff abyssalFlames = calamity.GetBuff("AbyssalFlames");
					ModBuff vulnerabilityHex = calamity.GetBuff("VulnerabilityHex");
					player.buffImmune[abyssalFlames.Type] = true;
					player.buffImmune[vulnerabilityHex.Type] = true;
				}
			}
		}

		public override bool UseItem(Player player)
		{
			Item item = player.inventory[0];
			if (item == null)
			{
				return false;
			}
			player.QuickSpawnClonedItem(item, item.stack);
			return true;
		}	

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
