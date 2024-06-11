using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JatekosInput
{
    public interface IInterakcio
    {
        float NyomasIdo { get; }

        bool NyomvaInterakcio { get; }
        bool TobbszoriHasznalat { get; }
        bool IsInteraktalhato { get; }

        string Felirat { get; }

        void OnInterakcio();
    }
}