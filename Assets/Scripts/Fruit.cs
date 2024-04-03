using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        };
    }


    // private void OnDestroy()
    // {
    //     GameManager.Instance.DecreaseScore();
    // }
}
