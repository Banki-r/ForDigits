using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JatekosInput
{
    public class InterakcioKontroll : MonoBehaviour
    {
        public InterakcioInputAdat interakcioInputAdat;
        public InterakcioAdat interakcioAdat;

        public InterakcioUIPanel uiPanel;

        public float rayTavolsag;
        public float rayGombSugar;
        public LayerMask interaktalhatoLayer;

        private Camera kamera;
        private bool interakt_e;
        private float tartIdo = 0f;

        private void Awake()
        {
            kamera = FindObjectOfType<Camera>();
        }
        private void Update()
        {
            InteraktalhatoKereses();
            InteraktalhatoInputKereses();
        }

        private void InteraktalhatoKereses() 
        {
            Ray ray = new Ray(kamera.transform.position, kamera.transform.forward);
            RaycastHit talalatInfo;

            bool talaltValamit = Physics.SphereCast(ray,rayGombSugar,out talalatInfo,rayTavolsag,interaktalhatoLayer);

            if (talaltValamit)
            {
                InterakcioAlap interaktalhato = talalatInfo.transform.GetComponent<InterakcioAlap>();
                if (interaktalhato!=null && (interakcioAdat.IsUres() || !interakcioAdat.UgyanazInteraktalhato(interaktalhato)))
                {
                    interakcioAdat.Interaktalhato = interaktalhato;
                    uiPanel.SetFelirat(interaktalhato.Felirat);
                }
            }
            else
            {
                uiPanel.ResetUI();
                interakcioAdat.ResetAdat();
            }
        }
        private void InteraktalhatoInputKereses()
        {
            if (interakcioAdat.IsUres())
            {
                return;
            }
            if (interakcioInputAdat.InterakcioKatt)
            {
                interakt_e = true;
                tartIdo = 0f;
            }

            if (interakcioInputAdat.InterakcioElenged)
            {
                interakt_e = false;
                tartIdo = 0f;
                uiPanel.MutatoFrissit(0f);
            }
            if (interakt_e)
            {
                if (!interakcioAdat.Interaktalhato.IsInteraktalhato)
                {
                    return;
                }
                if (interakcioAdat.Interaktalhato.nyomvaInterakcio)
                {
                    tartIdo += Time.deltaTime;
                    float tartasSzazalek=tartIdo/interakcioAdat.Interaktalhato.nyomasIdo;
                    uiPanel.MutatoFrissit(tartasSzazalek);
                    if (tartasSzazalek>1f)
                    {
                        interakcioAdat.Interakcio();
                        interakt_e = false;
                    }
                }
                else
                {
                    interakcioAdat.Interakcio();
                    interakt_e = false;
                }
            }
        }
    }
}