using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Abilities
{
    nothing,
    dash,
    invisible,
    fireBall
}
public class Abelities : MonoBehaviour
{
    [Range(0f, 50f)]
    public float dashSpeed;
    CharacterController controller;
    public float dashTime;
    public Actions actions;
    public float invisibleTIme;
    private void Awake()
    {
        actions = new Actions();
        actions.Enable();
        actions.Abilities.Dash.performed += _ => ActiveDash();
        actions.Abilities.Invisible.performed += _ => ActiveInvisible();
        actions.Abilities.Ability.performed += _ => DoAbility();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {

    }
    IEnumerator DashCouroutine()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(transform.forward * dashSpeed);
            yield return null;
        }
    }
    void Dash()
    {
        StartCoroutine(DashCouroutine());
    }
    public void ActiveDash()
    {
        GameManager.Instance.currentAbility = Abilities.dash;
    }
    void Invisible()
    {
        GameManager.Instance.playerMesh.GetComponent<Renderer>().enabled = false;
        StartCoroutine(DesactivateInvisible());
    }
    IEnumerator DesactivateInvisible()
    {
        yield return new WaitForSeconds(invisibleTIme);
        Visible();
    }
    public void ActiveInvisible()
    {
        GameManager.Instance.currentAbility = Abilities.invisible;
    }
    void Visible()
    {
        GameManager.Instance.playerMesh.GetComponent<Renderer>().enabled = true;
    }
    public void DoAbility()
    {
        switch (GameManager.Instance.currentAbility)
        {
            case Abilities.nothing:
                break;
            case Abilities.dash:
                Dash();
                GameManager.Instance.currentAbility = Abilities.nothing;
                break;
            case Abilities.invisible: 
                Invisible();
                GameManager.Instance.currentAbility = Abilities.nothing;
                break;
        }
    }

}
