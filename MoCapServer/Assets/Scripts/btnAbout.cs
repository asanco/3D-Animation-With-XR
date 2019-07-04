using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAbout : MonoBehaviour
{
    private Button _button;

    public GameObject Interface;
    //public GameObject botonAtras;

    public GameObject InterfazActual;

    // Use this for initialization
    void Start ()
    {
        Interface.SetActive(false);
       // botonAtras.SetActive(false);

        _button = GetComponent<Button>();

        if (_button.name == "Button5")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
               /* InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = false;
                InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = false;
                InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = false;
                InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = false;
                InterfazActual.transform.Find("Button5").GetComponent<Button>().interactable = false;*/

                Interface.SetActive(true);
              //  botonAtras.SetActive(true);
            });
        }
    }
	
}
