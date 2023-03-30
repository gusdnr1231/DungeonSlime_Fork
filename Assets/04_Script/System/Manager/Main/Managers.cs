using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{

    private static Managers instance;

    public static Managers Instance { get { Init(); return instance; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {

        if(instance == null)
        {

            GameObject go = GameObject.Find("@Managers");

            if(go == null)
            {

                go = new GameObject("@Managers");
                instance = go.AddComponent<Managers>();

                DontDestroyOnLoad(go);

            }
            
            SettingManager(go);
            
        }


    }

    public static void SettingManager(GameObject obj)
    {



    }

}
