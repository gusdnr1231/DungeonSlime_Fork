using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCutSceneManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] List<string> story;

    private void Start()
    {
        StartCoroutine(Read());
    }

    IEnumerator Read()
    {
        for (int k = 0; k < story.Count; k++)
        {
            text.text = "";
            for (int i = 0; i < story[k].Length; i++)
            {
                text.text += story[k][i];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1f);
        }
        text.text = "";

    }
}
