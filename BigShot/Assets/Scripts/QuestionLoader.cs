using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLoader
{

    public static List<Question> LoadQuestions()
    {
        List<Question> questionList = new List<Question>();
        string line;
        List<string> questionStringList = new List<string>();

        // Read the file and build questions
        System.IO.StreamReader file =
            new System.IO.StreamReader(@"QuestionList.txt");
        while ((line = file.ReadLine()) != null)
        {
            questionStringList.Add(line);
        }
        file.Close();

        List<string> answerList = new List<string>();
        List<bool> answerValueList = new List<bool>();
        string questionTitle = "";

        int x = 0;

        foreach (string s in questionStringList)
        {

            if (x == 0)
            {
                // If first line on string, get question title
                questionTitle = s;
            }
            else
            {
                // If not, add answer and value to respective lists
                string[] answerValueArray = s.Split('|');
                answerList.Add(answerValueArray[0]);
                answerValueList.Add(Convert.ToBoolean(answerValueArray[1]));
            }

            if (x >= 15)
            {
                // Fill answer and values dictionary with lists
                Dictionary<string, bool> answerDictionary = new Dictionary<string, bool>();
                for (int i = 0; i < 15; i++)
                {
                    answerDictionary.Add(answerList[i], answerValueList[i]);
                }

                // Build question
                Question question = new Question(answerDictionary, questionTitle);
                questionList.Add(question);

                // Clear list and reset counter

                answerList.Clear();
                answerValueList.Clear();
            }
            if (x == 15)
            {
                x = 0;
            }
            else
            {
                x++;
            }
        }
        return questionList;

    }

}
