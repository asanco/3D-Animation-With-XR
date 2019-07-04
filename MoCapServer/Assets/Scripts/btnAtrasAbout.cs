using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAtrasAbout : MonoBehaviour
{

    private Button _button;

    public GameObject InterfazActual;

    // Use this for initialization
    void Start()
    {
        _button = GetComponent<Button>();

        if (_button.name == "Atras2")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
                InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Button5").GetComponent<Button>().interactable = true;
            });
        }
    }

    // Update is called once per frame
   /* void Update()
    {

        

    }*/
}
