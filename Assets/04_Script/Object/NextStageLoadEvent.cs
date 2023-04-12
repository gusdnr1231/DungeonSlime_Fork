using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageLoadEvent : MonoBehaviour
{
    
    public void Load()
    {

        Managers.Map.SetCurrentStageNumber(Managers.Map.currentStageNum + 1);
        Managers.Map.LoadMap();

    }

}
