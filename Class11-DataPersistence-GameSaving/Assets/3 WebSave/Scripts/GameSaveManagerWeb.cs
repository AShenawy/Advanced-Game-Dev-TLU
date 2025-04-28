using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GameSaveGeneral;

namespace GameSaveWeb
{
    public class GameSaveManagerWeb : ManagerBase
    {
        public static GameSaveManagerWeb instance;

        public bool isDataLoaded;
        public Vector3 playerPosition;


        // JS interaction with browser to force file saving on system
        [DllImport("__Internal")]
        private static extern void SyncFiles();


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
            LoadGameData();
        }

        public void SaveGame()
        {
            // ==== Save code just like other GameSaveManager ====
            SaveData saveData = new SaveData();
            saveData.SetPlayerPosition(GameManager.instance.player.transform.position);

            string jsonString = JsonUtility.ToJson(saveData, true);

            string savePath = Application.persistentDataPath + "/saveFile.jsonFile";
            using StreamWriter writer = new StreamWriter(savePath);
            writer.Write(jsonString);

            // ==== Afterwards, we add the WebGL related part ====

            // If running on WebGL, ensure browser syncs save file to local indexed DB file system
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                SyncFiles();
            }
        }

        public void LoadGameData()
        {
            // ==== Load code just like other GameSaveManager ====
            string savePath = Application.persistentDataPath + "/saveFile.jsonFile";

            if (File.Exists(savePath))
            {
                using StreamReader reader = new StreamReader(savePath);
                string jsonString = reader.ReadToEnd(); // ReadToEnd ensures we get all the information stored on the file

                SaveData saveData = JsonUtility.FromJson<SaveData>(jsonString);
                playerPosition = saveData.GetPlayerPosition();

                isDataLoaded = true;
                print("Save Manager: Data loading complete");
            }
            else
            {
                isDataLoaded = false;
                print("Save Manager: No file to load");
            }
        }
    }
}