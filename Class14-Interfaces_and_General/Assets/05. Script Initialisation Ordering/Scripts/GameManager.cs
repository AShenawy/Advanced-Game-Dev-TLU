using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<ManagerBase> managers;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (ManagerBase manager in managers)
        {
            Instantiate(manager);
            manager.InitialiseManager();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
