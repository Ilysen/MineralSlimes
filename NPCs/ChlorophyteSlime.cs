using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MineralSlimes.NPCs
{
	public class ChlorophyteSlime : ModNPC
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
			npc.damage = 60;
			npc.defense = 20;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.alpha = 25;
			npc.value = 500f;
			npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return NPC.downedPlantBoss ? SpawnCondition.HardmodeJungle.Chance * 0.1f : 0;
		}

        public override void PostAI()
        {
            if (npc.life < npc.lifeMax)
            {
                npc.life += 1;
            }
            Lighting.AddLight(npc.Center, 0.75f, 0.5f, 0.1f);
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            base.ModifyHitPlayer(target, ref damage, ref crit);
            target.AddBuff(BuffID.Venom, !Main.expertMode ? 300 : 420);
        }
    }
}
