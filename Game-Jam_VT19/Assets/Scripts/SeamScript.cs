using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamScript : MonoBehaviour
{
    public bool isExit = true;

    public GameObject otherPipe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && otherPipe == null && isExit)
        {


            Debug.Break();



            int pipeToPickIndex = Random.Range(0, GameController.GameControllerInstance.pipes.Length - 1);

            //GameObject pipeToPick = GameController.GameControllerInstance.pipes[pipeToPickIndex];
            GameObject pipeToPick = Instantiate(GameController.GameControllerInstance.pipes[pipeToPickIndex]);

            Transform[] pipeEntrances = pipeToPick.GetComponentsInChildren<Transform>();

            //int entranceToPickIndex = Random.Range(0, pipeEntrances.Length - 1);
            int entranceToPickIndex = 0;

            GameObject entranceToPick = pipeEntrances[entranceToPickIndex].gameObject;

            Debug.Log(entranceToPick);
            Debug.Log(entranceToPick.GetComponent<SeamScript>());

            entranceToPick.GetComponent<SeamScript>().isExit = false;

            //Vector3 newPipePosition = GetComponentInParent<Transform>().position;
            Vector3 newPipePosition = transform.position - entranceToPick.transform.localPosition;

            //Debug.Log(transform.position);

            pipeToPick.transform.position = newPipePosition;





            //GameObject entranceToPick

            Debug.Log("Make pipe!");

        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isExit)
        {
            Debug.Log("Delete previous");
        }
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
