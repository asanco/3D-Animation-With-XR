using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ButtonTest : MonoBehaviour
{
    private Button _button;
    private Color _color;
    //public Image _testImage;
    // Use this for initialization
    public GameObject Logic;
    public GameObject InterfaceSiguiente1;
    public GameObject InterfaceSiguiente2;
    public GameObject InterfaceSiguiente3;
    public GameObject InterfaceSiguiente4;

    public GameObject InterfaceAbout;

    public GameObject InterfazActual;
    public bool[] played = { false, false, false, false };
    public GameObject[] button;

   // public AudioSource audioClick;

    void Start()
    {
       // audioClick = GetComponent<AudioSource>();

        PlayerPrefs.SetInt("principal", 0);

        _button = GetComponent<Button>();
        _color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        
        GameObject professor = (Logic.GetComponent<Logic2>().Professors);
        
        if (_button.name == "Button1" )
        {
            //cuando se presiona este boton haga....
            _button.onClick.AddListener(() =>
            {
               // audioClick.Play();

                //si el profesor dejo de hablar entonces
                //if (!professor.transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying)
                //{
                //Reproduce la animacion para la el boton1
                professor.GetComponent<AnimationManager>().interface1();
                    played[0] = true;

                    InterfaceAbout.SetActive(false);


                    //InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = false;
                    //InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = false;
                    //InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = false;
                    //InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = false;

                //PlayerPrefs.SetInt("ScrollActivo", 1);
                //}
            });
        }

        if (_button.name == "Button2" )
        {
            _button.onClick.AddListener(() =>
            {
                //if (!professor.transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying)
                //{
                    professor.GetComponent<AnimationManager>().interface2();
                    played[1] = true;

                    InterfaceAbout.SetActive(false);

                //InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = false;

                //PlayerPrefs.SetInt("ScrollActivo", 1);
                //}
            });
        }

        if (_button.name == "Button3" )
        {
            _button.onClick.AddListener(() =>
            {
                //if (!professor.transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying)
               // {
                    professor.GetComponent<AnimationManager>().interface3();
                    played[2] = true;

                    InterfaceAbout.SetActive(false);

                //InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = false;

                //PlayerPrefs.SetInt("ScrollActivo", 1);
                // }
            });
        }

        if (_button.name == "Button4")
        {
            _button.onClick.AddListener(() =>
            {
                //if (!professor.transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying)
                //{
                    professor.GetComponent<AnimationManager>().interface4();
                    played[3] = true;

                     InterfaceAbout.SetActive(false);

                //InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = false;
                //InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = false;

                //PlayerPrefs.SetInt("ScrollActivo", 1);
                // }
            });
        }
        
    }

    void Update()
    {
        GameObject professor = (Logic.GetComponent<Logic2>().Professors);

        /*
        if ((button[0].GetComponent<ButtonTest>().played[0] && !professor.transform.Find("Interfaz1").GetComponent<AudioSource>().isPlaying)
            || (button[1].GetComponent<ButtonTest>().played[1] && !professor.transform.Find("Interfaz2").GetComponent<AudioSource>().isPlaying)
            || (button[2].GetComponent<ButtonTest>().played[2] && !professor.transform.Find("Interfaz3").GetComponent<AudioSource>().isPlaying)
            || (button[3].GetComponent<ButtonTest>().played[3] && !professor.transform.Find("Interfaz4").GetComponent<AudioSource>().isPlaying))
            */
        

        if (PlayerPrefs.GetInt("principal") == 1)
        {
            //InterfazActual.transform.Find("Button4").GetComponent<Button>().interactable = true;
            //InterfazActual.transform.Find("Button3").GetComponent<Button>().interactable = true;
            //InterfazActual.transform.Find("Button2").GetComponent<Button>().interactable = true;
            //InterfazActual.transform.Find("Button1").GetComponent<Button>().interactable = true;
            
            button[0].GetComponent<ButtonTest>().played[0] = false;
            button[1].GetComponent<ButtonTest>().played[1] = false;
            button[2].GetComponent<ButtonTest>().played[2] = false;
            button[3].GetComponent<ButtonTest>().played[3] = false;

            //PlayerPrefs.SetInt("ScrollActivo", 0);
            PlayerPrefs.SetInt("principal", 0);
        }

        if ( button[0].GetComponent<ButtonTest>().played[0] )
        {
            //se quitan estos cuatro botones y se colocan los nuevos
            InterfazActual.SetActive(false);
            InterfaceSiguiente1.SetActive(true);            

            InterfaceSiguiente2.SetActive(false);
            InterfaceSiguiente3.SetActive(false);
            InterfaceSiguiente4.SetActive(false);
        }

        if (button[1].GetComponent<ButtonTest>().played[1])
        {
            //se quitan estos cuatro botones y se colocan los nuevos
            InterfazActual.SetActive(false);
            InterfaceSiguiente2.SetActive(true);

            InterfaceSiguiente1.SetActive(false);
            InterfaceSiguiente3.SetActive(false);
            InterfaceSiguiente4.SetActive(false);
        }

        if (button[2].GetComponent<ButtonTest>().played[2])
        {
            //se quitan estos cuatro botones y se colocan los nuevos
            InterfazActual.SetActive(false);            
            InterfaceSiguiente3.SetActive(true);

            InterfaceSiguiente1.SetActive(false);
            InterfaceSiguiente2.SetActive(false);
            InterfaceSiguiente4.SetActive(false);
        }

        if (button[3].GetComponent<ButtonTest>().played[3])
        {
            //se quitan estos cuatro botones y se colocan los nuevos
            InterfazActual.SetActive(false);
            InterfaceSiguiente4.SetActive(true);

            InterfaceSiguiente1.SetActive(false);
            InterfaceSiguiente2.SetActive(false);
            InterfaceSiguiente3.SetActive(false);
        }


    }

     
}
