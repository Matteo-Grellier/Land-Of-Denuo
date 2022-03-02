using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Characters
{
    public enum State
    {
        isFishing,
        isNotFishing
    }

    float facingX = 0;
    float facingY = 0;


    protected Vector2 direction;
    public Animator animator;
    public static State state;
    int time_remaining;
    public static float elapsedTime;
    public static int startTime;
    static int facingDirection = 0;

    string tileName;
    //for scene transition purpose 
    public static int lastTakenTpNumber;
    
    


    // Start is called before the first frame update
    void Start()
    {
        state = State.isNotFishing;
        time_remaining = (int)Random.Range(5, 10);
        SpawnTP();
    }

    // Update is called once per frame
    void Update()
    {
        // if the player has do a new input, change the variable value.
        getTileName();
        startTime = (int)Time.time;
        if (state == State.isFishing)
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
        Debug.Log(getTileName());
        if (Input.GetKeyDown(KeyCode.E) && getTileName() == "AWater_pipo_60" || state == State.isFishing )
        {   
            elapsedTime += Time.deltaTime;
            state = State.isFishing;
            Fishing.Is_fishing_sucessfull(time_remaining);
        }
    }

    protected void DamagePlayer()
    {
    
    }

    string getTileName()
    {
        Vector3 positionToVerify;
        //Debug.Log("Axis : " + this.movement.x);
        //Debug.Log(tileName);
        //Debug.Log("player position : " + tPos);
        
        positionToVerify = new Vector3(rb.transform.position.x + 1, rb.transform.position.y, rb.transform.position.z);
        Vector3Int tPos = grid.WorldToCell(positionToVerify);
        if (tilemap.GetTile(tPos) != null)
        { 
            tileName = tilemap.GetTile(tPos).name;
            Debug.Log("name : " + tilemap.GetTile(tPos).name + " & position : " + tPos);
        }
        else
        {
            tileName = "null";
        }
        return tileName;
    }

    //To spawn the player at the good spot depending on wich teleporter he took
    void SpawnTP() {
        Vector3 position1 = new Vector3(0.06f, -3.12f, 0.0f);
        Vector3 position2 = new Vector3(6.49f, -2.76f, 0.0f);
        Vector3 position3 = new Vector3(8.78f, 0.06f, 0.0f);
        Vector3 position4 = new Vector3(-8.21f, 1.86f, 0.0f);

        switch(lastTakenTpNumber) {
            case 1:
                transform.position = position1;
                break;
            case 2:
                transform.position = position2;
                break;
            case 3:
                transform.position = position3;
                break;
            case 4:
                transform.position = position4;
                break;
            }
    }

}
