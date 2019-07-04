using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MaterialUI;
using System;
using UnityEngine.UI;




public class DataInfo : MonoBehaviour
{
    public static DataInfo main;

    public DataRowList InfoList;
    public EventosNoticiasData dataNoticias;

    public bool OnFinishDwnld;

    private bool unaVez;


    void Awake()
    {
        main = this;
        OnFinishDwnld = false;
        unaVez = false;
    }

    public IEnumerator LoadInfo()
    {
        OnFinishDwnld = false;
        yield return StartCoroutine(DownloadEventos(DataApp.main.host + "Eventos/Eventos.php?opc=TotalEventos"));
        //print ("sdisiisisisi");
    }

    #region DESCARGA DE DATOS EVENTOS   //--------------------------------------------------------------------------------------------------------------------------

    IEnumerator DownloadEventos(string url)
    {
        dataNoticias.NoticiasSeneca.Clear();


        print("primer print" + dataNoticias.NoticiasSeneca.Count);


        WWW consult = new WWW(DataApp.main.host + "Validaciones/Validaciones.php?opc=validar&flag=6");
        yield return consult;

        if (string.IsNullOrEmpty(consult.error))
        {
            int version = int.Parse(consult.text);


            if (DataApp.main.Usuario.miUsuario.DataInfo.EventosInd != version)
            {
                DataApp.main.Usuario.miUsuario.DataInfo.EventosInd = version;
                yield return StartCoroutine(GetJsonDataScript.getJson.GetPhpData(url));
                DataApp.main.Usuario.miUsuario.DataInfo.EventosJsonCache = GetJsonDataScript.getJson.GetDataConsult();
            }
            else
            {
                string jsonGuardado = DataApp.main.Usuario.miUsuario.DataInfo.EventosJsonCache;
                yield return StartCoroutine(GetJsonDataScript.getJson.GetLocalData(jsonGuardado));
            }
        }

        if (GetJsonDataScript.getJson._state == "Successful")
        {
            if (unaVez == false)
            {

                InfoList = GetJsonDataScript.getJson.GetData(InfoList, "idEvento", "nombreEvento", "opc1", "descrpOpc1", "opc2", "descrpOpc2", "opc3", "descrpOpc3", "opc4", "descrpOpc4");

                print("cantidad " + InfoList.dataList.Count);

                for (int i = 0; i < InfoList.dataList.Count; i++)
                {
                    Eventos evnt = new Eventos();
                    evnt.idEvento = int.Parse(InfoList.dataList[i].GetValueToKey("idEvento"));
                    evnt.nombreEvento = InfoList.dataList[i].GetValueToKey("nombreEvento");
                    evnt.opc1 = InfoList.dataList[i].GetValueToKey("opc1");
                    evnt.descrpOpc1 = InfoList.dataList[i].GetValueToKey("descrpOpc1");
                    evnt.opc2 = InfoList.dataList[i].GetValueToKey("opc2");
                    evnt.descrpOpc2 = InfoList.dataList[i].GetValueToKey("descrpOpc2");
                    evnt.opc3 = InfoList.dataList[i].GetValueToKey("opc3");
                    evnt.descrpOpc3 = InfoList.dataList[i].GetValueToKey("descrpOpc3");
                    evnt.opc4 = InfoList.dataList[i].GetValueToKey("opc4");
                    evnt.descrpOpc4 = InfoList.dataList[i].GetValueToKey("descrpOpc4");

                    dataNoticias.NoticiasSeneca.Add(evnt);

                }
            }

            print("ultimo print" + dataNoticias.NoticiasSeneca.Count);
            unaVez = true;

            if (dataNoticias.NoticiasSeneca.Count == 0)
            {
                print("Aún no hay eventos registrados.!");
            }
            else
            {
            }

        }
        else
        {
            if (GetJsonDataScript.getJson._state != "Empty")
            {
                print("Hubo un error al descargar los datos");
                StartCoroutine(LoadInfo());
            }
            else
            {
                print("Aún no hay eventos registrados.!");
            }
        }

        StartCoroutine(FlagEventos(DataApp.main.host + "Validaciones/Validaciones.php?opc=validar&flag=2"));

    }



    IEnumerator FlagEventos(string url)
    {
        WWW consult = new WWW(url);
        yield return consult;
        if (string.IsNullOrEmpty(consult.error))
        {
            int version = int.Parse(consult.text);

            if (DataApp.main.Usuario.miUsuario.UpdatesImgs.NoticiasFlg != version)
            {
                DataApp.main.DeleteFolder("Noticias");
                DataApp.main.Usuario.miUsuario.UpdatesImgs.NoticiasFlg = version;


                NoticiasView.main.CmptsNoticiasView.noticiaInterface1.setNoticiasEvent(0);
                NoticiasView.main.CmptsNoticiasView.noticiaInterface2.setNoticiasEvent(1);
                NoticiasView.main.CmptsNoticiasView.noticiaInterface3.setNoticiasEvent(2);
                NoticiasView.main.CmptsNoticiasView.noticiaInterface4.setNoticiasEvent(3);
                NoticiasView.main.CmptsNoticiasView.noticiaInterface5.setNoticiasEvent(4);
            }
        }

        DataApp.main.Save(); /////////////////////////////
        OnFinishDwnld = true;

    }

    #endregion
}

[System.Serializable]
public class EventosNoticiasData
{
    public List<Eventos> NoticiasSeneca;
   

}


[System.Serializable]
public class ImagesCacheUI
{
    public List<Sprite> listSprites;
}
