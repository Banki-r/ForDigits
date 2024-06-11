using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JatekosInput
{
    [CreateAssetMenu(fileName = "InterakcioAdat", menuName = "InterakcioRendszer/InterakcioAdat")]
    public class InterakcioAdat : ScriptableObject
    {
        private InterakcioAlap interaktalhatoObjektum;

        public InterakcioAlap Interaktalhato {
            get => interaktalhatoObjektum;
            set => interaktalhatoObjektum = value;
        }

        public void Interakcio() {
            interaktalhatoObjektum.OnInterakcio();
            ResetAdat();
        }

        public bool UgyanazInteraktalhato(InterakcioAlap ujInteraktalhato) => interaktalhatoObjektum == ujInteraktalhato;
        public bool IsUres() => interaktalhatoObjektum == null;

        public void ResetAdat() => interaktalhatoObjektum = null;
    }
}
