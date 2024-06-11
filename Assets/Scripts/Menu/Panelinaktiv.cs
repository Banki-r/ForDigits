using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panelinaktiv : MonoBehaviour
{
    private GameObject panel;
    private void Awake()
    {
        panel = this.gameObject;
        panel.SetActive(false);
    }
}
