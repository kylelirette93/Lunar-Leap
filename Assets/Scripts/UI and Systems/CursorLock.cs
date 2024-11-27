using UnityEngine;

public class CursorLock : MonoBehaviour
{
    void Start()
    {
        // Hide the cursor
        Cursor.visible = false;

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable()
    {
        // Restore the cursor when the script is disabled or game ends
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}