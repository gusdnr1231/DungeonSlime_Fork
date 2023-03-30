using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEditor : MonoBehaviour
{

    [SerializeField] private string enemyName;

    public void CreateEnemy()
    {

        var mainObject = CreateObject(enemyName);

    }

    private GameObject CreateObject(string name = "Object")
    {

        return new GameObject(name);

    }

}
