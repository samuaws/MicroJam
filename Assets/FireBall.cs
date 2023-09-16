using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject boom;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            Destroy(collision.gameObject);
            Instantiate(boom , collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
