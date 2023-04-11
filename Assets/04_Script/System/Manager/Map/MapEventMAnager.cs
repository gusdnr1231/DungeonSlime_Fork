using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEventManager : MonoBehaviour
{
    
    public void LoadMap(int count)
    {

        Managers.Map.SetCurrentStageNumber(count);
        Managers.Map.LoadMap();

    }

}
