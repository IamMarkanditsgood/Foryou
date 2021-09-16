using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("light1");

        if (other.gameObject.tag == "light")
        {
            print("light");
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("light1");

    //    if (collision.collider.gameObject.tag == "light")
    //    {
    //        print("light");
    //    }
    //}
}
