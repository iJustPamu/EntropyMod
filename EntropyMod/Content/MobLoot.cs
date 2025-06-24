using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using EntropyMod.Content.Items; 

namespace TuMod.NPCs.Loot
{
    public class SlimeLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // Verifica si el NPC es un slime usando su AIStyle
            if (npc.aiStyle == 1 && npc.lifeMax <= 100 && npc.damage <= 40)
            {
                // Agrega drop con 3% de probabilidad
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EntropyScrap>(), 55)); 
            }
        }
    }
}
