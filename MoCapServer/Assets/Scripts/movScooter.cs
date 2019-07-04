using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movScooter : MonoBehaviour
{
    public GameObject scooter;
    private float tiempo;
    private float estado;

    void Start()
    {
        estado = 0;
    }


    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;


        if (estado == 0)
        {
            if (tiempo >= 6 && tiempo <= 7)
            {
                scooter.transform.Translate(Vector3.back * Time.deltaTime * 0.4f);
            }
            else if (tiempo > 7)
            {
                estado = 1;
                tiempo = 0;
            }
        }
        else if (estado == 1)
        {
            if (tiempo < 1)
            {
                scooter.transform.Rotate(Vector3.up * Time.deltaTime * 100);
            }
            else if (tiempo > 6)
            {
                estado = 2;
                tiempo = 0;
            }
        }
        else if (estado == 2)
        {
            if (tiempo < 0.8)
            {
                scooter.transform.Rotate(Vector3.up * Time.deltaTime * 100);
            }
            else
            {
                estado = 3;
                tiempo = 0;
            }
        }
        else if (estado == 3)
        {
            if (tiempo < 3)
            {
                scooter.transform.Translate(Vector3.back * Time.deltaTime * 0.4f);
            }
            else
            {
                estado = 4;
                tiempo = 0;
            }
        }
        else if (estado == 4)
        {
            scooter.transform.position = new Vector3(35.3303f, 0.6673f, -9.713f);
            scooter.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (PlayerPrefs.GetInt("iniciarAnimacion")==1)
            {
                estado = 0;
                tiempo = 0;
            }
        }
    }
}


