using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyCameraScript : MonoBehaviour
{ 
    public float maxDistance = 20.0f;
    public LayerMask pipeLayer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayHit;
        bool rayHasHit = Physics.Raycast(player.transform.position, -player.transform.forward, out rayHit, maxDistance, pipeLayer, QueryTriggerInteraction.Ignore);

        float camDistance = maxDistance;
        if (rayHasHit)
        {
            camDistance = rayHit.distance;
        }

        
        transform.position = player.transform.position - (player.transform.forward * camDistance);
        transform.rotation = player.transform.rotation;
    }
}
