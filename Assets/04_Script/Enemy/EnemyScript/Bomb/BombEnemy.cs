using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombEnemy : EnemyRoot
{

    private const float increaseValue = 0.2f;
    private const float decreaseValue = 0.0002f;

    [SerializeField] private float radiua;
    [SerializeField] private GameObject particle;

    private Generator generator;
    private Tilemap tilemap;
    private PlayerHide playerHide;
    private GameObject jumpCheck;
    private GameObject possibleCheck;
    private bool willBomb;

    protected override void Awake()
    {

        base.Awake();
        tilemap = GameObject.FindWithTag("Breakable").GetComponent<Tilemap>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerHide = FindObjectOfType<PlayerHide>();
        possibleCheck = transform.GetChild(0).gameObject;
        jumpCheck = transform.GetChild(1).gameObject;
        generator = transform.parent.GetComponent<Generator>();
    }

    private void Update()
    {
        if(!willBomb)
            spriteRenderer.color += new Color(0, decreaseValue, decreaseValue, 0);

        if (spriteRenderer.color.b <= 0 && !willBomb)
        {

            willBomb = true;
            jumpCheck.SetActive(false);
            playerHide.Bounce();
            possibleCheck.SetActive(false);
            gameObject.layer = 0;
            StartCoroutine(ColorChange(0.5f, 5));

        }
    }

    void Touch()
    {
        spriteRenderer.color -= new Color(0, increaseValue, increaseValue, 0);
    }

    IEnumerator ColorChange(float time, int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(time);
            spriteRenderer.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(time);
        }

        GameObject part = Instantiate(particle, transform.position, Quaternion.identity);
        part.GetComponent<ParticleSystem>().Play();

        RemoveTilesInRadius(radiua);
        PlayerRadius();
        BossRadius();
        generator.Create();

        Destroy(gameObject);
    }

    void RemoveTilesInRadius(float radius)
    {
        Vector3Int centerCell = tilemap.WorldToCell(transform.position);
        int cellRadius = Mathf.CeilToInt(radius / tilemap.cellSize.x);

        for (int x = -cellRadius; x <= cellRadius; x++)
        {
            for (int y = -cellRadius; y <= cellRadius; y++)
            {
                Vector3Int cell = new Vector3Int(centerCell.x + x, centerCell.y + y, centerCell.z);
                Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);

                if (Vector3.Distance(transform.position, cellCenter) <= radius)
                {
                    tilemap.SetTile(cell, null);

                    GameObject part = Instantiate(particle, cell, Quaternion.identity);
                    part.GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }

    void PlayerRadius()
    {

        var obj = Physics2D.OverlapCircle(transform.position, radiua, LayerMask.GetMask("Player"));

        if (obj)
        {

            //MapBy �ɰ���
            var copo = obj.GetComponent<DieSensor>();
            copo.InvokeDieEvent();

        }

    }

    void BossRadius()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radiua);
    }

    public override void AddEvent()
    {

        jumpCheck.SetActive(true);
        input.OnJumpEvent += Touch;

    }

    public override void RemoveEvent()
    {

        jumpCheck.SetActive(false);
        input.OnJumpEvent -= Touch;

    }
}
