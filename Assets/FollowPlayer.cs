using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float speed; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = (GameManager.Instance.player.transform.position - new Vector3(1,1,1) - transform.position) * speed;
      //  transform.LookAt(GameManager.Instance.player.transform);
    }
}
