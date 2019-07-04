using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAvatar : MonoBehaviour {

    public Animator anim; //Variable del animator

    // Lista de booleanos que representan si los sonidos de introducción y askMe fueron reproducidos
    bool[] played = { false, false, false, false, false, false, false, false};

    // Booleano para indicar a logic si ya el personaje se despidió
    public bool byebool = false;

    /// <summary>
    ///DICCINARIO DE METODOS DE MOVIMIENTOS
    /// ABRIR Y CERRAR CANALES DE MOVIMIENTO
    /// DUDA(ES NECESARIO SIEMPRE UN CONDICIONAL PARA VOLVER)?
    /// </summary>

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Funcion de estado Idle del personaje
    public void idleMinotity()//ESTADO 0
    {
        //se selcciona en modelo 3d en project, en el inspector se selecciona animation 
        //y se crean todos los clips de animacion por frame,
        //luego se seleccionan las animaciones que son loopeadas y se chulea loop time, apply
        // en base manager coloco en el idle la animacion de minoriry

        //aca inicializo todas las animaciones en false

        //anim.SetBool("isGiro", false);
       // anim.SetBool("isSaludar", false);
        anim.SetBool("isIntro", false);


        anim.SetBool("isWalking", false);
        anim.SetBool("isTurning", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWaving", false);
        //anim.SetBool("isBye", false);
        anim.SetBool("isTalking", false);        
        anim.SetBool("isConv", false);
        anim.SetBool("isAsk", false);
        // transform.Find("Talking").gameObject.SetActive(false);
    }

    ///funcion para activar movimientos de la cara
    // Funcion para cuando se inicia la introduccion de un profesor
    public void intro()
    {
        //anim.SetBool("isConv", false);

        anim.SetBool("isConv", false);
        //anim.SetBool("isIntro", true);
        anim.SetBool("isAsk", true);

        anim.SetBool("isGiro", true);
        //anim.SetBool("isSaludar", true);

        //Busca el audio source de introduction y lo reproduce
        if (!transform.Find("Introduction").GetComponent<AudioSource>().isPlaying && !played[0])
        {
            transform.Find("Introduction").GetComponent<AudioSource>().Play();
            played[0] = true;
        }
        else if (!transform.Find("Introduction").GetComponent<AudioSource>().isPlaying && played[0]
            && !transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying && !played[1])
        {

            transform.Find("Dinamic").GetComponent<AudioSource>().Play();
            transform.Find("Canvas").gameObject.SetActive(true);
            played[1] = true;
        }
        else if (!transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying && played[1])
        {
            idle();
        }
        // transform.Find("Talking").gameObject.SetActive(false);
    }

    // Funcion de estado Idle del personaje
    public void idle()//ESTADO 0
    {
        //anim.SetBool("isGiro", false);
        //anim.SetBool("isSaludar", false);
        //anim.SetBool("isIntro", true);


        anim.SetBool("isWalking", false);
        anim.SetBool("isTurning", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWaving", false);
        //anim.SetBool("isBye", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isConv", false);
        anim.SetBool("isAsk", false);
       // transform.Find("Talking").gameObject.SetActive(false);
    }

    //Funcion de caminar del personaje
    public void walking() //(estados 0-1 || 2-0)
    {
        anim.SetBool("isWalking", true);
        anim.SetBool("isTurning", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWaving", false);
        //anim.SetBool("isBye", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", false);
        anim.SetBool("isQuestion2", false);
        anim.SetBool("isQuestion3", false);
        anim.SetBool("isConv", false);
       // transform.Find("Talking").gameObject.SetActive(false);

    }
    
    // Funcion para cuando se identifica al jugador e inicia interacción con el
    public void wave() //saluda (Estados 0-2 || 1-2)
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isTurning", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWaving", true);
        //anim.SetBool("isBye", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isConv", false);
      //  transform.Find("Talking").gameObject.SetActive(false);
    }

    //funciones para mover solo la cabeza cuando esta en estado 1 (caso de presenciar a alguien y que no se quede mucho tiempo)
    public void turnHead()
    {
       // anim.SetBool("isTurnHead", true);
    }

    //funcion para girar 90 grados a la derecha
    public void turn() //SOLO PARA EL PROFESOR DE LA IZQUIERDA (Estados 1-2||2-0)
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isTurning", true);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWaving", false);
        //anim.SetBool("isBye", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isConv", false);
      //  transform.Find("Talking").gameObject.SetActive(false);
    }

    //funcion para simular una conversacion con otro profesor
    public void conversation()//Se queda simulando la conversacion (estado 1)
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isTurning", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWaving", false);
        //anim.SetBool("isBye", false);
        anim.SetBool("isTalking", true);
        anim.SetBool("isConv", true);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        transform.Find("Talking").gameObject.SetActive(true);
    }

    public void Question1()
    {
        idle();
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", true);
        anim.SetBool("isQuestion2", false);
        anim.SetBool("isQuestion3", false);
        anim.SetBool("isConv", false);

        if (!transform.Find("Question1").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("Question1").GetComponent<AudioSource>().Play();
        }
       // transform.Find("Talking").gameObject.SetActive(false);


    }
    public void Question2()
    {
        idle();
        
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", false);
        anim.SetBool("isQuestion2", true);
        anim.SetBool("isQuestion3", false);
        anim.SetBool("isConv", false);
        if (!transform.Find("Question2").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("Question2").GetComponent<AudioSource>().Play();
        }
       // transform.Find("Talking").gameObject.SetActive(false);

    }
    public void Question3()
    {
        idle();
        
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", false);
        anim.SetBool("isQuestion2", false);
        anim.SetBool("isQuestion3", true);
        anim.SetBool("isConv", false);
        if (!transform.Find("Question3").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("Question3").GetComponent<AudioSource>().Play();
        }
        //transform.Find("Talking").gameObject.SetActive(false);

    }

    //funcion para las animaciones cuando interactua con el usuario
    public void interaction() //se quedará quieto hasta saber como se harán las animaciones (estado 2)
    {
        idle();

    }
    //funcion para terminar la ejecucion con el usuario (estado 2-0);
    public void bye()
    {
        if(!transform.Find("RightAnswer").GetComponent<AudioSource>().isPlaying && !transform.Find("WrongAnswer").GetComponent<AudioSource>().isPlaying)
        {
            anim.SetBool("isTalking", false);
            anim.SetBool("isIntro", false);
            anim.SetBool("isAsk", false);
            anim.SetBool("isQuestion1", false);
            anim.SetBool("isQuestion2", false);
            anim.SetBool("isQuestion3", false);
            anim.SetBool("isTest", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isWrong", false);
            if (!transform.Find("Bye").GetComponent<AudioSource>().isPlaying)
            {
                transform.Find("Bye").GetComponent<AudioSource>().Play();
            }
            anim.SetBool("isBye", true);
            anim.SetBool("isWaving", true);
            anim.SetBool("isConv", false);
            
            
            byebool = true;
            //transform.Find("Talking").gameObject.SetActive(false);
        }
        
    }

    

    public void rightAnswer()
    {
        idle();
        anim.SetBool("isConv", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", false);
        anim.SetBool("isQuestion2", false);
        anim.SetBool("isQuestion3", false);
        anim.SetBool("isRight", true);
        anim.SetBool("isTest", false);
        anim.SetBool("isWrong", false);
        //anim.SetBool("isBye", false);
        if (!transform.Find("RightAnswer").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("RightAnswer").GetComponent<AudioSource>().Play();
        }
       // transform.Find("Talking").gameObject.SetActive(false);

    }

    public void wrongAnswer()
    {
        idle();
  
        anim.SetBool("isConv", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", false);
        anim.SetBool("isQuestion2", false);
        anim.SetBool("isQuestion3", false);
        anim.SetBool("isWrong", true);
        anim.SetBool("isTest", false);
        anim.SetBool("isRight", false);
        //anim.SetBool("isBye", false);
        if (!transform.Find("WrongAnswer").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("WrongAnswer").GetComponent<AudioSource>().Play();
        }
        //transform.Find("Talking").gameObject.SetActive(false);
    }

    public void test()
    {
        idle();
        
        anim.SetBool("isConv", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isIntro", false);
        anim.SetBool("isAsk", false);
        anim.SetBool("isQuestion1", false);
        anim.SetBool("isQuestion2", false);
        anim.SetBool("isQuestion3", false);
        anim.SetBool("isTest", true);
        //anim.SetBool("isBye", false);
        if (!transform.Find("Test").GetComponent<AudioSource>().isPlaying)
        {
            transform.Find("Test").GetComponent<AudioSource>().Play();
        }
       // transform.Find("Talking").gameObject.SetActive(false);
    }



    // FIN DICCIONARIO DE MOVIMIENTOS

    /// <summary>
    ///     Indicadores de movimiento y estados relacionados con el kinnect 
    /// </summary>


    // Update is called once per frame
    void Update () {


        //Convertir todos estos if en uno solo como en Test.cs con los isRight e is Wrong

        if( !transform.Find("Dinamic").GetComponent<AudioSource>().isPlaying 
            && !transform.Find("Question1").GetComponent<AudioSource>().isPlaying
            && !transform.Find("Question2").GetComponent<AudioSource>().isPlaying
            && !transform.Find("Question3").GetComponent<AudioSource>().isPlaying
            && !transform.Find("Test").GetComponent<AudioSource>().isPlaying
            //&& !transform.Find("Bye").GetComponent<AudioSource>().isPlaying
            && !transform.Find("RightAnswer").GetComponent<AudioSource>().isPlaying
            && !transform.Find("WrongAnswer").GetComponent<AudioSource>().isPlaying)
        {
            anim.SetBool("isAsk", false);
            anim.SetBool("isQuestion1", false);
            anim.SetBool("isQuestion2", false);
            anim.SetBool("isQuestion3", false);
            anim.SetBool("isTest", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isWrong", false);
            //anim.SetBool("isBye", false);

        }
       // print(anim.GetBool("isBye"));
    }
}
