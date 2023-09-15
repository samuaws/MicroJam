using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abelities : MonoBehaviour
{
    [Range(0f, 50f)]
    public float dashSpeed;
    CharacterController controller;
    public float dashTime;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(transform.forward * dashSpeed);
            yield return null;
        }
    }


}
