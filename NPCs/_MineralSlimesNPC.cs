using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MineralSLimes.NPCs
{
	public class MineralSlimeNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

        public override void NPCLoot(NPC npc)
        {
            int oreDropped = 0;
            int oreType = 0;
            if (npc.type == mod.NPCType("ChlorophyteSlime"))
            {
                oreDropped = !Main.expertMode ? Main.rand.Next(6, 19) : Main.rand.Next(18, 25);
                oreType = ItemID.ChlorophyteOre;
            }
            else if (npc.type == mod.NPCType("SaltwaterSlime"))
            {
                oreDropped = !Main.expertMode ? Main.rand.Next(5, 10) : Main.rand.Next(10, 15);
                switch (Main.rand.Next(0, 3))
                {
                    case 0:
                        oreType = ItemID.Starfish;
                        break;
                    case 1:
                        oreType = ItemID.Coral;
                        break;
                    case 2:
                        oreType = ItemID.Seashell;
                        break;
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 
                    Main.rand.Next(0, 2) == 1 ? ItemID.Shrimp : ItemID.RedSnapper, Main.rand.Next(1, 4));
            }
            else if (npc.type == mod.NPCType("EctoplasmSlime"))
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DungeonSpirit, 0, 0f, 0f, 0f, 0f, 255);
            }
            else if (npc.type == mod.NPCType("IronSlime"))
            {
                oreDropped = !Main.expertMode ? Main.rand.Next(15, 25) : Main.rand.Next(24, 34);
                switch (Main.rand.Next(0, 4))
                {
                    case 0:
                        oreType = ItemID.TinOre;
                        break;
                    case 1:
                        oreType = ItemID.LeadOre;
                        break;
                    case 2:
                        oreType = ItemID.TungstenOre;
                        break;
                    case 3:
                        oreType = ItemID.PlatinumOre;
                        break;
                }
            }
            else if (npc.type == mod.NPCType("TitanSlime"))
            {
                oreDropped = !Main.expertMode ? Main.rand.Next(15, 25) : Main.rand.Next(24, 34);
                switch (Main.rand.Next(0, 3))
                {
                    case 0:
                        oreType = ItemID.PalladiumOre;
                        break;
                    case 1:
                        oreType = ItemID.OrichalcumOre;
                        break;
                    case 2:
                        oreType = ItemID.TitaniumOre;
                        break;
                }
            }
            if (oreDropped > 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, oreType, oreDropped);
            }
        }
	}
}
