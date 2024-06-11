using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nezes : MonoBehaviour
{
    public float egerErzekenyseg = 100f;
    public Transform jatekosTest;
    private float xRotacio = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*egerErzekenyseg*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*egerErzekenyseg*Time.deltaTime;

        xRotacio -= mouseY;
        xRotacio = Mathf.Clamp(xRotacio,-60f,60f);

        jatekosTest.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotacio, 0f, 0f);
    }
}
