using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MaterialUI;
using UnityEngine.UI;

public class NoticiasView : MonoBehaviour
{

    public static NoticiasView main;

    public ComponentesNoticiasUI CmptsNoticiasView;

    void Awake()
    {
        main = this;
    }

    public void SettingView(NoticiasItemEvent evnt)
    {

      
    }

   

    void InitSetting(int cnt)
    {
        
    }
}

[System.Serializable]
public class ComponentesNoticiasUI
{
   
    public NoticiasItemEvent noticiaInterface1;
    public NoticiasItemEvent noticiaInterface2;
    public NoticiasItemEvent noticiaInterface3;
    public NoticiasItemEvent noticiaInterface4;
    public NoticiasItemEvent noticiaInterface5;


}


