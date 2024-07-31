using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject jumpParticle;

    bool isLeftKeyPressed;
    bool isRightKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        isLeftKeyPressed = false;
        isRightKeyPressed = false;
   
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 4.0f;
        const float jumpSpeed = 6.0f;
        Vector3 v = rb.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRightKeyPressed = true;
            isLeftKeyPressed = false;
            transform.rotation = Quaternion.Euler(10, 90, 0);
            v.x = moveSpeed;
            if(Input.GetKeyDown(KeyCode.D))
            {
                rb.transform.position += new Vector3(1, 0, 0);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            isRightKeyPressed = false;
            isLeftKeyPressed = true;
            transform.rotation = Quaternion.Euler(10, -90, 0);
            v.x = -moveSpeed;
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.transform.position -= new Vector3(1, 0, 0);
            }
        }
        else
        {
            v.x = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // ジャンプパーティクル発生
            Instantiate(jumpParticle, transform.position, Quaternion.identity);

            v.y = jumpSpeed;
        }
        rb.velocity = v;

        if(isRightKeyPressed == true && Input.GetKey(KeyCode.RightArrow) == false)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (isLeftKeyPressed == true && Input.GetKey(KeyCode.LeftArrow) == false)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
