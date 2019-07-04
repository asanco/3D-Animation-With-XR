using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceInteraction : MonoBehaviour
{
    private Button _button;
    public GameObject vistaScrollMostar;
    public GameObject vistaScrollOcultar1;
    public GameObject vistaScrollOcultar2;
    public GameObject vistaScrollOcultar3;

    public GameObject Logic;


    public GameObject InterfaceAnterior;
    public GameObject InterfazActual;

   

    public GameObject imgInstruc;

    public ScrollRect myScrollRect;
    public Scrollbar newScrollBar;


    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.SetInt("principal2", 0);

        _button = GetComponent<Button>();

        GameObject professor = (Logic.GetComponent<Logic2>().Professors);

        if (_button.name == "Atras")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
                imgInstruc.GetComponent<animacionInstrucciones>().instrucBtn();

                vistaScrollMostar.SetActive(false);
                vistaScrollOcultar1.SetActive(false);
                vistaScrollOcultar2.SetActive(false);
                vistaScrollOcultar3.SetActive(false);

                InterfaceAnterior.SetActive(true);
                InterfazActual.SetActive(false);


                PlayerPrefs.SetInt("principal", 1);
            });
        }

        if (_button.name == "Btn1")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
                professor.GetComponent<AnimationManager>().interfacePunoScroll();

                myScrollRect.normalizedPosition = new Vector2(0, 1);

                vistaScrollMostar.SetActive(true);
                vistaScrollOcultar1.SetActive(false);
                vistaScrollOcultar2.SetActive(false);
                vistaScrollOcultar3.SetActive(false);
                
            });
        }

        if (_button.name == "Btn2")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
                professor.GetComponent<AnimationManager>().interfacePunoScroll();

                myScrollRect.normalizedPosition = new Vector2(0, 1);

                vistaScrollMostar.SetActive(true);
                vistaScrollOcultar1.SetActive(false);
                vistaScrollOcultar2.SetActive(false);
                vistaScrollOcultar3.SetActive(false);
                
            });
        }

        if (_button.name == "Btn3")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
                professor.GetComponent<AnimationManager>().interfacePunoScroll();

                myScrollRect.normalizedPosition = new Vector2(0, 1);

                vistaScrollMostar.SetActive(true);
                vistaScrollOcultar1.SetActive(false);
                vistaScrollOcultar2.SetActive(false);
                vistaScrollOcultar3.SetActive(false);
                
            });
        }

        if (_button.name == "Btn4")
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
                professor.GetComponent<AnimationManager>().interfacePunoScroll();

                myScrollRect.normalizedPosition = new Vector2(0, 1);

                vistaScrollMostar.SetActive(true);
                vistaScrollOcultar1.SetActive(false);
                vistaScrollOcultar2.SetActive(false);
                vistaScrollOcultar3.SetActive(false);
                
            });
        }


    }


    void Update()
    {
        if (PlayerPrefs.GetInt("principal2") == 1)
        {

            vistaScrollMostar.SetActive(false);
            vistaScrollOcultar1.SetActive(false);
            vistaScrollOcultar2.SetActive(false);
            vistaScrollOcultar3.SetActive(false);
           

            //PlayerPrefs.SetInt("ScrollActivo", 0);
            PlayerPrefs.SetInt("principal2", 0);
        }
    }



    }
