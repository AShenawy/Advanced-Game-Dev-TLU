using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : ManagerBase
{
    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void InitialiseManager()
    {
        base.InitialiseManager();
        print(name);
    }
}
