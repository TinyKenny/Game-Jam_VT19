using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyCameraScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - (player.transform.forward * 20.0f);
        //transform.LookAt(player.transform);
        transform.rotation = player.transform.rotation;
    }
}
