using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarRobot : MonoBehaviour
{

    public GameObject Robot;
    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= 5 && tiempo <= 7)
        {
            PlayerPrefs.SetInt("iniciarAnimacion", 0);
            Robot.transform.Rotate(Vector3.up * Time.deltaTime * 40);
        }

        if (tiempo >= 14 && tiempo <= 18)
        {
            Robot.transform.Rotate(Vector3.down * Time.deltaTime * 20);
        }


        if (tiempo >= 25 && tiempo <= 29)
        {
            Robot.transform.Rotate(Vector3.down * Time.deltaTime * 20);
        }

        if (tiempo >= 42 && tiempo <= 46)
        {
            Robot.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }

        if (tiempo >= 80)
        {
            tiempo = 0;
            PlayerPrefs.SetInt("iniciarAnimacion", 1);
        }

    }   
}
