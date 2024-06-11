using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace JatekosInput
{
    public class InterakcioUIPanel : MonoBehaviour
    {
        public Image lenyomasMutato;
        public TextMeshProUGUI felirat;

        public void SetFelirat(string felirat)
        {
            this.felirat.SetText(felirat);
        }
        public void MutatoFrissit(float toltesMennyiseg)
        {
            lenyomasMutato.fillAmount = toltesMennyiseg;
        }
        public void ResetUI()
        {
            lenyomasMutato.fillAmount = 0f;
            felirat.SetText("");
        }

    }
}