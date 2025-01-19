using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace changedmod.Content.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class MaleDarkLatex : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

			NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Werewolf;
		}

		public override void SetDefaults() {
			NPC.width = 18;
			NPC.height = 45;
			NPC.damage = 25;
			NPC.defense = 8;
			NPC.lifeMax = 360;
			NPC.HitSound = SoundID.NPCHit6;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic

			AIType = NPCID.Mummy; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
			AnimationType = NPCID.Zombie; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			// Since Party Zombie is essentially just another variation of Zombie, we'd like to mimic the Zombie drops.
			// To do this, we can either (1) copy the drops from the Zombie directly or (2) just recreate the drops in our code.
			// (1) Copying the drops directly means that if Terraria updates and changes the Zombie drops, your ModNPC will also inherit the changes automatically.
			// (2) Recreating the drops can give you more control if desired but requires consulting the wiki, bestiary, or source code and then writing drop code.

			// (1) This example shows copying the drops directly. For consistency and mod compatibility, we suggest using the smallest positive NPCID when dealing with npcs with many variants and shared drop pools.
			var zombieDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.Zombie, false); // false is important here
			foreach (var zombieDropRule in zombieDropRules) {
				// In this foreach loop, we simple add each drop to the PartyZombie drop pool. 
				npcLoot.Add(zombieDropRule);
			}

			// (2) This example shows recreating the drops. This code is commented out because we are using the previous method instead.
			// npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50)); // Drop shackles with a 1 out of 50 chance.
			// npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 250)); // Drop zombie arm with a 1 out of 250 chance.

			// Finally, we can add additional drops. Many Zombie variants have their own unique drops: https://terraria.fandom.com/wiki/Zombie
			npcLoot.Add(ItemDropRule.Common(ItemID.Confetti, 100)); // 1% chance to drop Confetti
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Overworld.Chance * 0.2f; // Spawn with 1/5th the chance of a regular zombie.
		}

		public override void AI() {
			if (NPC.wet) {
				if (NPC.honeyWet) { // Removes the effects of honey's fall rate making the NPC fall normally in honey
					NPC.GravityMultiplier /= NPC.GravityWetMultipliers[LiquidID.Honey];
					NPC.MaxFallSpeedMultiplier /= NPC.MaxFallSpeedWetMultipliers[LiquidID.Honey];
				}
				else if (!NPC.lavaWet && !NPC.shimmerWet) { // Removes water falls speed effects, then adds honey falls speed effects, making the NPC fall at the honey rate in water
					NPC.GravityMultiplier *= NPC.GravityWetMultipliers[LiquidID.Honey] / NPC.GravityWetMultipliers[LiquidID.Water];
					NPC.MaxFallSpeedMultiplier *= NPC.MaxFallSpeedWetMultipliers[LiquidID.Honey] / NPC.MaxFallSpeedWetMultipliers[LiquidID.Water];
				}
			}
			
		}

		

		public override void HitEffect(NPC.HitInfo hit) {
			// Spawn confetti when this zombie is hit.

			for (int i = 0; i < 10; i++) {
				int dustType = Main.rand.Next(139, 143);
				var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

				dust.velocity.X += Main.rand.NextFloat(-0.05f, 0.05f);
				dust.velocity.Y += Main.rand.NextFloat(-0.05f, 0.05f);

				dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
			}
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
			// Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
			// Common use is applying buffs/debuffs:

			
			// Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

			 //This makes it 5 seconds, one second is 60 ticks
			
		}

		public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers) {
			if (modifiers.DamageType.CountsAsClass(DamageClass.Magic)) {
				// This example shows how PartyZombie reduces magic damage by 75%. We use FinalDamage here rather than SourceDamage since we are affecting how the npc reacts to the damage.
				// Conceptually, the source dealing the damage isn't interpreted as weaker, but rather this NPC has a resistance to this damage source.
				modifiers.FinalDamage *= 0.25f;
			}
		}
	}
}
