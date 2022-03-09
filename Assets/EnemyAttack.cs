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

    public float attackRange = 0.5f;
    public int attackDamage = 10;

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
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                    // stopAttackTime = Time.time + 1f;
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