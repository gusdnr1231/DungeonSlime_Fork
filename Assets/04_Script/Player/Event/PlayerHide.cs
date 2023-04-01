using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : PlayerRoot
{

    private List<IEventObject> playerEvent = new List<IEventObject>();

    protected override void Awake()
    {

        base.Awake();
        input.OnHideEvnet += Hide;
        input.OnBounceEvent += Bounce;

    }

    private void Hide()
    {



    }

    private void Bounce()
    {


    }

}
