using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerLevel3 : MonoBehaviour
{
    public PizzaDrag pizzaPrefab;
    public Transform pizzaStartPos;
    public Transform pizzaStayPos;
    public TransitionScript transition;
    public MealOrder fractions;
    public ScrollingObject lenta;

    int currentTask = 0;
    int tasksToCompleteLevel = 10;

    List<Vector2> tasks;

    void Start()
    {
        SetTasks();
        CreateTask();
    }

    void SetTasks()
    {
        tasks = new List<Vector2>();
        for (int i = 0; i < fractions.numDenom.Length; i++)
        {
            tasks.Add(fractions.numDenom[i]);
        }
    }

    public void CreateTask()
    {
        SharedState.SubmitProgress();

        Vector2 fraction = GetFraction();
        PizzaDrag pizza = Instantiate(pizzaPrefab);
        pizza.transform.position = pizzaStartPos.position;
        pizza.SetNumDenom((int)fraction.x, (int)fraction.y);
        pizza.SetPizzaStayPosition(pizzaStayPos.position);
        pizza.levelManager = this;
        lenta.doScroll = true;
        currentTask++;
    }

    public void OnPizzaStartDrag()
    {
        lenta.doScroll = false;
    }

    public void OnPizzaStay()
    {
        lenta.doScroll = false;
    }

    Vector2 GetFraction()
    {
        int randomIndex = Random.Range(0, tasks.Count - 1);
        var newFraction = new Vector2();
        newFraction.x = tasks[randomIndex].x;
        newFraction.y = tasks[randomIndex].y;
        tasks.RemoveAt(randomIndex);
        return newFraction;
    }

    public void OnTaskComplete()
    {
        if (tasks.Count > 0) CreateTask();
        else EndLevel();
    }

    void EndLevel()
    {
        transition.DisplayTransitionAndGotoNextScene();
    }

    void Update()
    {
        
    }
}
