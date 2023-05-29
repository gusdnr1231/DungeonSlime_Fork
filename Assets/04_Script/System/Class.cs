using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Class
{

    [System.Serializable]
    public class GemUIClass
    {

        public Image gemIconImage;
        public string gemKey;

    }

    [System.Serializable]
    public class GemSaveFile
    {

        public List<string> clearTag = new List<string>(); 

    }

    [System.Serializable]
    public class ChapterSaveClass
    {

        public string chapterName;
        public bool isLock;

    }

    [System.Serializable]
    public class ChapterSaveFile
    {

        public List<ChapterSaveClass> chapterSaveClasses = new List<ChapterSaveClass>();

    }

}