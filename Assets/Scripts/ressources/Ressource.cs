using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour
{
    private bool playerInCollider = false;
    private bool canCut = true;

    public bool isTree;

    private float nextTime = 0.0f;

    public int hp = 100;
    public int timeToDestroy = 20;

    public GameObject item;
    public GameObject leftOvers;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInCollider = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInCollider = false;
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            // Instantiate(item, transform.position, transform.rotation);
            Instantiate(leftOvers, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.R) && playerInCollider == true && canCut == true)
        {
            ShakeTree(Time.time);
            hp = hp - timeToDestroy;

            int chance = Random.Range(1, 4);
            if (chance == 1 || chance == 2)
            {
                PopItem();
            }
        }

        if (Time.time >= nextTime && canCut == false)
        {
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
            canCut = true;
        }
    }

    void ShakeTree(float time)
    {
        transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        nextTime = time + 0.05f;
        canCut = false;
    }

    void PopItem()
    {
        GameObject itemIsntance = Instantiate(item, transform.position, transform.rotation);
        itemIsntance.transform.position =  (Vector2)transform.position +(Random.insideUnitCircle * 1  );
    }


}
