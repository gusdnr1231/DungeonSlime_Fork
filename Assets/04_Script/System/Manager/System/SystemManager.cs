using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager
{

    public ProjectSettingSO projectSettingSO {  get; private set; }

    public void Setting()
    {

        projectSettingSO = Resources.Load<ProjectSettingSO>("Setting/ProjectSetting");

    }

}
