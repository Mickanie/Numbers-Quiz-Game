using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class QuizGame : MonoBehaviour
{

    public Button[] answerButtons = new Button[4];
    public Text questionText;
    
    public int[] answers = new int[4];
    public string[] answersInEnglish = new string[4];
    private int questionsDone = 0;
    int correctAnswerLocation;
    List<int> questionsUsed = new List<int>();

    public GameObject[] QuestionPanels;
    public GameObject finalResultPanel;
    public Text resultText;
    private int score = 0;
    private bool gameActive = true;
  
    public Text scoreText;
    public Button questionButton; 
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    public Sprite ten;
    public Sprite correct;
    public Sprite wrong;
    public GameObject feedbackButton;

    
    // Use this for initialization
    void Start()
    {
        score = 0;
        questionsDone = 0;
        newQuestion();
 
    }
    //Generating question
    void newQuestion()
    {
        int numberAsked = UnityEngine.Random.Range(1, 11);
        while (questionsUsed.Contains(numberAsked))
        {
            numberAsked = UnityEngine.Random.Range(1, 11);
        }
        switch (numberAsked)
        {
            case 1:
                questionButton.GetComponent<Image>().overrideSprite = one;
                break;
            case 2:
                questionButton.GetComponent<Image>().overrideSprite = two;
                break;
            case 3:
                questionButton.GetComponent<Image>().overrideSprite = three;
                break;
            case 4:
                questionButton.GetComponent<Image>().overrideSprite = four;
                break;
            case 5:
                questionButton.GetComponent<Image>().overrideSprite = five;
                break;
            case 6:
                questionButton.GetComponent<Image>().overrideSprite = six;
                break;
            case 7:
                questionButton.GetComponent<Image>().overrideSprite = seven;
                break;
            case 8:
                questionButton.GetComponent<Image>().overrideSprite = eight;
                break;
            case 9:
                questionButton.GetComponent<Image>().overrideSprite = nine;
                break;
            case 10:
                questionButton.GetComponent<Image>().overrideSprite = ten;
                break;
     
        }
        questionsUsed.Add(numberAsked);
        correctAnswerLocation = UnityEngine.Random.Range(0, 4);
        
        
        for (int i = 0; i < answers.Length; i++)
        {
            if (i == correctAnswerLocation)
            {
                answers[i] = numberAsked;
            }
            else
            {
                int wrongAnswer = UnityEngine.Random.Range(1, 11);
                while (wrongAnswer == numberAsked || Array.IndexOf(answers, wrongAnswer) > -1)
                {
                    wrongAnswer = UnityEngine.Random.Range(1, 11);
                }
                answers[i] = wrongAnswer;
            }
            
        }

        for (int i = 0; i < answers.Length; i++)
        {
            switch (answers[i])
            {
                case 1:
                    answersInEnglish[i] = "ONE";
                    break;
                case 2:
                    answersInEnglish[i] = "TWO";
                    break;
                case 3:
                    answersInEnglish[i] = "THREE";
                    break;
                case 4:
                    answersInEnglish[i] = "FOUR";
                    break;
                case 5:
                    answersInEnglish[i] = "FIVE";
                    break;
                case 6:
                    answersInEnglish[i] = "SIX";
                    break;
                case 7:
                    answersInEnglish[i] = "SEVEN";
                    break;
                case 8:
                    answersInEnglish[i] = "EIGHT";
                    break;
                case 9:
                    answersInEnglish[i] = "NINE";
                    break;
                case 10:
                    answersInEnglish[i] = "TEN";
                    break;
              
            }
        }
        questionText.text = numberAsked.ToString();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answersInEnglish[i];
        }
        //string info = answerButtons[0].GetComponentInChildren<Text>().text;
        //scoreText.text = info;
    }

    //Checking answer and giving feedback 
    public void checkAnswer(int buttonNumber)
    {
        if (gameActive)
        {
            
            if (buttonNumber == correctAnswerLocation)
            {
                score++;
                
                answerButtons[buttonNumber].GetComponent<Image>().color = Color.green;
                
          
                feedbackButton.GetComponent<Image>().overrideSprite = correct;
                feedbackButton.GetComponent<Image>().color = new Color32(33, 171, 0, 255);
                print("correct");
                StartCoroutine("ContinueAfterFeedback");
            }
            else
            {
                answerButtons[buttonNumber].GetComponent<Image>().color = Color.red;
                
                print("incorrect");
       
                feedbackButton.SetActive(true);
                feedbackButton.GetComponent<Image>().overrideSprite = wrong;
                feedbackButton.GetComponent<Image>().color = Color.red;
        
            }
            
        }
    }
    //pause before moving to next question, showing feedback, updating score
    IEnumerator ContinueAfterFeedback()
    {
        gameActive = false;
    
        feedbackButton.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 4; i++)
        {

            answerButtons[i].GetComponent<Image>().color = new Color32(254, 238, 220, 255);
         
        }
        feedbackButton.SetActive(false);

        questionsDone++;
        if (questionsDone < 5)
        {
            newQuestion();

        }
        else
        {

            foreach (GameObject p in QuestionPanels)
            {
                p.SetActive(false);
            }
            finalResultPanel.SetActive(true);
            DisplayResults();
        }
        gameActive = true;
    }

    //displaying final result 
    void DisplayResults()
    {
        resultText.text = "Super!";
    }

    //restart level
    public void restartLevel()
    {
        SceneManager.LoadScene("NumbersGameLevel1");
    }
    

    public void QuitGame()
    {

        SceneManager.LoadScene("NumbersLearning");

    }
}
