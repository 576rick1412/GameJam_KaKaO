using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daruma : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndHammer"))
        {
            transform.localScale = new Vector3(1.3f,0.2f,1.3f);
        }
    }
}
