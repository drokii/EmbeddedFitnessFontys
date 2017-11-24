using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question {

    public string QuestionText { get; set; }
    public List<string> Answers { get; set; }

    public Question(List<string> answers, string question)
    {
        Answers = answers;
        QuestionText = question;
    }


}
