using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collider other)
         {
             if (other.gameObject.tag == "Player")
             {
                 Physics.IgnoreCollision(other, GetComponent<Collider>());
             }
         }
}
