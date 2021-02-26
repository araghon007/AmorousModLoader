using Amorous.Mod;
using Amorous.Mod.NPC;
using Amorous.Engine.NPC;
using Microsoft.Xna.Framework;

namespace araghon007.AmorousTestMod.NPC
{
    public class Stickman : ModLayerNPC<Stickman.Heads, Stickman.Poses, Stickman.Clothes>
    {

        // Token: 0x06000A85 RID: 2693 RVA: 0x00027364 File Offset: 0x00025564
        public Stickman(_ReSMQinwfLqHErTI2lafWxQJw9B gameInstance, ModLoader modLoader) : base(gameInstance, modLoader, "Assets/NPC/Stickman", 1f)
        {
            AddBody(Poses.Default, "Stickman");
            AddHead(Heads.Default, "Default");
            AddHead(Heads.Angry, "Angry");
            Size = 0.4f;
            HitboxWidth = 1411;
            HitboxHeight = 1602;
            _ECOYBw818Ua5A2IhfOUNAeQZBEq = false;
            _yMYmd4GkbImedw3LbbzcSKDjh4sA = true;
        }

        // Token: 0x06000B0C RID: 2828 RVA: 0x00028DB8 File Offset: 0x00026FB8
        public override void _pedFGoqAIjRhB9Jo0miZgSOTbKs()
        {
            base._pedFGoqAIjRhB9Jo0miZgSOTbKs();
            SetHead(Heads.Default);
            SetBody(Poses.Default);
        }

        public override void _obvu1L6KrxGqH1z2XacOoFxfneg(NPCLocation location)
        {
            base._obvu1L6KrxGqH1z2XacOoFxfneg(location);
            switch (location)
            {
                case NPCLocation.Middle:
                    Size = 1f;
                    Flip = true;
                    X = 240f;
                    Y = 50f;
                    return;
                case NPCLocation.Left:
                    Size = 0.85f;
                    Flip = true;
                    X = -300f;
                    Y = 50f;
                    return;
                case NPCLocation.Right:
                    Size = 0.85f;
                    Flip = false;
                    X = 990f;
                    Y = 50f;
                    return;
                default:
                    return;
            }
        }

        // Token: 0x02000179 RID: 377
        public enum Heads
        {
            // Token: 0x0400050C RID: 1292
            Default,
            Angry
        }

        // Token: 0x0200017A RID: 378
        public enum Poses
        {
            Default
        }

        // Token: 0x0200017B RID: 379
        public enum Clothes
        {
            Default
        }
	}
}
