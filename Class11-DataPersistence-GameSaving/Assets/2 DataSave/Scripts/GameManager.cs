using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSaveGeneral
{
    public class GameManager : ManagerBase
    {
        public static GameManager instance;

        public Player player;

        // Singleton
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        // From ManagerController we know that this Initialise is called after Initialie in the GameSaveManager
        public override void Initialise()
        {
            if (GameSaveManager.instance.isDataLoaded)
            {
                print("Found save data. Restoring player position");
                RestorePlayerPosition();
            }
        }

        void RestorePlayerPosition()
        {
            player.transform.position = GameSaveManager.instance.playerPosition;
        }

        // Button click action
        public void SaveBinary()
        {
            GameSaveManager.instance.SaveBinary();
            //GameSaveManager.instance.SaveGameDataBadWay();
        }

        // Button click action
        public void LoadBinary()
        {
            GameSaveManager.instance.LoadBinary();
            //GameSaveManager.instance.LoadGameDataBadWay();

            if (GameSaveManager.instance.isDataLoaded)
            {
                RestorePlayerPosition();
            }
        }

        public void SaveJson()
        {
            GameSaveManager.instance.SaveJSON();
        }

        public void LoadJson()
        {
            GameSaveManager.instance.LoadJSON();

            if (GameSaveManager.instance.isDataLoaded)
            {
                RestorePlayerPosition();
            }
        }
    }
}