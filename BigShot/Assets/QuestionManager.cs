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

    void Start()
    {      
        //Get questions
        _questionList = QuestionLoader.LoadQuestions();
        // TODO: ADD RANDOMIZER TO CHOSEN QUESTION (QUESTIONPICKER METHOD?)
        CurrentQuestion = _questionList[0];   
        FillUIwithQuestion();
    }

    void nextQuestion()
    {
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
            child.Find("Text").gameObject.GetComponent<Text>().text = allAnswers[indexOfQuestion];
            indexOfQuestion++;            
        }

    }

}

