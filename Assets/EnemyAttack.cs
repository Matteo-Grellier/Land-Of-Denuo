using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask playerlayers;
    public GameObject target;


    public float attackRange = 0.5f;
    public int attackDamage = 10;

    public float attackRate = 2f;
    public float nextAttackTime = 0f;



    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (target = GameObject.FindGameObjectWithTag("Player"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerlayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().TakeDamage(attackDamage);
            //Debug.Log("We hit" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}