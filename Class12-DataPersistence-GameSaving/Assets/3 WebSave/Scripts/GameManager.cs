using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSaveGeneral;

namespace GameSaveWeb
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

        public override void Initialise()
        {
            if (GameSaveManager.instance.isDataLoaded)
            {
                SetPlayerPosition();
            }
        }

        void SetPlayerPosition()
        {
            player.transform.position = GameSaveManager.instance.playerPosition;
        }

        // Button click action
        public void OnLoadButtonClicked()
        {
            GameSaveManager.instance.LoadGameData();
            if (GameSaveManager.instance.isDataLoaded)
            {
                SetPlayerPosition();
            }
        }
    }
}