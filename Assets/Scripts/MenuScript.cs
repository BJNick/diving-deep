using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public int mainSceneIndex = 1;
    public int menuSceneIndex = 0;

    public bool enableEscapeMenu = false;
    public GameObject escapeMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enableEscapeMenu && Input.GetKeyDown(KeyCode.Escape)) {
            if (escapeMenu != null) {
                var current = escapeMenu.activeSelf;
                escapeMenu.SetActive(!current);
                // also stop time
                Time.timeScale = current ? 1.0f : 0.0f;
            }
        }
    }

    public void StartGame() {
        
            Time.timeScale = 1.0f;
         // Load the main scene
        SceneManager.LoadScene(mainSceneIndex);
        
    }

    public void Quit() {
        Debug.Log("Quitting game");
        #if UNITY_EDITOR
            // Stop the editor's play mode
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quit the application
            Debug.Log("Quitting game");
            Application.Quit();
        #endif
    }

    public void MainMenu() {
            Time.timeScale = 1.0f;
        SceneManager.LoadScene(menuSceneIndex);
        
    }

    public void Unpause() {
        if (escapeMenu != null) {
            escapeMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    
}
