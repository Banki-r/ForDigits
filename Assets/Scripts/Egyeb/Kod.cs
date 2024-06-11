using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JatekosInput
{
    public class Kod : MonoBehaviour
    {
        public static string[] szamok;

        public static int kodSzam;

        public void Awake()
        {
            kodSzam = 4;
            szamok = new string[kodSzam];
            for (int j = 0; j < kodSzam; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    szamok[j] += Random.Range(0, 10);
                }
            }
        }

    }
}
