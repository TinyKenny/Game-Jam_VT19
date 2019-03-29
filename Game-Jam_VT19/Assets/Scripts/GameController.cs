using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] pipes;

    //private Random rngSus = new Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pipeToPickIndex = Random.Range(0, pipes.Length - 1);

        GameObject pipeToPick = pipes[pipeToPickIndex];

        Transform[] pipeEntrances = pipeToPick.GetComponentsInChildren<Transform>();

        int entranceToPickIndex = Random.Range(0, pipeEntrances.Length - 1);

        //GameObject entranceToPick

    }
}
