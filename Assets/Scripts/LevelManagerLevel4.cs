using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManagerLevel4 : MonoBehaviour
{
    public PizzaMoving pizzaPrefab;
    public DescriptionText descriptionText;
    public DescriptionText instructionsText;
    public Transform pizzaStartPos;
    public Transform pizzaStayPos;
    public TransitionScript transition;
    public MovingPizzaTasks fractions;
    public ScrollingObject lenta;
    PizzaMoving currentPizza;
    public StartMovingPizzaButton startButton;
    public Switch[] switches;
    string descriptionKey;

    int currentTask = 0;
    int tasksToCompleteLevel = 10;

    List<Vector2> tasks;
    List<Vector2> solutions;

    void Start()
    {
        startButton.gameObject.SetActive(false);
        SetTasks();
        CreateTask();
        string key = "level_4_instructions";
        instructionsText.ShowTextWithoutDelay(key, false, false);
    }

    void SetTasks()
    {
        tasks = new List<Vector2>();
        solutions = new List<Vector2>();
        for (int i = 0; i < fractions.tasks.Length; i++)
        {
            tasks.Add(fractions.tasks[i]);
            solutions.Add(fractions.solutions[i]);
        }
    }

    public void CreateTask()
    {
        SharedState.SubmitProgress();
        int randomIndex = Random.Range(0, tasks.Count - 1);
        Vector2 task = GetFraction(randomIndex);
        Vector2 solution = GetSolution(randomIndex);
        currentPizza = Instantiate(pizzaPrefab);
        currentPizza.transform.position = pizzaStartPos.position;
        currentPizza.SetNumDenom((int)task.x, (int)task.y);
        currentPizza.SetSolution((int)solution.x, (int)solution.y);
        currentPizza.SetPizzaTargetPos(pizzaStayPos.position);
        currentPizza.pizzaStayPos = pizzaStayPos.position;
        currentPizza.levelManager = this;
        lenta.doScroll = true;
        currentTask++;
        descriptionKey = "level_4_"+(int)solution.x+"_"+(int)solution.y;
        descriptionText.DisplayText(descriptionKey, false);
    }

    public void OnPizzaStartDrag()
    {
        lenta.doScroll = false;
    }

    Vector2 GetFraction(int randomIndex)
    {
        var newFraction = new Vector2();
        newFraction.x = tasks[randomIndex].x;
        newFraction.y = tasks[randomIndex].y;
        tasks.RemoveAt(randomIndex);
        return newFraction;
    }

    Vector2 GetSolution(int randomIndex)
    {
        var newFraction = new Vector2();
        newFraction.x = solutions[randomIndex].x;
        newFraction.y = solutions[randomIndex].y;
        solutions.RemoveAt(randomIndex);
        return newFraction;
    }

    public void OnTaskComplete()
    {
        if (tasks.Count > 0) CreateTask();
        else EndLevel();
    }

    public void CurrentPizzaReadyToGo()
    {
        startButton.gameObject.SetActive(true);
        lenta.doScroll = false;
        Debug.Log("currentPizza ready to go");
    }

    public void OnStartMovingPizzaButtonClicked()
    {
        startButton.gameObject.SetActive(false);
        currentPizza.SetAndMoveToSwitch(switches[0]);
    }

    void EndLevel()
    {
        transition.DisplayTransitionAndGotoNextScene();
    }

    public void OnCorrect()
    {
        string key = "level_4_well_done";
        descriptionText.DisplayText(key, false);
    }

    public void OnWrong()
    { 
        descriptionText.DisplayText(descriptionKey, false);
    }

    void Update()
    {

    }
}
