using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MineralSlimes.NPCs
{
	public class TitanSlime : ModNPC
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
			npc.defense = 80;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 400f;
            npc.knockBackResist = -100f;
			npc.buffImmune[BuffID.Poisoned] = true;
            aiType = NPCID.ToxicSludge;
            animationType = NPCID.BlueSlime;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return NPC.downedMechBossAny ? SpawnCondition.Cavern.Chance * 0.1f : 0;
		}

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 146, 0f, 0f, 0, default, 1.5f);
            if (npc.life <= 0)
            {
                for (int i = 0; i < 25; i++)
                    Dust.NewDust(npc.position, npc.width, npc.height, 146, -npc.velocity.X, npc.velocity.Y, 0, default, 1f);
            }
        }

        public override void PostAI()
        {
            if (Main.rand.Next(0, 11) == 0)
            {
                int dustIndex = Dust.NewDust(npc.Center, npc.width, npc.height, 245, 0, 0, 254, default, 0.25f);
                Main.dust[dustIndex].velocity *= 0.1f;
            }
        }
    }
}
