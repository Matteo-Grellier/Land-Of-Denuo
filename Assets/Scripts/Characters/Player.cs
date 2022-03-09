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
    static string tileName = "";
    
    //for scene transition purpose 
    public static int lastTakenTpNumber;
    public Grid gridLayout;
    public Tilemap Tilemap_blocking_object;
    public Tile tile;
    public Vector2Int location;


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
        if(movement.x != 0 || movement.y != 0)
        {
            facingX = movement.x;
            facingY = movement.y;
            
        }

        ThereIsWater(facingX,facingY);

        // if the player has do a new input, change the variable value.
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

        if (Input.GetKeyDown(KeyCode.E) && Tilemap_blocking_object.GetTile((Vector3Int)location) != null || state == State.isFishing )
        {   
            elapsedTime += Time.deltaTime;
            state = State.isFishing;
            Fishing.Is_fishing_sucessfull(time_remaining);
        }
    }

    public string GetTileName(Vector2 pos)
    {
        location = (Vector2Int)Tilemap_blocking_object.WorldToCell(pos);
        if (Tilemap_blocking_object.GetTile((Vector3Int)location) == null)
        {
            return "";
        }
        else
        {
            return Tilemap_blocking_object.GetTile((Vector3Int)location).name;
        }
    }


    public void ThereIsWater(float facingX, float facingY)
    {
        switch (facingX)
        {
            case 1:
                positionToVerify = new Vector2(rb.transform.position.x + 1, rb.transform.position.y);
                tilename = GetTileName(positionToVerify);
                break;
            case -1:
                positionToVerify = new Vector2(rb.transform.position.x - 1, rb.transform.position.y);
                tilename = GetTileName(positionToVerify);
                break;
            default:
                break;
        }
        switch (facingY)
        {
            case 1:
                positionToVerify = new Vector2(rb.transform.position.x, rb.transform.position.y + 1);
                tilename = GetTileName(positionToVerify);
                break;
            case -1:
                positionToVerify = new Vector2(rb.transform.position.x, rb.transform.position.y - 1);
                tilename = GetTileName(positionToVerify);
                break;
            default:
                break;
        }
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
