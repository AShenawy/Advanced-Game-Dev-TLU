using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        // Z is forward in 3D space
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (moveInput.x != 0f || moveInput.z != 0f)
        {
            transform.Translate(moveInput * speed * Time.deltaTime);
        }
    }
}
