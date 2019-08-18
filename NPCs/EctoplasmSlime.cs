using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MineralSlimes.NPCs
{
	public class EctoplasmSlime : ModNPC
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
			npc.damage = 70;
			npc.defense = 35;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.alpha = 25;
			npc.value = 500f;
			npc.buffImmune[BuffID.Poisoned] = true;
            aiType = NPCID.DungeonSlime;
            animationType = NPCID.BlueSlime;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            if (!NPC.downedPlantBoss)
            {
                return 0;
            }
            return SpawnCondition.Dungeon.Chance * 0.1f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int i = 0; i < 40; i++)
                {
                    int deathDust = Dust.NewDust(npc.position, npc.width, npc.height, 180, npc.velocity.X, npc.velocity.Y, 0, default, 1.4f);
                    Main.dust[deathDust].noGravity = true;
                }
            }
        }

        public override void PostAI()
        {
            Lighting.AddLight(npc.Center, 0.7f, 0.85f, 0.9f);
            int deathDust = Dust.NewDust(npc.position, npc.width, npc.height, 180, default, 1.4f);
            Main.dust[deathDust].noGravity = true;
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            base.ModifyHitPlayer(target, ref damage, ref crit);
            target.AddBuff(BuffID.ManaSickness, !Main.expertMode ? 300 : 420);
        }
    }
}
