using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager
{
    
    public void SaveMap<T>(T obj, string fileName)
    {

        var jsonObject = JsonUtility.ToJson(obj);

        File.WriteAllText(Application.dataPath + $"/{fileName}.json", jsonObject);

    }

    public T LoadMap<T>(string fileName)
    {

        var obj = File.ReadAllText(Application.dataPath + $"/{fileName}.json");

        return JsonUtility.FromJson<T>(obj);

    }

}
