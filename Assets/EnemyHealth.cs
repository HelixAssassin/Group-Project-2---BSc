using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] private Canvas canvas;

    [SerializeField] private Image healthBar;

    public float Health = 30f;

    protected bool isDead = false;

    protected Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amnt)
    {
        Health -= amnt;

        if (Health <=0)
        {
            print("Enemy Has Died");        

            Dead();

            isDead = true;
        }

        healthBar.fillAmount = Health / 100;

        anim.SetBool("Damaged", true);

        print("Enemy took some damage");
    }

    private void Dead()
    {
        anim.SetBool("Dead", true);

        Destroy(GetComponent<CharacterController>());

        Destroy(GetComponent<CapsuleCollider>());

        canvas.enabled = false;

        Destroy(gameObject, 1);

        GameObject.Find("GameManager").GetComponent<GameManager>().AddKill();

        isDead = true;
    }

    private void DisableDamage()
    {
        anim.SetBool("Damaged", false);
    }
}
