using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemUISettingScript : MonoBehaviour
{

    [SerializeField] private List<GemUIClass> gems = new List<GemUIClass>();

    private void Awake()
    {
        
        foreach(var item in gems)
        {

            if(PlayerPrefs.GetInt(item.gemKey) == int.MaxValue)
            {



            }

        }

    }

}
