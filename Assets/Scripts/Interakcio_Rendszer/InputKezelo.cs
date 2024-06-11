using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JatekosInput {
    public class InputKezelo : MonoBehaviour
    {
        public GameObject panel;
        public InterakcioInputAdat interakcioInputAdat;

        private bool kurzor = false;
        private void Start()
        {
            interakcioInputAdat.VisszaInput();
        }
        private void Update()
        {
            GetInterakcioInputAdat();
            ESCMenu();
        }
        private void GetInterakcioInputAdat() {
            interakcioInputAdat.InterakcioKatt = Input.GetKeyDown(KeyCode.E);
            interakcioInputAdat.InterakcioElenged = Input.GetKeyUp(KeyCode.E);
        }

        private void ESCMenu() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                kurzor = true;
                panel.SetActive(true);
                //Debug.Log("MENÜÜÜ");
                Cursor.lockState = CursorLockMode.None;
            }
            if (Time.timeScale==1f)
            {
                Cursor.lockState = CursorLockMode.Locked;
                panel.SetActive(false);
                kurzor = false;
            }
            Cursor.visible = kurzor;
        }
    }
}
