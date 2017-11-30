using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{

    public string QuestionText { get; set; }

    public Dictionary<string, bool> Answers;

    public Question(Dictionary<string, bool> answers, string question)
    {
        Answers = answers;
        QuestionText = question;
    }

    public List<String> getAnswerTexts()
    {
        List<string> s = new List<string>();
        foreach (string key in Answers.Keys)
        {
            s.Add(key);
        }
        return s;
    }


}
