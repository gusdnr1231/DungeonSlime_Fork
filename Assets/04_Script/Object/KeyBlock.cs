using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyBlock : MonoBehaviour
{
    Key _key;
    public
    List<Vector3Int> cellPositions;
    public List<Vector3Int> cellCollisions;
    Tilemap tilemap;

    BoxCollider2D _boxcollider;

    [SerializeField]
    float delayTime = 0.5f;
    [SerializeField]
    Vector3 Startpos;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        _boxcollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        cellPositions.Add(tilemap.LocalToCell(Startpos));
        while (true)
        {
            if (tilemap.GetTile(cellPositions[cellPositions.Count - 1] + Vector3Int.up) != null && IsChecked(cellPositions[cellPositions.Count - 1] + Vector3Int.up))
            {
                cellPositions.Add(cellPositions[cellPositions.Count - 1] + Vector3Int.up);
            }
            else if (tilemap.GetTile(cellPositions[cellPositions.Count - 1] + Vector3Int.right) != null && IsChecked(cellPositions[cellPositions.Count - 1] + Vector3Int.right))
            {
                cellPositions.Add(cellPositions[cellPositions.Count - 1] + Vector3Int.right);
            }
            else if (tilemap.GetTile(cellPositions[cellPositions.Count - 1] + Vector3Int.down) != null && IsChecked(cellPositions[cellPositions.Count - 1] + Vector3Int.down))
            {
                cellPositions.Add(cellPositions[cellPositions.Count - 1] + Vector3Int.down);
            }
            else if (tilemap.GetTile(cellPositions[cellPositions.Count - 1] + Vector3Int.left) != null && IsChecked(cellPositions[cellPositions.Count - 1] + Vector3Int.left))
            {
                cellPositions.Add(cellPositions[cellPositions.Count - 1] + Vector3Int.left);
            }
            else
            {
                break;
            }
        }
    }

    bool IsChecked(Vector3Int vect)
    {
        foreach(var cellpos in cellPositions)
        {
            if(cellpos == vect) return false;
        }
        foreach(var collpos in cellCollisions)
        {
            if (collpos == vect) return false;
        }
        return true;
    }

    public IEnumerator deleteTile()
    {
        for (int i = 0; i<cellPositions.Count;i++)
        {
            yield return new WaitForSeconds(delayTime);
            //여기에 사운드나 이펙트 추가할거 추가하기 근데 이대로면 메서드 추가해야할듯;
            tilemap.SetTile(cellPositions[i], null);
        }
        cellPositions.Clear();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.transform.Find("Key").TryGetComponent<Key>(out _key))
                return;
            if (_key.gotKey)
            {
                Debug.Log(1);
                Vector3Int gridPosition = tilemap.WorldToCell(collision.transform.position);
                foreach(var collpos in cellCollisions)
                {
                    Debug.Log(2);
                    if (collpos == gridPosition)
                    {
                        Debug.Log(3);
                        StartCoroutine(deleteTile());
                    }
                }
            }
        }
    }

}
