using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/LoadingText")]
public class LoadingTextSO : ScriptableObject
{

    [field:SerializeField] public string[] loadingText { get; private set; }

}
