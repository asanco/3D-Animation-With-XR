using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramaRota : MonoBehaviour {

    public GameObject holograma;

    // Update is called once per frame
    void Update ()
    {
        // transform.Rotate(Vector3.left * Time.deltaTime * 30);
        transform.Rotate(Vector3.forward * Time.deltaTime * 30);
    }
}
