using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyBlock : MonoBehaviour
{
    Key _key;
    public
    List<Vector3Int> cellPositions;
    public List<Vector3Int> cellCollisions;
    Tilemap tilemap;

    [SerializeField]
    ParticleSystem particle;

    [SerializeField]
    float delayTime = 0.5f;
    [SerializeField]
    Vector3 Startpos;

    public void Delete() => StartCoroutine(deleteTile());

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
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
        for (int i = 0; i < cellCollisions.Count; i++)
        {
            tilemap.SetTile(cellCollisions[i], null);
            Particle(cellCollisions[i]);
        }

        for (int i = 0; i<cellPositions.Count;i++)
        {
            yield return new WaitForSeconds(delayTime);
            //여기에 사운드나 이펙트 추가할거 추가하기 근데 이대로면 메서드 추가해야할듯;
            tilemap.SetTile(cellPositions[i], null);
            Particle(cellPositions[i]);
        }
        cellPositions.Clear();
    }

    private void Particle(Vector3 pos)
    {
        pos += Vector3.right / 2 + Vector3.up / 2;
        ParticleSystem p = Instantiate(particle, pos, Quaternion.identity, this.transform);
        p.Play();
        Destroy(p.gameObject, 1f);
    }
}
