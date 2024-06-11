using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject panel;
    public Text jegyzet;

    private int futasok;

    private void Start()
    {
        futasok = 0;
        string jegyzetFelirat = "Az (A, W, S, D) gombok segítségével tudsz mozogni és Space-el ugrani.\n" +
            "E betűvel tudsz interakcióba lépni tárgyakkal.\n " +
            "Bal egérgombal meg be tudod fejezni bizonyos tárgyakkal az interakciót.\n" +
            "A kódot meg az ENTER billentyűvel tudod megerősiteni.\n\n\n" +
            "Ha mehet a játék nyomj egy bal egérgombot!";
        jegyzet.text = jegyzetFelirat;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && futasok <= 0)
        {
            futasok++;
            jegyzet.text = "";
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
