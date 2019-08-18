using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MineralSlimes.NPCs
{
	public class SaltwaterSlime : ModNPC
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
			npc.buffImmune[BuffID.Poisoned] = true;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return SpawnCondition.OceanMonster.Chance * 0.1f;
		}

        public override bool PreAI()
        {
            npc.wet = false;
            return base.PreAI();
        }

        public override void PostAI()
        {
            Lighting.AddLight(npc.Center, 0.1f, 0.5f, 0.5f);
        }
    }
}
