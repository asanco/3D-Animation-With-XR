using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Test : MonoBehaviour {
    private Button _button;
    private Color _color;
    // Use this for initialization
    public GameObject Logic;
    
    public GameObject[] buttons;
    public GameObject thisButtons;
    public bool answered = false;
    public bool[] played = { false, false };

    void Start () {


        _button = GetComponent<Button>();
        _color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        GameObject professor = (Logic.GetComponent<Logic2>().Professors);


        if (_button.name == "Correct")
        { 
            //si selecciono la respuesta correcta
            _button.onClick.AddListener(() =>
            {
                //reproduce la animacion de respuesta correcta
                professor.GetComponent<MovimientoAvatar>().rightAnswer();
                played[0] = true;
                answered = true;      

            });
           
        }

        //si no selecciona la respuesta incorrecta 
        else
        {
            _button.onClick.AddListener(() =>
            {
                //reproduce la animación de mala respuesta
                professor.GetComponent<MovimientoAvatar>().wrongAnswer();
                played[1] = true;

            });

        }
        
       
        
	}

    private void Update()
    {
        GameObject professor = (Logic.GetComponent<Logic2>().Professors);

        /*if (!professor.transform.Find("RightAnswer").GetComponent<AudioSource>().isPlaying
                       && !professor.transform.Find("WrongAnswer").GetComponent<AudioSource>().isPlaying)
        {
            professor.transform.GetComponent<MovimientoAvatar>().anim.SetBool("isRight", false);
            professor.transform.GetComponent<MovimientoAvatar>().anim.SetBool("isWrong", false);
        }*/

        //si respondio correctamente 
        if (answered)
        {

            for (int i = 0; i < buttons.Length; i++)
            {
                if (thisButtons.name == buttons[i].name)
                {

                    if (!professor.transform.Find("RightAnswer").GetComponent<AudioSource>().isPlaying
                       && !professor.transform.Find("WrongAnswer").GetComponent<AudioSource>().isPlaying)
                    {
                        //desactiva este boton
                        thisButtons.SetActive(false);
                        
                        //activa el otro boton botones
                        if (i + 1 < buttons.Length)
                        {
                            buttons[i + 1].SetActive(true);
                        }
                        //si ya todos los botones se habian activado
                        else
                        {
                            //reproduce la animación de salir
                            professor.GetComponent<MovimientoAvatar>().bye();
                        }
                        
                    }
                }
            }
        }
    }

}
