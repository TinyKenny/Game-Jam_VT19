using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController GameControllerInstance;

    [SerializeField] public GameObject[] pipes;

    //private Random rngSus = new Random();

    // Start is called before the first frame update
    void Start()
    {
        GameControllerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
