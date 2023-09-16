using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
    public GameObject grenade;
    public Transform gunTip;
    public float shotRange;
    public float grappelCheckRadius;
    public GameObject poroDead;
    Animator anim;
    private void Awake()
    {
        actions = new Actions();
        actions.Enable();
        actions.Abilities.Dash.performed += _ => ActiveDash();
        actions.Abilities.Invisible.performed += _ => ActiveInvisible();
        actions.Abilities.Grappel.performed += _ => ActiveGrapple();
        actions.Abilities.fireball.performed += _ => ActiveFireBall();

        actions.Abilities.Ability.performed += _ => DoAbility();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (!grappling.IsGrappling()) anim.SetBool("grappel", false);
        
    }
    IEnumerator DashCouroutine()
    {
        float startTime = Time.time;
        anim.SetBool("dash", true);
        AudioManager.instance.PlaySoundEffect(Abilities.dash);
        while (Time.time < startTime + dashTime)
        {
            controller.Move(transform.forward * dashSpeed);
            yield return null;
        }
        anim.SetBool("dash", false);
    }
    void Dash()
    {
        StartCoroutine(DashCouroutine());
    }

    void Invisible()
    {
        StartCoroutine(InvisibleCouroutine());
    }
    public void Grappel()
    {
        grappling.StartGrapple();
        AudioManager.instance.PlaySoundEffect(Abilities.grappel);
        anim.SetBool("grappel", true);

    }

    IEnumerator InvisibleCouroutine()
    {
        anim.SetBool("invisible", true);
        AudioManager.instance.PlaySoundEffect(Abilities.invisible);
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
    public void ActiveDash()
    {
        if (GameManager.Instance.poroObtained[Abilities.dash].count > 0)
        {
            GameManager.Instance.currentAbility = Abilities.dash;
            GameManager.Instance.poroObtained[Abilities.dash].count--;
            GameObject var = GameManager.Instance.poroObtained[Abilities.dash].poro[0];
            GameManager.Instance.poroObtained[Abilities.dash].poro.RemoveAt(0);
            Instantiate(poroDead, var.transform.position, Quaternion.identity);
            Destroy(var);


        }
    }
    public void ActiveInvisible()
    {
        if (GameManager.Instance.poroObtained[Abilities.invisible].count > 0)
        {
            GameManager.Instance.currentAbility = Abilities.invisible;
            GameManager.Instance.poroObtained[Abilities.invisible].count--;
            GameObject var = GameManager.Instance.poroObtained[Abilities.invisible].poro[0];
            GameManager.Instance.poroObtained[Abilities.invisible].poro.RemoveAt(0);
            Instantiate(poroDead, var.transform.position, Quaternion.identity);
            Destroy(var);
        }
    }
    public void ActiveGrapple()
    {
        if (GameManager.Instance.poroObtained[Abilities.grappel].count > 0)
        {
            GameManager.Instance.currentAbility = Abilities.grappel;
            GameManager.Instance.poroObtained[Abilities.grappel].count--;
            GameObject var = GameManager.Instance.poroObtained[Abilities.grappel].poro[0];
            GameManager.Instance.poroObtained[Abilities.grappel].poro.RemoveAt(0);
            Instantiate(poroDead, var.transform.position, Quaternion.identity);
            Destroy(var);
        }
    }
    public void ActiveFireBall()
    {
        if (GameManager.Instance.poroObtained[Abilities.fireBall].count > 0)
        {
            GameManager.Instance.currentAbility = Abilities.fireBall;
            GameManager.Instance.poroObtained[Abilities.fireBall].count--;
            GameObject var = GameManager.Instance.poroObtained[Abilities.fireBall].poro[0];
            GameManager.Instance.poroObtained[Abilities.fireBall].poro.RemoveAt(0);
            Instantiate(poroDead, var.transform.position, Quaternion.identity);
            Destroy(var);
        }
    }
    void FireBall()
    {
        StartCoroutine(FireBallCouroutuine());
    }
    void FireBallActions()
    {
        
        GameObject fireball =  Instantiate(grenade, gunTip.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shotRange + gunTip.transform.right, ForceMode.Impulse);
        anim.SetBool("throw", false);
    }
    IEnumerator FireBallCouroutuine()
    {
        AudioManager.instance.PlaySoundEffect(Abilities.fireBall);
        anim.SetBool("throw", true);
        yield return new WaitForSeconds(.5f);
        FireBallActions();
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
                if(Physics.SphereCast(Camera.main.transform.position , grappelCheckRadius ,Camera.main.transform.forward ,  out RaycastHit hit))
                {
                    if (hit.collider.gameObject.CompareTag("Grappel"))
                    {
                        Grappel();
                        GameManager.Instance.currentAbility = Abilities.nothing;
                    }
                }
                break;

            case Abilities.fireBall:
                FireBall();
                GameManager.Instance.currentAbility = Abilities.nothing;
                break;

        }
    }

}
