using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //private
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //calculate the direction and add force in that direction (multiplied by the m_BlackholeGravityForce variable).
        Vector3 dir = (GameManagerX.instance.m_Blackhole.transform.position - transform.position).normalized;
        rb2D.AddForce(dir * GameManagerX.instance.m_BlackholeGravityForce * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if the ball hits de player, it will destroy it self.
        if (collision.gameObject.name.Contains("Player"))
        {
            UIManagerX.instance.AddScore();
            Destroy(gameObject);
        }
    }
}
