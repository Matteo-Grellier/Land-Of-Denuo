using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemylayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;

    public float nextAttackTime = 0f;





    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime){
            
            animator.SetBool("Attack", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        animator.SetBool("Attack", true);
        nextAttackTime = nextAttackTime = Time.time + 0.2f ;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Ennemies>().TakeDamage(attackDamage);
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
