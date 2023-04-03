#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapEditor : MonoBehaviour
{

    [SerializeField] private int mapNumber;

    public void CreateDefaultMap()
    {

        if (mapNumber <= 0) return;

        #region 디폴트 맵 생성

        GameObject mainMap = CreateObject(mapNumber.ToString());
        mainMap.AddComponent<Grid>();

        #endregion

        #region 타일맵 오브젝트 생성

        GameObject defaultTilemapObject = CreateObject("TileMap");
        defaultTilemapObject.AddComponent<Tilemap>();
        defaultTilemapObject.AddComponent<TilemapRenderer>();

        #endregion

    }

    private GameObject CreateObject(string name = "Obj")
    {

        return new GameObject(name);

    }

}
#endif