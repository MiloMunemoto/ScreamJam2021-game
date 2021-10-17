using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        if (instance == null)
            instance = this;
    }

    private int currentRequirements = 0;
    private int completedRequirements = 0;
    private int currentStage = 0;

    public List<Stage> stages;

    void Start()
    {
        LoadFirstStage();
    }

    public void LoadFirstStage()
    {
        SceneManager.LoadScene(stages[0].sceneBuildIndex,LoadSceneMode.Additive);
        InventoryManager.instance.AddToShoppingList(stages[0].goalObjects);
    }

    public void LoadNextStage()
    {
        currentStage++;
        if (currentStage > stages.Count - 1)
        {
            Debug.LogError("No more stages remaining");
            return;
        }
        InventoryManager.instance.AddToShoppingList(stages[currentStage].goalObjects);
        SceneManager.LoadSceneAsync(stages[currentStage].sceneBuildIndex,LoadSceneMode.Additive);
        if (currentStage >= 1)
            SceneManager.UnloadSceneAsync(stages[currentStage - 2].sceneBuildIndex);
    }
}
