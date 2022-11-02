using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 10000);
            Debug.Log("?");
        }
    }
}
