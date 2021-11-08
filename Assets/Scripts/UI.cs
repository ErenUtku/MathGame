using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text problemText;                
    public Text[] answersTexts;             
    public Image remainingTimeDial;         
    private float remainingTimeDialRate;    
    public Text endText;

    public static UI instance;
    void Awake()
    {
        instance = this;//Creating instance for accessing through other script
    }
    void Start()
    {
        {
            remainingTimeDialRate = 1.0f / GameManager.instance.timePerProblem;//exp 8 seconds will divide dial 8 times so with Time.deltaTime that will just work as a clock
        }
    }
    void Update()
    {
        remainingTimeDial.fillAmount = remainingTimeDialRate * GameManager.instance.remainingTime;
    }

    public void SetProblemText(Problem problem)
    {
        string operatorText = "";
        switch (problem.operation)
        {
            case MathsOperation.Addition: operatorText = " + "; break;
            case MathsOperation.Subtraction: operatorText = " - "; break;
            case MathsOperation.Multiplication: operatorText = " x "; break;
            case MathsOperation.Division: operatorText = " ÷ "; break;
        }
        problemText.text = problem.firstNumber + operatorText + problem.secondNumber;
        for (int index = 0; index < answersTexts.Length; ++index)
        {
            answersTexts[index].text = problem.answers[index].ToString();
        }
    }
    public void SetEndText(bool win)
    {
        endText.gameObject.SetActive(true);
        if (win)
        {
            endText.text = "You Win!";
            endText.color = Color.green;
        }
        else
        {
            endText.text = "Game Over!";
            endText.color = Color.red;
        }
    }
}
