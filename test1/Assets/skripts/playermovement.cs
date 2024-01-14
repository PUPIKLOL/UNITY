using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    float Ver, Hor, Jump;

    bool isGround;

    public float Speed = 10, JumpSpeed = 200;

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }

    void Update()
    {
        if (isGround)
        {
            Ver = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;

            GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
            transform.Translate(new Vector3(Hor, 0, Ver));
        }
    }
}

