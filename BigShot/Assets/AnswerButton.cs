using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnswerButton : MonoBehaviour
{
    private Button _btn;
    private string _questionText;

	// Use this for initialization
	void Start () {
        _btn = GetComponent<Button>();
	    _btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        // TODO: INSTEAD OF SETTING CANVAS INACTIVE, GETTING A QUESTION RIGHT MUST INCREMENT COUNTER AND DESTROY BUTTON. CANVAS GOES AWAY ONLY AFTER ALL RIGHT ANSWERS ARE POPPED.
        _questionText = _btn.transform.Find("Text").gameObject.GetComponent<Text>().text;
        if (QuestionManager.CurrentQuestion.Answers[_questionText])
        {
            GameObject.Find("Canvas").SetActive(false);
        }
    }
}
