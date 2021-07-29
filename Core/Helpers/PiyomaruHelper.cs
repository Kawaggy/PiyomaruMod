using Terraria;
using PiyomaruMod.Common;

namespace PiyomaruMod.Core.Helpers
{
    public static partial class PiyomaruHelper
    {
        public static PiyomaruPlayer Piyomaru(this Player player)
        {
            return player.GetModPlayer<PiyomaruPlayer>();
        }
    }
}
