using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JatekosInput
{
    public class InterakcioKodlap : InterakcioAlap
    {
        public GameObject panel;
        public Text jegyzet;
        public int kodSzama;

        private string jegyzetFelirat;
        private string felirat;
        
        private void Start()
        {
            string[] kodok = Kod.szamok;
            jegyzetFelirat = kodok[kodSzama];
        }

        public override void OnInterakcio()
        {
            base.OnInterakcio();
            felirat = t_Felirat;
            t_Felirat = "";
            jegyzet.text = jegyzetFelirat;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && t_Felirat == "")
            {
                t_Felirat = felirat;
                jegyzet.text = "";
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
