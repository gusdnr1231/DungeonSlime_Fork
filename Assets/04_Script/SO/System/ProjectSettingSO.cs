using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectSetting" , menuName = "SO/ProjectSetting")]
public class ProjectSettingSO : ScriptableObject
{

    [field: SerializeField] public bool isKeyboard;

}
