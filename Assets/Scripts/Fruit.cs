using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private bool isSliced = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        };
    }

    public void SetSliced(bool sliced)
    {
        isSliced = sliced;
    }

    private void OnDestroy()
    {
        if (!isSliced){
            GameManager.Instance.DecreaseScore();
        }
    }
}
