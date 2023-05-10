using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;


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


        // ========= Using the Binary Formatter
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


        // ========= Using the JSON format
        public void SaveJSON()
        {
            // Make a save path to save the file to
            string savePath = Application.persistentDataPath + "/saveFile.jsonFile";

            // Create an instance of SaveData and fill it in with values to save
            SaveData saveData = new SaveData();
            saveData.SetPlayerPosition(GameManager.instance.player.transform.position);


            // Convert the save data instance to JSON format
            string jsonString = JsonUtility.ToJson(saveData, true);

            // Create an instance of StreamWriter to write the JSON to disk
            // "using" keyword automatically disposes of the StreamWriter, so we don't have to manually call Dispose() on it
            using StreamWriter writer = new StreamWriter(savePath);
            writer.Write(jsonString);
        }

        public void LoadJSON()
        {
            // Make sure the file name and extension matches the saved version above
            string savePath = Application.persistentDataPath + "/saveFile.jsonFile";

            if (!File.Exists(savePath))
            {
                Debug.LogWarning("No Save file found");
                isDataLoaded = false;
                return;
            }

            // Create an instance of StreamReader to read the data in the JSON file
            using StreamReader reader = new StreamReader(savePath);
            string jsonString = reader.ReadToEnd(); // ReadToEnd ensures we get all the information stored on the file

            // Create an instance of SaveData and fill it in with the values stored in the JSON file
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonString);
            playerPosition = saveData.GetPlayerPosition();

            isDataLoaded = true;
        }


        // ========= Using the alernative binary format
        public void SaveBinary()
        {
            string savePath = Application.persistentDataPath + "/saveFile.bin";

            SaveData saveData = new SaveData();
            saveData.SetPlayerPosition(GameManager.instance.player.transform.position);

            using FileStream stream = new FileStream(savePath, FileMode.Create);

            // Note that the type here is BinaryWriter and not BinaryFormatter like above
            using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, false);  // false is to close the file after it's done

            string jsonString = JsonUtility.ToJson(saveData);

            // Encode the JSON file (a big string) into a byte array
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

            // Convert/Encrypt the bytes into a Base64 string
            string encryption = Convert.ToBase64String(bytes);

            // Write the Encoded string to disk
            writer.Write(encryption);
        }

        public void LoadBinary()
        {
            string savePath = Application.persistentDataPath + "/saveFile.bin";

            if (!File.Exists(savePath))
            {
                Debug.LogWarning("No Save file found");
                isDataLoaded = false;
                return;
            }

            using FileStream stream = new FileStream(savePath, FileMode.Open);

            // Note that the type here is BinaryReader
            using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, false); // false is to close the file after it's done

            // Do the reverse steps of Saving above, starting with reading the encrypted string values
            string decryption = reader.ReadString();

            // Convert the encryption to a byte array, using the same type of conversion (Base64)
            byte[] bytes = Convert.FromBase64String(decryption);

            // Decode it into a string that will be our JSON file
            // (note that we also use UTF8 format like we did in saving above)
            string jsonString = Encoding.UTF8.GetString(bytes);

            // Create an instance of SaveData and fill it in with the values stored in the JSON file
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonString);
            playerPosition = saveData.GetPlayerPosition();

            isDataLoaded = true;
        }
    }
}