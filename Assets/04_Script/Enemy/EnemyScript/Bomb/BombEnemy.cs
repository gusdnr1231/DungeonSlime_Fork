using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombEnemy : EnemyRoot
{
    const float increaseValue = 0.2f;
    const float decreaseValue = 0.01f;

    public Tilemap tilemap;
    [SerializeField] float radiua;
    bool willBomb;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //if(!willBomb)
        //    spriteRenderer.color += new Color(0, decreaseValue, decreaseValue, 0);

        if (spriteRenderer.color.b <= 0 && !willBomb)
        {
            willBomb = true;
            StartCoroutine(ColorChange(0.5f, 5));
        }
    }

    void Touch()
    {
        Debug.Log("touch");
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

        RemoveTilesInRadius(radiua);
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
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radiua);
    }

    public override void AddEvent()
    {

        input.OnJumpEvent += Touch;

    }

    public override void RemoveEvent()
    {

        input.OnJumpEvent -= Touch;

    }
}
