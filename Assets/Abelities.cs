using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Abilities
{
    nothing,
    dash,
    invisible,
    fireBall,
    grappel
}
public class Abelities : MonoBehaviour
{
    [Range(0f, 50f)]
    public float dashSpeed;
    CharacterController controller;
    public float dashTime;
    public Actions actions;
    public float invisibleTIme;
    public Grappling grappling;
    Animator anim;
    private void Awake()
    {
        actions = new Actions();
        actions.Enable();
        actions.Abilities.Dash.performed += _ => ActiveDash();
        actions.Abilities.Invisible.performed += _ => ActiveInvisible();
        actions.Abilities.Grappel.performed += _ => ActiveGrapple();

        actions.Abilities.Ability.performed += _ => DoAbility();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {

    }
    IEnumerator DashCouroutine()
    {
        float startTime = Time.time;
        anim.SetBool("dash", true);
        while (Time.time < startTime + dashTime)
        {
            controller.Move(transform.forward * dashSpeed);
            yield return null;
        }
        anim.SetBool("dash", true);
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
        StartCoroutine(InvisibleCouroutine());
    }
    public void Grappel()
    {
        grappling.StartGrapple();

    }
    IEnumerator InvisibleCouroutine()
    {
        anim.SetBool("invisible", true);
        yield return new WaitForSeconds(1);
        GameManager.Instance.playerMesh.GetComponent<Renderer>().enabled = false;
        StartCoroutine(DesactivateInvisible());

    }
    IEnumerator DesactivateInvisible()
    {

        yield return new WaitForSeconds(invisibleTIme);
        anim.SetBool("invisible", false);
        Visible();
    }
    public void ActiveInvisible()
    {
        GameManager.Instance.currentAbility = Abilities.invisible;
    }
    public void ActiveGrapple()
    {
        GameManager.Instance.currentAbility = Abilities.grappel;
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
            case Abilities.grappel:
                Grappel();
                GameManager.Instance.currentAbility = Abilities.nothing;
                break;
        }
    }

}
