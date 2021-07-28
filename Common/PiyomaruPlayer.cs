using Terraria.ModLoader;

namespace PiyomaruMod.Common
{
    public partial class PiyomaruPlayer : ModPlayer
    {
        public bool niwa;

        internal void Reset()
        {
            niwa = false;
        }

        public override void ResetEffects()
        {
            Reset();
        }

        public override void UpdateDead()
        {
            Reset();
        }

        public override void Initialize()
        {
            Reset();
        }
    }
}
