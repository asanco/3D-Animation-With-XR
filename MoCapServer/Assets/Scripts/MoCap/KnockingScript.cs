using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockingScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("knocking");
        FindObjectOfType<SoundManager>().Play("knock");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("knocking");
        FindObjectOfType<SoundManager>().Play("knock");
    }
}
