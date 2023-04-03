using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{

    public int currentStageNum { get; private set; } = 1;

    public void SetCurrentStageNumber(int number)
    {

        currentStageNum = number;

    }

}
