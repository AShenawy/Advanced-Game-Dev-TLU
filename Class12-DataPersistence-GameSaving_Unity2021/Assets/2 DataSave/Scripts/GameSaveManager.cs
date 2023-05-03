using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GameSaveGeneral
{
    public class GameSaveManager : ManagerBase
    {
        public static GameSaveManager instance;

        public bool isDataLoaded;
        public Vector3 playerPosition;


        // Singleton
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }


        // From ManagerController we know that this Initialise is called before other managers
        public override void Initialise()
        {
            LoadGameData();
        }


        public void SaveGameData()
        {
            // Binary Formatter is what converts our data to binary values
            BinaryFormatter formatter = new BinaryFormatter();

            // We set the save file name and its file extension that we want it to be
            string savePath = Application.persistentDataPath + "/saveFile.whatever";

            // File Stream creates a file (FileMode.Create) to store the data the Binary Formatter produces on the hard disk
            FileStream stream = new FileStream(savePath, FileMode.Create);

            // Create a blank instance of save data class
            SaveData data = new SaveData();

            // Fill the class with data we want to save to disk, such as player position
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            data.SetPlayerPosition(playerPosition);

            // Tell the binary formatter to start converting data into binary and write it to the file (Serialize)
            formatter.Serialize(stream, data);

            // IMPORTANT: Must close the file stream when done. It's the equivalent of saving the file
            stream.Close();
        }


        public void LoadGameData()
        {
            // Get the save path and file name we created for our game
            string savePath = Application.persistentDataPath + "/saveFile.whatever";
            
            // Check if there's an actual file there to read from
            if (File.Exists(savePath))
            {
                // Binary formatter will convert back the data from binary
                BinaryFormatter formatter = new BinaryFormatter();

                // File Stream will open the file (FileMode.Open) at the given path
                FileStream stream = new FileStream(savePath, FileMode.Open);

                // Tell the binary formatter to convert binary into our save data (Deserializa)
                // and we must cast the returned object into our SaveData class to use it
                SaveData data = (SaveData)formatter.Deserialize(stream);

                // Get the values from the newly created save data class
                playerPosition = data.GetPlayerPosition();

                // IMPORTANT: Must close the file stream when done, in order for it to be used again next time we save/load
                stream.Close();

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