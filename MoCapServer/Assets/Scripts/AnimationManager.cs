using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    public Animator anim; //Variable del animator

   

    public GameObject InterfazPrin;

    public GameObject InterfazPrinBtnAbout;

    public GameObject InterfazUno;
    //public GameObject imgBlock1;
    //public GameObject botonCerrarScroll1;
    //public GameObject imgInstruc1;
    public GameObject ScrollView1Interface1;
    public GameObject ScrollView2Interface1;
    public GameObject ScrollView3Interface1;
    public GameObject ScrollView4Interface1;

    public GameObject InterfazDos;
    public GameObject ScrollView1Interface2;
    public GameObject ScrollView2Interface2;
    public GameObject ScrollView3Interface2;
    public GameObject ScrollView4Interface2;

    public GameObject InterfazTres;
    public GameObject ScrollView1Interface3;
    public GameObject ScrollView2Interface3;
    public GameObject ScrollView3Interface3;
    public GameObject ScrollView4Interface3;

    public GameObject InterfazCuatro;
    public GameObject ScrollView1Interface4;
    public GameObject ScrollView2Interface4;
    public GameObject ScrollView3Interface4;
    public GameObject ScrollView4Interface4;

    public GameObject interfaceMinority;

    public GameObject interfaceInstrucciones;

    private float tiempoGiro;
    private float tiempoSaludar;
    private float tiempoInteraccion;

    private Button _button;

    private int estado = 0;

    private bool unaVez = false;

    private int usuario = 0;

    // Lista de booleanos que representan si los sonidos de introducción y askMe fueron reproducidos
    bool[] played = { false, false, false, false, false, false, false, false };

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();

    }

    //si no hay usuarios 
    public void inicializar()
    {
        //inicializa las variables de ButtonTest
        PlayerPrefs.SetInt("principal", 1);
        PlayerPrefs.SetInt("principal2", 1);

        tiempoGiro = 0;
        tiempoSaludar = 0;
        tiempoInteraccion = 0;

        unaVez = false;
        usuario = 0;

        interfaceMinority.SetActive(true);

        anim.SetBool("isReiciniar", true);

        anim.SetBool("isGiro", false);
        anim.SetBool("isSaludar", false);
        anim.SetBool("isInteraccion", false);
        anim.SetBool("isSelect1", false);
        anim.SetBool("isSelect2", false);
        anim.SetBool("isSelect3", false);
        anim.SetBool("isSelect4", false);

       

        played[0] = false;
        played[1] = false;
        played[2] = false;
        played[3] = false;


        InterfazPrin.SetActive(true);

        interfaceInstrucciones.SetActive(false);
        interfaceInstrucciones.GetComponent<animacionInstrucciones>().nada();

        InterfazPrinBtnAbout.SetActive(false);
        InterfazPrin.transform.Find("Button4").GetComponent<Button>().interactable = true;
        InterfazPrin.transform.Find("Button3").GetComponent<Button>().interactable = true;
        InterfazPrin.transform.Find("Button2").GetComponent<Button>().interactable = true;
        InterfazPrin.transform.Find("Button1").GetComponent<Button>().interactable = true;
        InterfazPrin.transform.Find("Button5").GetComponent<Button>().interactable = true;

        ScrollView1Interface1.SetActive(false);
        ScrollView2Interface1.SetActive(false);
        ScrollView3Interface1.SetActive(false);
        ScrollView4Interface1.SetActive(false);
        InterfazUno.SetActive(false);

        ScrollView1Interface2.SetActive(false);
        ScrollView2Interface2.SetActive(false);
        ScrollView3Interface2.SetActive(false);
        ScrollView4Interface2.SetActive(false);
        InterfazDos.SetActive(false);

        ScrollView1Interface3.SetActive(false);
        ScrollView2Interface3.SetActive(false);
        ScrollView3Interface3.SetActive(false);
        ScrollView4Interface3.SetActive(false);
        InterfazTres.SetActive(false);

        ScrollView1Interface4.SetActive(false);
        ScrollView2Interface4.SetActive(false);
        ScrollView3Interface4.SetActive(false);
        ScrollView4Interface4.SetActive(false);
        InterfazCuatro.SetActive(false);


        transform.Find("Canvas").gameObject.SetActive(false);



        estado = 0;
    }


    public void intro()
    {
        interfaceMinority.SetActive(false);

        if (unaVez == false)
        {
            estado = 1;
            anim.SetBool("isGiro", true);
            anim.SetBool("isSaludar", false);
            anim.SetBool("isReiciniar", false);

            interfaceInstrucciones.SetActive(true);
            interfaceInstrucciones.GetComponent<animacionInstrucciones>().instrucPiso();
        }

        usuario = 1;
    }

    public void saludar()
    {
        unaVez = true;

        anim.SetBool("isGiro", false);
        anim.SetBool("isSaludar", true);        
    }

    public void interaccion()
    {
        anim.SetBool("isSaludar", false);
        anim.SetBool("isInteraccion", true);

        interfaceInstrucciones.GetComponent<animacionInstrucciones>().instrucBtn();
    }

    public void interfacePunoScroll()
    {
        interfaceInstrucciones.GetComponent<animacionInstrucciones>().instrucScroll();
    }

    public void interface1()
    {
        estado = 4;

        anim.SetBool("isInteraccion", false);
        anim.SetBool("isSelect1", true);       
    }

    public void interface2()
    {
        estado = 5;

        anim.SetBool("isInteraccion", false);
        anim.SetBool("isSelect2", true);
    }

    public void interface3()
    {
        estado = 6;

        anim.SetBool("isInteraccion", false);
        anim.SetBool("isSelect3", true);
    }

    public void interface4()
    {
        estado = 7;

        anim.SetBool("isInteraccion", false);
        anim.SetBool("isSelect4", true);
    }

    public void interaccion2()
    {
        anim.SetBool("isSelect1", false);
        anim.SetBool("isSelect2", false);
        anim.SetBool("isSelect3", false);
        anim.SetBool("isSelect4", false);
        anim.SetBool("isInteraccion", true);
    }

    // Update is called once per frame
    void Update ()
    {
        //print(usuario);

        //animacion de giro
        if (estado == 1)
        {
            tiempoGiro = tiempoGiro + Time.deltaTime;
            if (tiempoGiro > 3)
            {
                saludar();
                estado = 2;
            }
        }
        //animacion de saludar
        else if (estado == 2)
        {
            if (!transform.Find("SaludoInicial").GetComponent<AudioSource>().isPlaying && !played[3])
            {
                transform.Find("SaludoInicial").GetComponent<AudioSource>().Play();
                played[3] = true;
            }
            else if (!transform.Find("SaludoInicial").GetComponent<AudioSource>().isPlaying && played[3])
            {
                tiempoSaludar = tiempoSaludar + Time.deltaTime;

                if (tiempoSaludar >= 1 && tiempoSaludar < 2)
                {
                    //se coloca esto para saber si sigue habiendo un usuario o no, es decir se en adelante sigue en 0 es porque no hay nadie, pero si hay un usuario seguri siendo usuario igual a 1
                    usuario = 0;
                }

                if (tiempoSaludar > 2)
                {
                    if (usuario == 1)
                    {
                        //pasa a la animacion de interaccion
                        interaccion();
                        estado = 3;
                    }
                    else if (usuario == 0)
                    {
                        //Pasa la animacion inicial idle
                        inicializar();
                    }
                }
            }

                
        }
        //animacion de interaccion
        else if (estado == 3)
        {
           /* if (!transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying && !played[0])
            {
                transform.Find("Dinamic").GetComponent<AudioSource>().Play();
                played[0] = true;
            }
            else if (!transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying && played[0])
            { */
                //activa los botones para interactuar
                transform.Find("Canvas").gameObject.SetActive(true);
             //   played[1] = true;
            //}

            tiempoInteraccion = tiempoInteraccion + Time.deltaTime;

            if (tiempoInteraccion >= 7 && tiempoInteraccion <= 8)
            {
                //se coloca esto para saber si sigue habiendo un usuario o no, es decir se en adelante sigue en 0 es porque no hay nadie, pero si hay un usuario seguri siendo usuario igual a 1
                usuario = 0;
            }

            if (tiempoInteraccion > 9)
            {
                if (usuario == 0)
                {
                    //Pasa la animacion inicial idle
                    inicializar();
                }
                tiempoInteraccion = 0;
            }
        }

        //animacion de interface
        else if (estado == 4)
        {
            //if (!transform.Find("Interfaz1").GetComponent<AudioSource>().isPlaying && !played[2])
            //{
                //transform.Find("Interfaz1").GetComponent<AudioSource>().Play();
               // played[2] = true;
            //}
            //else if (!transform.Find("Interfaz1").GetComponent<AudioSource>().isPlaying && played[2])
            //{
                interaccion2();
                estado = 3;
            //}           
        }

        //animacion de interface
        else if (estado == 5)
        {
            /*if (!transform.Find("Interfaz2").GetComponent<AudioSource>().isPlaying && !played[2])
            {
                transform.Find("Interfaz2").GetComponent<AudioSource>().Play();
                played[2] = true;
            }
            else if (!transform.Find("Interfaz2").GetComponent<AudioSource>().isPlaying && played[2])
            {*/
                interaccion2();
                estado = 3;
            //}
        }

        //animacion de interface
        else if (estado == 6)
        {
            /*if (!transform.Find("Interfaz3").GetComponent<AudioSource>().isPlaying && !played[2])
            {
                transform.Find("Interfaz3").GetComponent<AudioSource>().Play();
                played[2] = true;
            }
            else if (!transform.Find("Interfaz3").GetComponent<AudioSource>().isPlaying && played[2])
            {*/
                interaccion2();
                estado = 3;
           // }
        }

        //animacion de interface
        else if (estado == 7)
        {
            /*if (!transform.Find("Interfaz4").GetComponent<AudioSource>().isPlaying && !played[2])
            {
                transform.Find("Interfaz4").GetComponent<AudioSource>().Play();
                played[2] = true;
            }
            else if (!transform.Find("Interfaz4").GetComponent<AudioSource>().isPlaying && played[2])
            {*/
                interaccion2();
                estado = 3;
            //}
        }


        if (Input.GetKey(KeyCode.W))
        {
            intro();

            /*
            transform.Find("Canvas").gameObject.SetActive(true);

            InterfazPrin.SetActive(false);
            InterfazUno.SetActive(true);*/
        
        }

    }
}
