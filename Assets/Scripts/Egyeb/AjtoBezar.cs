using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjtoBezar : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled=true;
        gameObject.GetComponent<MeshCollider>().isTrigger=false;
    }
}
