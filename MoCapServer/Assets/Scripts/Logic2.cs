using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class Logic2 : MonoBehaviour {

    // Variables publicas que se referencian en otros scripts o son asignadas en el juego
    //public Transform camara; //Asignar la main camera
    public Material Red; // Asignar el material de los bones del kinect

    public GameObject Professors; //Asignar la lista de profesores que se pueden escoger
    
    // public GameObject finalPos; // Asignar la posicion final donde el profesor interactua con el usuario ???????????

    //public GameObject posKinect; // Asignar posicion a donde debe mirar el profesor ????????????????????????????????

    public GameObject BodySourceManager; // Asignar objeto de BodySourceManager

    //public GameObject canvas; // Asignar objeto de Canvas ]????????????????????????

    //public GameObject[] waypoints; // Asignar puntos de referencia de llegada de los profesores
     
    //public GameObject[] ChosenProfessors = new GameObject[2]; //Lista de profesores en el juego

    //bool OnPlay = false; //Variable para empezar

    //bool[] entering = { false, false }; // Lista de booleanos para saber si los profesores estan entrando

    //float trackedCount = 0; //Contador de tiempo de persona detectada por el kinect

    //float countBye = 0; //Contador para esperar que los profesores terminen de despedirse y puedan retirarse

    //bool[] arrived = { false, false };  // ?????????????????????????????????????????????????????????????????????????
    
    //bool[] talking = { false, false }; // Lista de booleanos para saber si el profesor está hablando  ??????????????
    //bool[] played = { false, false, false, false, false }; // Booleanos para saber si se ejecutaron los audios ?????
    //bool[] playing = { false, false, false, false, false }; // Booleanos para saber si están en ejecución los audios ????

    float InteractCounter = 0; // ??????????????????????????????????????????????

    //Animator anim; // Variable que representa el animator del profesor ????????
    
    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>(); //Diccionario de Bodies y sus respectivos ID's
    private BodySourceManager _BodyManager; 
    
    //Diccionario de Joints del cuerpo en el kinect
    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },

        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },

        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };

    void Start() {

    }

    // Update es llamado una vez por Frame
    void Update() {

        //Inicialización del kinect
        if (BodySourceManager == null)
        {
            return;
        }

        _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }

        Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }

        //Agregar ID cuando se detecta un cuerpo
        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
                
            }
        }

        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);

        // Eliminar cuerpos que ya no están
        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);

                InteractCounter = 0;
                //trackedCount = 0;

            }
        }


        //Esperar que el Kinect detecte un cuerpo
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            //Se crea un nuevo cuerpo si es detectado
            if (body.IsTracked)
            {
                if (!_Bodies.ContainsKey(body.TrackingId))
                {
                    // _Bodies[body.TrackingId] = CreateBodyObjects(body.TrackingId);                               
                }

                Professors.GetComponent<AnimationManager>().intro();

                //print("1111111111");

                //PlayerPrefs.SetInt("EstadoAnimacion", 1);

            }

            //si no detecta ningun usuario corra el idle de animacion
            /*else
            {
                PlayerPrefs.SetInt("EstadoAnimacion", 0);

                print("00000");
            }*/
        }
    }


    private GameObject CreateBodyObjects(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);
        //body.transform.position = posKinect.transform.position;
        //body.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        
            for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = Red;
            lr.SetWidth(0.05f, 0.05f);

            jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;

        }

        return body;
    }


    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            Kinect.Joint sourceJoint = body.Joints[jt];
            Kinect.Joint? targetJoint = null;

            if (_BoneMap.ContainsKey(jt))
            {
                targetJoint = body.Joints[_BoneMap[jt]];
            }

            Transform jointObj = bodyObject.transform.Find(jt.ToString());
            jointObj.localPosition = GetVector3FromJoint(sourceJoint);

            LineRenderer lr = jointObj.GetComponent<LineRenderer>();
            if (targetJoint.HasValue)
            {
                lr.SetPosition(0, jointObj.localPosition);
                lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
                lr.SetColors(GetColorForState(sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
            }
            else
            {
                lr.enabled = false;
            }
                       

        }
    }

    private static Color GetColorForState(Kinect.TrackingState state)
    {
        switch (state)
        {
            case Kinect.TrackingState.Tracked:
                return Color.green;

            case Kinect.TrackingState.Inferred:
                return Color.red;

            default:
                return Color.black;
        }
    }

    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }


    // Funcion para girar un objero hacia un target a tantos steps por frame
    public void TurnTo(Transform obj, Vector3 target, float step)
    {
        Vector3 direction = target - obj.transform.position;
       // Vector3 direction = Camera.main.transform.position - obj.transform.position;
        direction.y = 0;

        obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, Quaternion.LookRotation(direction), step * Time.deltaTime);

    }
}
