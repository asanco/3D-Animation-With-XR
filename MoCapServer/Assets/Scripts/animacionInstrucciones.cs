using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacionInstrucciones : MonoBehaviour
{
    public Animator animInstrucciones;


    // Use this for initialization
    void Start()
    {
        animInstrucciones.SetBool("piso", false);
        animInstrucciones.SetBool("botones", false);
        animInstrucciones.SetBool("scroll", false);
    }

    public void nada()
    {
        animInstrucciones.SetBool("piso", false);
        animInstrucciones.SetBool("botones", false);
        animInstrucciones.SetBool("scroll", false);
    }

    public void instrucPiso()
    {
        animInstrucciones.SetBool("piso", true);
        animInstrucciones.SetBool("botones", false);
        animInstrucciones.SetBool("scroll", false);
    }

    public void instrucBtn()
    {
        animInstrucciones.SetBool("piso", false);
        animInstrucciones.SetBool("botones", true);
        animInstrucciones.SetBool("scroll", false);
    }

    public void instrucScroll()
    {
        animInstrucciones.SetBool("piso", false);
        animInstrucciones.SetBool("botones", false);
        animInstrucciones.SetBool("scroll", true);
    }

      
}
