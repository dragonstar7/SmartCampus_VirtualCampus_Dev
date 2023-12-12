using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButtons : MonoBehaviour
{   
    // load campus scene
    public void LoadCampus() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainCampus");
    }
    
    // quits program
    public void ExitProgram() {
        // Only leave in the next line if testing from the Unity video
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
