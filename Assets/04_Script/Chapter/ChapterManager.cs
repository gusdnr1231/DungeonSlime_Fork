using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager
{

    private ChapterSaveFile chapterSaveFile;

    private void NullChack()
    {

        if (chapterSaveFile == null)
        {

            chapterSaveFile = new ChapterSaveFile();
            Managers.Save.SaveFile(chapterSaveFile, "Gem");

        }

    }

    public void Setting()
    {

        chapterSaveFile = Managers.Save.LoadFile<ChapterSaveFile>("Gem");

    }

    public bool ClearChack(string tag)
    {

        NullChack();

        return chapterSaveFile.Clearchapter.Find(x => x == tag) != null;

    }

    public void SetClear(string tag)
    {

        NullChack();

        chapterSaveFile.Clearchapter.Add(tag);
        Managers.Save.SaveFile(chapterSaveFile, "Gem");

    }

}
