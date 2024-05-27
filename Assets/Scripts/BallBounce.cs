using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SocialPlatforms.Impl;


public class BallBounce : MonoBehaviourPun
{
    
    Rigidbody rigid;
    float speed = 300f;
   

   

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoalPost")
        {
            GameManager.instance.SetScore2();
            gameObject.transform.position = new Vector3(0, 0, 0);
            rigid.velocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "GoalPost2")
        {
            GameManager.instance.SetScore1();
            gameObject.transform.position = new Vector3(0, 0, 0);
            rigid.velocity = Vector3.zero;
        }
        else
        {
            ExcecuteReBounding(collision, speed);
            speed += 15f;
        }



    }

    [PunRPC]
    void ExcecuteReBounding(Collision collision, float speed)
    {
        ContactPoint cp = collision.GetContact(0);
        Vector3 dir = transform.position - cp.point; // ���������������� ź��ġ �� ����
        rigid.AddForce((dir).normalized * speed);
    }
}
