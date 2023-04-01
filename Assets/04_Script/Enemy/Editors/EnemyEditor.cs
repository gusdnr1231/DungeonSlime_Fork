#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyEditor : MonoBehaviour
{
    
    [SerializeField] private string enemyName;

    private GameObject mainObject;

    public void CreateEnemy()
    {

        if (enemyName == "")
        {

            Debug.LogError("enemyName이 잘못됨");
            return;

        }

        #region 메인 오브젝트 생성

        mainObject = CreateObject(enemyName);
        mainObject.AddComponent<SpriteRenderer>();
        mainObject.AddComponent<Animator>();
        mainObject.AddComponent<EnemyMovementHide>();
        mainObject.AddComponent<EnemyJumpHide>();
        mainObject.AddComponent<Rigidbody2D>();
        mainObject.AddComponent<BoxCollider2D>();

        mainObject.layer = 3;

        #endregion

        #region 땅 감지 오브젝트 생성

        var groundObj = CreateObject("groundCol");
        groundObj.AddComponent<BoxCollider2D>().isTrigger = true;
        groundObj.GetOrAddComponent<GroundCol>();
        groundObj.transform.SetParent(mainObject.transform);

        #endregion

    }

    public void SaveEnemy()
    {

        if (enemyName == "")
        {

            Debug.LogError("enemyName이 잘못됨");
            return;

        }

        if(mainObject == null)
        {

            Debug.LogError("Enemy오브젝트가 잘못됨");
            return;

        }

        PrefabUtility.SaveAsPrefabAsset(mainObject,
            Application.dataPath + $"/Resources/Enemy/{enemyName}.prefab");

        enemyName = "";

        Debug.Log("저장 완료");

        DestroyImmediate(mainObject);

        mainObject = null;
    }

    public void LoadEnemy()
    {

        if (enemyName == "")
        {

            Debug.LogError("enemyName이 잘못됨");
            return;

        }

        if (mainObject != null)
        {

            DestroyImmediate(mainObject);

        }

        mainObject = Instantiate(Resources.Load<GameObject>($"Enemy/{enemyName}"));
        mainObject.name = enemyName;

    }

    private GameObject CreateObject(string name = "Object")
    {

        return new GameObject(name);

    }

}
#endif