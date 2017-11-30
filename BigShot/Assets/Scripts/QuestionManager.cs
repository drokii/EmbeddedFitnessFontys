using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class QuestionManager : MonoBehaviour
{
    public static Question CurrentQuestion;
    private List<Question> _questionList;
    private static int totalGoodAnswers = 0, goodAnswered = 0; 

    void Start()
    {      
        //Get questions
        _questionList = QuestionLoader.LoadQuestions();
        // TODO: ADD RANDOMIZER TO CHOSEN QUESTION (QUESTIONPICKER METHOD?)
        CurrentQuestion = _questionList[0];   
        FillUIwithQuestion();
    }

    private void Update()
    {
        Transform t = transform.Find("Answers");

        goodAnswered = 0;
        foreach (Transform child in t)
        {
            if (QuestionManager.CurrentQuestion.Answers[child.Find("Text").gameObject.GetComponent<Text>().text] && !child.gameObject.activeSelf)
            {
                goodAnswered++;
            }
        }

        if (goodAnswered == totalGoodAnswers)
        {
            nextQuestion();
        }
    }

    void nextQuestion()
    {
        goodAnswered = 0;
        totalGoodAnswers = 0;
        gameObject.SetActive(true);
        CurrentQuestion = _questionList[_questionList.IndexOf(CurrentQuestion) + 1];
        FillUIwithQuestion();
    }

    void FillUIwithQuestion()
    {
        //Fill question text
        transform.Find("Text").gameObject.GetComponent<Text>().text = CurrentQuestion.QuestionText;

        //Fill answers
        Transform t = transform.Find("Answers");
        List<string> allAnswers = CurrentQuestion.getAnswerTexts();    

        int indexOfQuestion = 0;

        //Populate all buttons with answers. Buttons are gotten from the children of Canvas. 15 answers for 15 buttons.
        foreach (Transform child in t)
        {
            child.gameObject.SetActive(true);
            child.Find("Text").gameObject.GetComponent<Text>().text = allAnswers[indexOfQuestion];
            if (QuestionManager.CurrentQuestion.Answers[allAnswers[indexOfQuestion]])
            {
                totalGoodAnswers++;
            }
            indexOfQuestion++;        
            
            
        }

    }

}

