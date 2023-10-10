using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool ShouldQuitGame => Input.GetKeyUp(KeyCode.Escape);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldQuitGame)
        {
            ShouldGame();
        }
    }

    private void ShouldGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
// todo handle WedGL
Application.Quit();
#endif
    }
}
