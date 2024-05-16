using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ManagerBase
{
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    public override void InitialiseManager()
    {
        base.InitialiseManager();
        print(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
