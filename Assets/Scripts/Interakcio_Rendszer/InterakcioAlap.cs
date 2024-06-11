using JatekosInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JatekosInput
{
    public class InterakcioAlap : MonoBehaviour, IInterakcio
    {
            public float nyomasIdo;
            public bool nyomvaInterakcio;
            public bool tobbszoriHasznalat;
            public bool isInteraktalhato;
            public string t_Felirat="Hasznal";

        public float NyomasIdo => nyomasIdo;

        public bool NyomvaInterakcio => nyomvaInterakcio;
        public bool TobbszoriHasznalat => tobbszoriHasznalat;
        public bool IsInteraktalhato => isInteraktalhato;

        public string Felirat => t_Felirat;
        public virtual void OnInterakcio()
        {
            Debug.Log("Interakcio"+gameObject.name);
        }
    }
}
