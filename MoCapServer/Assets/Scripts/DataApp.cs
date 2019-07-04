using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Collections.Generic;
//using MaterialUI;
using System.Threading;
using System;
using UnityEngine.UI;

public class DataApp : MonoBehaviour
{

    public static DataApp main;

    public string host = "";
    public string hostImg = "";

    public Componentes MisComponentes;

    [Header("Informacion del Usuario")]
    public userData Usuario;

    void Awake()
    {
        main = this;
        CreateDirectorys();

    }

    private void Start()
    {
       
            if (DataApp.main.isExistDataPath())
                DataApp.main.Load();


            StartCoroutine(DataInfo.main.LoadInfo());
     
    }

    public void CreateDirectorys()
    {
        foreach (string dir in MisComponentes.Directorys)
        {
            if (!Directory.Exists(Application.persistentDataPath + "/" + dir))
                Directory.CreateDirectory(Application.persistentDataPath + "/" + dir);

            if (!Directory.Exists(Application.persistentDataPath + "/InfoUser/userInfo"))
                Directory.CreateDirectory(Application.persistentDataPath + "/InfoUser/userInfo");

        }
    }

    public void DeleteFolder(string dir)
    {
        if (Directory.Exists(Application.persistentDataPath + "/" + dir))
        {
            DirectoryInfo dic = new DirectoryInfo(Application.persistentDataPath + "/" + dir);

            foreach (FileInfo fl in dic.GetFiles())
            {
                fl.Delete();
            }
            foreach (DirectoryInfo dirc in dic.GetDirectories())
            {
                dirc.Delete();
            }
            Directory.CreateDirectory(Application.persistentDataPath + "/" + dir);

        }
    }

    public int GetMyID()
    {
        return PlayerPrefs.HasKey("MyID") ? PlayerPrefs.GetInt("MyID") : 0;
    }


    public void accedio()
    {
    }

    public string ToAntiCache(string url)
    {
        string r = "";
        r += UnityEngine.Random.Range(1000000, 9000000).ToString();
        r += UnityEngine.Random.Range(1000000, 9000000).ToString();
        string result = "";
        if (url.Substring(url.Length - 4, 4) == ".php" || url.Substring(url.Length - 4, 4) == ".png" || url.Substring(url.Length - 4, 4) == ".jpg")
        {
            result = url + "?key=" + r;
        }
        else
        {
            result = url + "&key=" + r;
        }
        return result;
    }


    /// CHEQUEARR SI HAY INTERNETTT EN LA APP

    public bool failInternet;
    public IEnumerator CheckInternet(System.Action<bool> hasInternet)
    {
        bool result = false;
        string chcInternet = host + "ConexionInternet/isConection.php?conection=validarConexion";
        WWW getData = new WWW(chcInternet);
        yield return getData;
        if (getData.text == "ConexionEstablecida")
        {
            result = true;
        }
        else
        {
            failInternet = false;
        }

        hasInternet(result);
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/InfoUser/userInfo" + DataApp.main.GetMyID() + ".dat");

        userData usData = new userData();
        #region SETTING DE TODOS LOS DATOS DEL USUARIO ---------------------------------

        usData.miUsuario.UpdatesImgs.NoticiasFlg = Usuario.miUsuario.UpdatesImgs.NoticiasFlg;

        usData.miUsuario.DataInfo.EventosInd = Usuario.miUsuario.DataInfo.EventosInd;
        usData.miUsuario.DataInfo.EventosJsonCache = Usuario.miUsuario.DataInfo.EventosJsonCache;

        #endregion //----------------------------------------------------------------------------------------
        bf.Serialize(file, usData);
        file.Close();

        Debug.Log("Guardando info en: " + Application.persistentDataPath + "/InfoUser/InfoUser/userInfo" + DataApp.main.GetMyID() + ".dat");
    }

    public void Load()
    {
        if (isExistDataPath())
        {
            Debug.Log("Cargando info en: " + Application.persistentDataPath + "/InfoUser/userInfo" + DataApp.main.GetMyID() + ".dat");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/InfoUser/userInfo" + DataApp.main.GetMyID() + ".dat", FileMode.Open);
            userData usData = (userData)bf.Deserialize(file);
            file.Close();
            #region SETTING DE TODOS LOS DATOS DEL USUARIO -----------------------------------

            Usuario.miUsuario.DataInfo.EventosInd = usData.miUsuario.DataInfo.EventosInd;
            Usuario.miUsuario.DataInfo.EventosJsonCache = usData.miUsuario.DataInfo.EventosJsonCache;


            #endregion
        }
    }


    public bool isExistDataPath()
    {
        bool ext = (File.Exists(Application.persistentDataPath + "/InfoUser/userInfo" + DataApp.main.GetMyID() + ".dat")) ? true : false;
        return ext;
    }

 

    public void SetIsFirtsOpen(string opc)
    {
        PlayerPrefs.SetString("IsFirtsOpen", opc);
    }

    public string GetIsFirtsOpen()
    {
        return PlayerPrefs.HasKey("IsFirtsOpen") ? PlayerPrefs.GetString("IsFirtsOpen") : "";
    }

    public bool IsFirtsOpen()
    {
        return PlayerPrefs.HasKey("IsFirtsOpen");
    }

}





[System.Serializable]
public class Eventos
{
    // Info Principal
    public string nombreEvento = "";
    public string opc1 = "";
    public string descrpOpc1 = "";
    public string opc2 = "";
    public string descrpOpc2 = "";
    public string opc3 = "";
    public string descrpOpc3 = "";
    public string opc4 = "";
    public string descrpOpc4 = "";


    [Range(0, 1000)]
    public int idEvento;
  

}



[System.Serializable]
public class Componentes
{
  
    public List<string> Directorys;
}



[System.Serializable]
public class userData
{
  
    public User miUsuario = new User();
}

[System.Serializable]
public class User
{

    public FlagsUpdate UpdatesImgs = new FlagsUpdate();

    public InfoApp DataInfo = new InfoApp();

}

[System.Serializable]
public class FlagsUpdate
{
    public int NoticiasFlg;
}


[System.Serializable]
public class InfoApp
{
    public int EventosInd;
    public string EventosJsonCache;
}