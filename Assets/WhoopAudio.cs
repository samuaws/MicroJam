using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopAudio : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Whoop());
    }
    public AudioSource audioSource;
 IEnumerator Whoop()
    {
        int time = Random.Range(20, 120);
        yield return new WaitForSeconds(time);
        audioSource.Play();
        StartCoroutine(Whoop());
    }
}
