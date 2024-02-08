using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSaveGeneral
{
    public class ManagerController : MonoBehaviour
    {
        // The ManagerController can help us control the order of which manager classes are each setting themselves up
        // Since we cannot guarantee any order from Awake() or Start()

        public ManagerBase[] managers;


        void Start()
        {
            InitialiseManagers();
        }

        void InitialiseManagers()
        {
            foreach (ManagerBase man in managers)
            {
                man.Initialise();
            }
        }
    }
}