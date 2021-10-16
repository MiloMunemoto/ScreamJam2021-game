using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private int currentRequirements = 0;
    private int currentStage = 0;

    public List<Stage> stages;

    private static StageManager instance;
    void Awake()
    {
        if(instance != null)
            Destroy(this);
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        LoadFirstStage();
    }

    public bool IsStagePassed()
    {
        return currentRequirements <= 0;
    }

    public void LoadFirstStage()
    {
        SceneManager.LoadScene(stages[0].sceneBuildIndex,LoadSceneMode.Additive);
    }

    public void LoadNextStage()
    {
        if (!IsStagePassed()) return;

        currentStage++;
        if(currentStage>stages.Count-1)
            Debug.LogError("No more stages remaining");
        SceneManager.LoadSceneAsync(stages[currentStage].sceneBuildIndex,LoadSceneMode.Additive);
    }
}
