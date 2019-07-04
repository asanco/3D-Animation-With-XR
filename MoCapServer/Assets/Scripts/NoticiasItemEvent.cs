using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using MaterialUI;

public class NoticiasItemEvent : MonoBehaviour
{

    public int myIdEvento;
    public Text NombreEvento;
    public Text boton1;
    public Text TitulodescripcionBtn1;
    public Text descripcionBtn1;
    public Text boton2;
    public Text TitulodescripcionBtn2;
    public Text descripcionBtn2;
    public Text boton3;
    public Text TitulodescripcionBtn3;
    public Text descripcionBtn3;
    public Text boton4;
    public Text TitulodescripcionBtn4;
    public Text descripcionBtn4;

    public void setNoticiasEvent(int id)
    {
        //print("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
       
        myIdEvento = DataInfo.main.dataNoticias.NoticiasSeneca[id].idEvento;
        NombreEvento.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].nombreEvento;
        boton1.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].opc1;
        descripcionBtn1.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].descrpOpc1;
        boton2.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].opc2;
        descripcionBtn2.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].descrpOpc2;
        boton3.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].opc3;
        descripcionBtn3.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].descrpOpc3;
        boton4.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].opc4;
        descripcionBtn4.text = DataInfo.main.dataNoticias.NoticiasSeneca[id].descrpOpc4;

        TitulodescripcionBtn1.text = boton1.text;
        TitulodescripcionBtn2.text = boton2.text;
        TitulodescripcionBtn3.text = boton3.text;
        TitulodescripcionBtn4.text = boton4.text;
		     


    }

    IEnumerator LoadImageItem(int id, LoopVerticalScrollRect scr)
    {
        yield return new WaitUntil(() => scr.velocity.y < 0.02f);

    
    }

 
    public void OpenBntUpScroll(int idx)
    {
      
    }

  
}
