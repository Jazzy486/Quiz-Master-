using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;

    int answerIndex;

    [SerializeField] Sprite defaultAnwerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        DisplayQuestion();
    }

    void DisplayNextQuestion()
    {
        SetButtonState(true);
        SetButtonDefaultSprite();
        DisplayQuestion();
    }

    void SetButtonDefaultSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++){
            Image buttonImage = answerButtons[i].GetComponentInChildren<Image>();
            buttonImage.sprite = defaultAnwerSprite;
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            Image buttonImage = answerButtons[index].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = "Correct answer is " + question.GetAnswer(question.GetCorrectAnswerIndex());
            Image buttonImage = answerButtons[question.GetCorrectAnswerIndex()].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    public void SetButtonState(bool State)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = State;
        }
    }
}
