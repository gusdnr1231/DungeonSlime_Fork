using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TurtleEnemy : EnemyRoot
{
    const string waterTag = "Water";

    [SerializeField] private float waterSpeed;
    [SerializeField] private float jummpPower;

    EnemyMovementHide movementHide;
    GameObject waterTilemap;
    Rigidbody2D rb;

    bool isSwimming;

    protected override void Awake()
    {
        base.Awake();
        movementHide = gameObject.GetComponent<EnemyMovementHide>();
        waterTilemap = GameObject.FindWithTag(waterTag);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Swim();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(waterTag))
            movementHide.NewMoveSpeed(waterSpeed);
        else movementHide.NewMoveSpeed(waterSpeed - 2);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //닿았다가 다시 돌아가는거면 return;
        if (collision.transform.tag == waterTag)
        {
            Debug.Log(collision.name);
            isSwimming = !isSwimming;
        }
    }

    void Swim()
    {
        if (isSwimming)
        {
            input.OnJumpEvent += Fly;
            waterTilemap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.6f);
            waterTilemap.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        }
        else
        {
            input.OnJumpEvent -= Fly;
            waterTilemap.GetComponent<Tilemap>().color = Color.white;
            waterTilemap.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void Fly()
    {
        rb.velocity = Vector3.up * jummpPower;
    }

    public override void AddEvent()
    {

        waterTilemap.GetComponent<CompositeCollider2D>().isTrigger = true;

    }

    public override void RemoveEvent()
    {

        waterTilemap.GetComponent<CompositeCollider2D>().isTrigger = false;

    }
}
