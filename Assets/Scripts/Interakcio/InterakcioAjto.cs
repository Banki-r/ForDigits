using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace JatekosInput
{
    public class InterakcioAjto : InterakcioAlap
    {
        public GameObject panel;
        public Text text;
        public InputField ifd;

        private string szoveg;
        private string szam;
        private int i;
        private static string[] szamok;

        private void Start()
        {
           //szamok = Kod.szamok;
            i = int.Parse(this.gameObject.name.Substring(this.gameObject.name.Length - 1));
            i--;
            szamok = Kod.szamok;
            szam = szamok[i];
            i++;
            Debug.Log(szam);
        }

        public override void OnInterakcio()
        {
            //for (int j = 0; j < szamok.Length; j++)
            //{
            //    Debug.Log(szamok[j]);
            //}
            base.OnInterakcio();

            Time.timeScale = 0f;
            panel.SetActive(true);
            ifd.ActivateInputField();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                enterLenyomasakor();
            }
        }

        private void enterLenyomasakor()
        {
            szoveg = text.text;
            bool logikai = Physics.CheckSphere(this.gameObject.transform.position, 10f,LayerMask.GetMask("Jatekos"));
            if (szoveg.Equals(szam) && logikai) //ajtó kinyílik
            {
                Time.timeScale = 1f;
                panel.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                Time.timeScale = 1f;
                panel.SetActive(false);
            }

            
        }

    }
}