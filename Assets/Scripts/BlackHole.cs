using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    void Update()
    {
        //rotate the blackhole on its Z axis.
        transform.Rotate(Vector3.back, 1f * transform.localScale.z / 8f);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //if the black hole gets hit by anything but the player, make it grow in size.
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            //set gameover, and destory the player.
            UIManagerX.instance.SetGameOver();
            Destroy(collision.gameObject);
        }
        else
        {
            //grow the blackhole and destory the object it touched.
            gameObject.transform.localScale = gameObject.transform.localScale + Vector3.one;
            Destroy(collision.gameObject);
        }
    }
}