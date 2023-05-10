using UnityEngine;

namespace GameSaveGeneral
{
    // Save data class must be Serializable
    [System.Serializable]
    public class SaveData
    {
        // All values/variables to be stored on disk should be either public or
        // have [SerializeField] attribute if they're private
        public float[] position = new float[3];

        // Methods are not saved to disk
        public void SetPlayerPosition(Vector3 newPosition)
        {
            position[0] = newPosition.x;
            position[1] = newPosition.y;
            position[2] = newPosition.z;
        }

        public Vector3 GetPlayerPosition()
        {
            return new Vector3(position[0], position[1], position[2]);
        }
    }
}