using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MineralSlimes.NPCs
{
	public class IronSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
		}

		public override void SetDefaults()
		{
			npc.width = 44;
			npc.height = 32;
            npc.aiStyle = 1;
			npc.damage = 15;
			npc.defense = 15;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.alpha = 25;
			npc.value = 100f;
            npc.knockBackResist = -100f;
			npc.buffImmune[BuffID.Poisoned] = true;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return NPC.downedBoss3 ? SpawnCondition.Cavern.Chance * 0.1f : 0;
		}

        public override void PostAI()
        {
            if (Main.rand.Next(0, 15) == 0)
            {
                int dustIndex = Dust.NewDust(npc.Center, npc.width, npc.height, 245, 0, 0, 254, default, 0.25f);
                Main.dust[dustIndex].velocity *= 0.1f;
            }
        }
    }
}
