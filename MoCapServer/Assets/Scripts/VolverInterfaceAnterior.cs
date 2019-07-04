using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolverInterfaceAnterior : MonoBehaviour
{
    private Button _button;

    public GameObject InterfazActual;
    public GameObject scroll1;
    public GameObject scroll2;
    public GameObject scroll3;
    public GameObject scroll4;

    public GameObject imgBlock;
    public GameObject botonCerrarScroll;
    public GameObject imgInstruc;

    /*public ScrollRect myScrollRect1;
    public Scrollbar newScrollBar1;
    public ScrollRect myScrollRect2;
    public Scrollbar newScrollBar2;
    public ScrollRect myScrollRect3;
    public Scrollbar newScrollBar3;
    public ScrollRect myScrollRect4;
    public Scrollbar newScrollBar4;*/


    void Start ()
    {
        _button = GetComponent<Button>();



        if (_button.name == "Atras1")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
               /* myScrollRect1.normalizedPosition = new Vector2(0, 1);
                myScrollRect2.normalizedPosition = new Vector2(0, 1);
                myScrollRect3.normalizedPosition = new Vector2(0, 1);
                myScrollRect4.normalizedPosition = new Vector2(0, 1);  */

                InterfazActual.transform.Find("Atras").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Btn1").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Btn2").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Btn3").GetComponent<Button>().interactable = true;
                InterfazActual.transform.Find("Btn4").GetComponent<Button>().interactable = true;
                scroll1.SetActive(false);
                scroll2.SetActive(false);
                scroll3.SetActive(false);
                scroll4.SetActive(false);
                imgBlock.SetActive(false);
                botonCerrarScroll.SetActive(false);
                imgInstruc.SetActive(false);
                //PlayerPrefs.SetInt("ScrollActivo", 0);

               // scrollPos1.position.y = 0;
            });
        }

    }
	
}
