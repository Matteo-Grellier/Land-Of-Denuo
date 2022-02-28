using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    public enum State
	{
        isFishing,
        isNotFishing
	}

    protected Vector2 direction;
    public Animator animator;
    public static State state;
    int time_remaining;
    public static float elapsedTime;
    public static int startTime;

    // Start is called before the first frame update
    void Start()
    {
        state = State.isNotFishing;
        time_remaining = (int)Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        startTime = (int)Time.time;
        if (Player.state == Player.State.isFishing)
        {}
        else
        {
            this.movement.x = Input.GetAxisRaw("Horizontal");
            this.movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
            
        

        if(movement.x != 0 && movement.y == 0 || movement.x == 0 && movement.y != 0)
        {
            animator.SetFloat("PreviousHorizontal", movement.x);
            animator.SetFloat("PreviousVertical", movement.y);
        }

        if (Input.GetKeyDown(KeyCode.E) || state == State.isFishing)
        {   
            elapsedTime += Time.deltaTime;
            state = State.isFishing;
            Fishing.Is_fishing_sucessfull(time_remaining);
        }
    }

    Vector3Int GetTilePosition()
    {
        Vector3Int tPos = grid.WorldToCell(rb.transform.position);
        Debug.Log("name : " + tilemap.GetTile(tPos).name + " & position : " + tPos);
        return tPos;
    }

}
