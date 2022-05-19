using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
