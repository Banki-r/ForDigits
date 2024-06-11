using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JatekosInput
{
    public class InterakcioFog : InterakcioAlap
    {
        public override void OnInterakcio()
        {
            base.OnInterakcio();

            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.transform.parent = GameObject.Find("FogCel").transform;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.transform.parent = null;
            }
        }
    }
}
