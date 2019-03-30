using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyPlayerControls : MonoBehaviour
{
    public float baseMovementSpeed = 5.0f;

    [Header("Base Rotation Speeds")]
    public float pitchSpeed = 20.0f;
    public float yawSpeed = 20.0f;
    public float rollSpeed = 20.0f;

    [Header("Speed Scaling (Should be left at zero!)")]
    public float moveSpeedMod = 0.0f;
    public float rotationSpeedMod = 0.0f;

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

        float rotateX = Input.GetAxisRaw("Pitch") * pitchSpeed;
        float rotateY = Input.GetAxisRaw("Yaw") * yawSpeed;
        float rotateZ = Input.GetAxisRaw("Roll") * rollSpeed;

        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * (1.0f + rotationSpeedMod) * Time.deltaTime); // z = Input.GetAxisRaw("Horizontal")

        //Debug.Log(transform.forward);

        transform.Translate(new Vector3(0.0f, 0.0f, 1.0f) * baseMovementSpeed * (1.0f + moveSpeedMod) * Time.deltaTime);
    }
}
