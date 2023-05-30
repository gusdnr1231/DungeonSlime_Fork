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
    public class ChapterSaveFile
    {

        public List<string> Clearchapter = new List<string>();
        
    }

}