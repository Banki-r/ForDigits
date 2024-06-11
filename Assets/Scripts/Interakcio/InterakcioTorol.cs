using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JatekosInput
{
    public class InterakcioTorol : InterakcioAlap
    {
        public override void OnInterakcio()
        {
            base.OnInterakcio();
            Destroy(gameObject);
        }
    }
}
