using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyPlayerControls : MonoBehaviour
{
    private float moveSpeedMod = 1.5f;
    private float rotationSpeedMod = 20.0f;

    /* 
     * movement speed up
     * movement speed down
     * projectile speed up
     * projectile speed down
     * rotation speed up
     * rotation speed down
     * fire rate up
     * fire rate down
     * invert controls
     * auto aim
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float rotateX = Input.GetAxisRaw("Pitch");
        float rotateY = Input.GetAxisRaw("Yaw");
        float rotateZ = Input.GetAxisRaw("Roll");

        //Debug.Log(Input.GetAxisRaw("Yaw"));

        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * rotationSpeedMod * Time.deltaTime); // z = Input.GetAxisRaw("Horizontal")


        transform.Translate(transform.forward * moveSpeedMod * Time.deltaTime);
    }
}
