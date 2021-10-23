using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiloLevelManager : MonoBehaviour
{
    public static MiloLevelManager instance;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        if (instance == null)
            instance = this;
    }

    private int currentLevel = 0;

    public List<Stage> levels;


    void Start()
    {
        LoadFirstLevel();
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(levels[0].sceneBuildIndex, LoadSceneMode.Additive);

    }

    public void LoadNextLevel()
    {
        Debug.Log("Triggered");
        currentLevel++;
        if (currentLevel > levels.Count - 1)
        {
            Debug.Log("Final stage loaded, no more stages remaining");
            InventoryManager.instance.CheckWinCondition();
            return;
        }
        SceneManager.LoadSceneAsync(levels[currentLevel].sceneBuildIndex, LoadSceneMode.Additive);
        
    }
    public void UnloadLastScene() 
    {
        if (currentLevel >= 1)
            SceneManager.UnloadSceneAsync(levels[currentLevel - 1].sceneBuildIndex);
    }
}


