using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFix : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer render;

    void Start()
    {
        render = this.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (this.gameObject.transform.position.y >= player.transform.position.y)
        {
            render.sortingOrder = 0;
        }
        else 
        {
            render.sortingOrder = 2;
        }
    }
}
