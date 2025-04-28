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
            if (GameSaveManagerWeb.instance.isDataLoaded)
            {
                RestorePlayerPosition();
            }
        }

        void RestorePlayerPosition()
        {
            player.transform.position = GameSaveManagerWeb.instance.playerPosition;
        }

        public void OnSaveButtonClicked()
        {
            GameSaveManagerWeb.instance.SaveGame();
        }

        // Button click action
        public void OnLoadButtonClicked()
        {
            GameSaveManagerWeb.instance.LoadGameData();
            if (GameSaveManagerWeb.instance.isDataLoaded)
            {
                RestorePlayerPosition();
            }
        }
    }
}