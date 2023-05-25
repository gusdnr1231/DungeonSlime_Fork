using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{

    private static Managers instance;
    private static SystemManager systemManage;
    private static MapManager mapManager;
    private static SaveManager saveManager;

    public static Managers Instance { get { Init(); return instance; } }
    public static SystemManager SystemManage { get { Init(); return systemManage; } }
    public static MapManager Map { get { Init(); return mapManager; } }
    public static SaveManager Save { get { Init(); return saveManager; } }

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

        mapManager = obj.AddComponent<MapManager>();
        systemManage = new SystemManager();
        systemManage.Setting();
        saveManager = new SaveManager();

    }

}
