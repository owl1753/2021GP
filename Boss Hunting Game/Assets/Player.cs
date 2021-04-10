using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController cc;

    public float gravity = -9.8f;
    float velocity;
    public float jumpPower = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        if(cc.collisionFlags == CollisionFlags.Below)
        {
            velocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                velocity = jumpPower;
            }
        }
        velocity += gravity * Time.deltaTime;
        dir.y = velocity;
        //dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
