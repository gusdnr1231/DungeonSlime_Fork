using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager
{
    
    private GemSaveFile gemSaveFile;

    private void NullChack()
    {

        if (gemSaveFile == null)
        {

            gemSaveFile = Managers.Save.LoadFile<GemSaveFile>("Gem");

        }

    }

    public bool ClearChack(string tag)
    {

        NullChack();

        return gemSaveFile.clearTag.Find(x => x == tag) != null;

    }

    public void SetClear(string tag) 
    {
     
        NullChack();

        gemSaveFile.clearTag.Add(tag);
     
    }

}
