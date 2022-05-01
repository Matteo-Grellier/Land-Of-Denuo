using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Player : Characters
{
    public enum State
    {
        isFishing,
        isNotFishing
    }

    //for fishing
    float facingX = 0;
    float facingY = 0;

    protected Vector2 direction;
    public Animator animator;

    public static State state;
    int time_remaining;
    public static float elapsedTime;

    public float nextRessourceTime = 0f;

    public Tilemap TileMapWater;
    public string tilename = "";

    //for scene transition purpose 
    public static int lastTakenTpNumber;
    public Grid gridLayout;
    public Tile tile;
    public Vector2Int location;


    // Start is called before the first frame update
    void Start()
    {
        state = State.isNotFishing;
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

        //Mettre la condition de s'il y a la canne a p�che.
        if(TileMapWater != null)
        {
            ThereIsWater(facingX, facingY);
            FishingTime();
        }

        if (Time.time >= nextRessourceTime){
            
            animator.SetBool("Pioche", false);
            animator.SetBool("Hache", false);

            if (Input.GetKeyDown(KeyCode.R))
            {
                GetRessources();
            }
        }
       

    }

    void GetRessources()
    {
        Collider2D[] hiRessources = Physics2D.OverlapCircleAll(this.transform.position, 1, LayerMask.GetMask("Ressources"));

        foreach (Collider2D GameObject in hiRessources)
        {
            if (GameObject.GetComponent<Ressource>().isTree == true )
            {
                animator.SetBool("Hache", true);
                nextRessourceTime = nextRessourceTime = Time.time + 0.2f ;
            }
            else
            {
                animator.SetBool("Pioche", true);
                nextRessourceTime = nextRessourceTime = Time.time + 0.2f ;
            }
            
        }
    }

    public void FishingTime()
    {
        //Si on appuie sur E et qu'il y a de l'eau (ou que l'�tat du joueur est "isFishing" d'o� le fait qu'il rerentre a chaque fois qu'il est en isFishing)
        if ((Input.GetKeyDown(KeyCode.P) && TileMapWater.GetTile((Vector3Int)location) != null) || state == State.isFishing)
        {
            state = State.isFishing; // On met en isFishing (tant qu'il n'a pas fini).

            time_remaining = (int)Random.Range(5, 10); //Temps d'attente avant que le poisson mordre (al�atoire).
            elapsedTime += Time.deltaTime; // On ajoute une seconde de plus.
            
            Fishing.IsFishingSucessfull(time_remaining); // On v�rifie que la p�che est une r�ussite ou un �chec.
        }
    }

    public string GetTileName(Vector2 pos)
    {
        location = (Vector2Int)TileMapWater.WorldToCell(pos);
        if (TileMapWater.GetTile((Vector3Int)location) == null)
        {
            return "";
        }
        else
        {
            return TileMapWater.GetTile((Vector3Int)location).name;
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

    public override void Die()
    {
        SceneManager.LoadScene(3);
    }

}