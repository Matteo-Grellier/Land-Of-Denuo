using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask playerlayers;
    public GameObject target;
    public Ennemies ennemiesScript;

    private bool isFirstAttack = true;

    public float attackRange = 0.5f;
    public float attackDamage = 0f;

    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    // public float stopAttackTime = 0f;

    void Update()
    {

        if (Time.time >= nextAttackTime)
        {

            if (target = GameObject.FindGameObjectWithTag("Player"))
            {

                if (ennemiesScript.state == Ennemies.State.Attack)
                {

                    if ( isFirstAttack == true )
                    {
                        animator.SetBool("Attack", true);
                        nextAttackTime = Time.time + attackRate + 0.20f;
                        isFirstAttack = false;
                    }
                    else
                    {
                        // nextAttackTime = Time.time + 1f / attackRate;
                        nextAttackTime = Time.time + attackRate + attackRate;
                        Attack();
                        // stopAttackTime = Time.time + 1f;
                    }
                }
            }
        }
        
        // if (Time.time >= stopAttackTime)
        // {
        //     if (animator.GetBool("Attack") == true ) 
        //     {
        //         animator.SetBool("Attack", false);
        //     }
        // }
        if ( Vector2.Distance(transform.position, target.transform.position) > ennemiesScript.targetRange )
        {
            animator.SetBool("Attack", false);
            // HERE a remtrre pour que ça marche, c juste pour test que j'enleve
        }


    }

    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerlayers);


        foreach (Collider2D player in hitPlayer)
        {
            //animator.SetTrigger("Attack");
            animator.SetBool("Attack", true);
            player.GetComponent<Player>().TakeDamage(attackDamage);
            // stopAttackTime = Time.time + 1f;
            Debug.Log("HITING PLAYER");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}