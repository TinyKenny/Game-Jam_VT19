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
            //Debug.Break();


            GameObject[] pipes = GameController.GameControllerInstance.straightPipes; // change default?

            do
            {
                int pipeTypeToPick = Random.Range(0, 7);
                switch (pipeTypeToPick)
                {
                    case 0:
                        pipes = GameController.GameControllerInstance.straightPipes;
                        break;
                    case 1:
                        pipes = GameController.GameControllerInstance.cornerPipes;
                        break;
                    case 2:
                        pipes = GameController.GameControllerInstance.caltropPipes;
                        break;
                    case 3:
                        pipes = GameController.GameControllerInstance.crossingPipes;
                        break;
                    case 4:
                        pipes = GameController.GameControllerInstance.tCrossingPipes;
                        break;
                    case 5:
                        pipes = GameController.GameControllerInstance.doubleTCrossingPipes;
                        break;
                    case 6:
                        pipes = GameController.GameControllerInstance.muhsroomPipes;
                        break;
                    default:
                        Debug.Log(pipeTypeToPick);
                        break;
                }
            } while (pipes.Length == 0);

            int pipeToPickIndex = Random.Range(0, pipes.Length);

            //GameObject pipeToPick = GameController.GameControllerInstance.pipes[pipeToPickIndex];
            GameObject pipeToPick = Instantiate(pipes[pipeToPickIndex]);

            SeamScript[] pipeEntrances = pipeToPick.GetComponentsInChildren<SeamScript>();

            //Debug.Log(pipeEntrances.Length);

            //int entranceToPickIndex = 1;
            int entranceToPickIndex = Random.Range(0, pipeEntrances.Length);
            GameObject entranceToPick = pipeEntrances[entranceToPickIndex].gameObject;
            entranceToPick.GetComponent<SeamScript>().isExit = false;


            Quaternion rotationToMake = Quaternion.FromToRotation(entranceToPick.transform.forward, -transform.forward);

            //Debug.Log(-transform.forward);
            //Debug.Log(entranceToPick.gameObject);
            //Debug.Log(rotationToMake.eulerAngles);

            pipeToPick.transform.Rotate(rotationToMake.eulerAngles);

            //float placementOffsetDistance = Vector3.Distance(entranceToPick.transform.localPosition, entranceToPick.GetComponentInParent<Transform>().position);
            float placementOffsetDistance = entranceToPick.transform.localPosition.magnitude;

            //Vector3 newPipePosition = transform.position - entranceToPick.transform.localPosition; // localposition wont be affected by object rotation
            Vector3 newPipePosition = transform.position - transform.forward * placementOffsetDistance;

            pipeToPick.transform.position = newPipePosition;

            Debug.Log("Make pipe!");

            Debug.Log("Update the OtherPipe reference");



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
