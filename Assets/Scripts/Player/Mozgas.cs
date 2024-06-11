using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JatekosInput {
    public class Mozgas : MonoBehaviour
    {
        public float gyorsasag;
        public CharacterController cc;
        public float gravitacio=-11f;
        public float ugrasMagassag=2.5f;

        public Transform talajCheck;
        public float talajTav = 0.3F;
        public LayerMask talajMaszk;
        public LayerMask interakcioMaszk;

        private Vector3 sebvektor;
        private bool isTalajon;
        private void FixedUpdate()
        {
            if (Physics.CheckSphere(talajCheck.position, talajTav, talajMaszk) || Physics.CheckSphere(talajCheck.position, talajTav, interakcioMaszk))
            {
                isTalajon = true;
            }
            else 
            {
                isTalajon = false;
            }
            
            if (isTalajon && sebvektor.y < 0)
            {
                sebvektor.y = -3.5f;
            }

            if (Input.GetKey(KeyCode.LeftShift) && isTalajon)
            {
                gyorsasag = 0.2f;
            }
            else
            {
                gyorsasag = 0.1f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 seta = transform.right * x + transform.forward * z;
            cc.Move(seta * gyorsasag);

            if (Input.GetKeyDown(KeyCode.Space) && isTalajon)
            {
                sebvektor.y = Mathf.Sqrt(ugrasMagassag * -2f * gravitacio);
            }
            ;
            sebvektor.y +=gravitacio* Time.deltaTime;
            cc.Move(sebvektor * Time.deltaTime);
        }
    }
}
