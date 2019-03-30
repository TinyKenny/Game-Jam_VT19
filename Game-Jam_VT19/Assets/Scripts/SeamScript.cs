using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamScript : MonoBehaviour
{
    public bool isExit = true;

    public SeamScript otherPipe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && otherPipe == null && isExit)
        {
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

            GameObject pipeToPick = Instantiate(pipes[pipeToPickIndex]);

            SeamScript[] pipeEntrances = pipeToPick.GetComponentsInChildren<SeamScript>();

            int entranceToPickIndex = Random.Range(0, pipeEntrances.Length);
            GameObject entranceToPick = pipeEntrances[entranceToPickIndex].gameObject;
            otherPipe = entranceToPick.GetComponent<SeamScript>();
            otherPipe.isExit = false;
            otherPipe.otherPipe = this;

            Quaternion rotationToMake = Quaternion.FromToRotation(entranceToPick.transform.forward, -transform.forward);

            pipeToPick.transform.Rotate(rotationToMake.eulerAngles);

            float placementOffsetDistance = entranceToPick.transform.localPosition.magnitude;

            Vector3 newPipePosition = transform.position - transform.forward * placementOffsetDistance;

            pipeToPick.transform.position = newPipePosition;

            //Debug.Log("Make pipe!");

            //Debug.Log("Update the OtherPipe reference");

        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isExit)
        {
            Debug.Log("Delete previous");
            otherPipe.CleanUpPipes(this);
        }
    }

    private void CleanUpPipes(SeamScript caller) // make this public?
    {
        GameObject parentObject = transform.parent.gameObject;

        Debug.Log(parentObject);

        SeamScript[] points = parentObject.GetComponentsInChildren<SeamScript>();

        Debug.Log(points);

        foreach(SeamScript point in points)
        {
            point.RemoveOtherPipe(caller);
        }
    }

    private void RemoveOtherPipe(SeamScript protectedPipe)
    {
        if(otherPipe != null && otherPipe != protectedPipe)
        {
            Destroy(otherPipe.transform.parent.gameObject);
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
