using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EnemyMovements : Ennemies
{
    public void moveEnemy(Vector3 p )
    {
        //Debug.Log(Player.Instance.transform.position.x - transform.position.x);
        //movement = new Vector2(Player.transform.position.x, Player.transform.position.y);
        //rb.MovePosition(rb.position + (movement * speedMovement * Time.fixedDeltaTime));
        //Debug.Log(Player.Instance.transform.position.x - transform.position.x);
        //Debug.Log(Player.Instance.transform.position.y - transform.position.y);

        if (rb.transform.position.x - transform.position.x == 0)
        {
            animator.SetFloat("Horizontal", p.x);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, p.x), speedMovement * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Vertical", rb.transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(p.x, transform.position.y), speedMovement * Time.deltaTime);
        }


        //if (Player.Instance.transform.position.x - GameObject.Find("Enemy").transform.position.x > 0 && Player.Instance.transform.position.y - GameObject.Find("Enemy").transform.position.y > 0)
        //{
        //    movement = new Vector2(0.5f, 0.5f);
        //    rb.MovePosition(rb.position + (speedMovement * Time.fixedDeltaTime * movement));
        //}
    }
}
