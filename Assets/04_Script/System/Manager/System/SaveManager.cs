using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager
{
    
    public void SaveFile<T>(T obj, string fileName)
    {

        var jsonObject = JsonUtility.ToJson(obj);

        File.WriteAllText(Application.dataPath + $"/{fileName}.json", jsonObject);

    }

    public T LoadFile<T>(string fileName)
    {

        var obj = File.ReadAllText(Application.dataPath + $"/{fileName}.json");

        if (obj == "") return default;

        return JsonUtility.FromJson<T>(obj);

    }

}
