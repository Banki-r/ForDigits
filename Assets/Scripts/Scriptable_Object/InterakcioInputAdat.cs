using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JatekosInput {
    [CreateAssetMenu(fileName = "InterakcioInputAdat", menuName = "InterakcioRendszer/InputAdat")]
    public class InterakcioInputAdat : ScriptableObject
    {
        private bool interakcioKatt;
        private bool interakcioElenged;
        public bool InterakcioKatt
        {
            get => interakcioKatt;
            set => interakcioKatt = value;
        }
        public bool InterakcioElenged
        {
            get => interakcioElenged;
            set => interakcioElenged = value;
        }

        public void VisszaInput()
        {
            interakcioKatt = false;
            interakcioElenged = false;
        }
    }
}
