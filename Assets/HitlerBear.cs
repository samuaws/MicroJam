using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitlerBear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.Instance.invisible)
        {
            GameManager.Instance.GameOver();
        }
    }
}
