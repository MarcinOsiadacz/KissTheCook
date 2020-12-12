using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.Helpers
{
    public static class Extensions
    {
        public static bool IsEquivalentTo(this IList<int> a, IList<int> b)
        {
            return (a.Count == b.Count) && !a.Except(b).Any();
        }
    }
}
