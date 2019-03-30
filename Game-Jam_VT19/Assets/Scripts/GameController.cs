using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController GameControllerInstance;



    public GameObject[] straightPipes; // done
    public GameObject[] cornerPipes; // done
    public GameObject[] caltropPipes; // done
    public GameObject[] crossingPipes; // done
    public GameObject[] tCrossingPipes; // done
    public GameObject[] doubleTCrossingPipes; // done
    public GameObject[] muhsroomPipes; // 

    //public List<GameObject[]> pipeTypes;


    //public GameObject[] Pipes;


    // Start is called before the first frame update
    void Start()
    {
        GameControllerInstance = this;


        //pipeTypes.Add(straightPipes);
        //pipeTypes.Add(cornerPipes);
        //pipeTypes.Add(caltropPipes);
        //pipeTypes.Add(tCrossingPipes);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
