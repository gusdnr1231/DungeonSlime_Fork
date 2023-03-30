using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager
{

    private ProjectSettingSO projectSettingSO;

    public bool isKeyboard => projectSettingSO.isKeyboard;

    public void Setting()
    {

        projectSettingSO = Resources.Load<ProjectSettingSO>("Setting/ProjectSetting");

    }

}
