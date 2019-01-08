using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumbersVoice : MonoBehaviour {

    public AudioSource source;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    public AudioClip seven;
    public AudioClip eight;
    public AudioClip nine;
    public AudioClip ten;
    public Text scoreText;
    public Button button;

  

    
    public void playSound()
    {
       
        string info = button.GetComponentInChildren<Text>().text;
        scoreText.text = info;
        //another way info=clip??
        switch (info)
        {
            case "ONE":
                source.clip = one;
                break;
            case "TWO":
                source.clip = two;
                break;
            case "THREE":
                source.clip = three;
                break;
            case "FOUR":
                source.clip = four;
                break;
            case "FIVE":
                source.clip = five;
                break;
            case "SIX":
                source.clip = six;
                break;
            case "SEVEN":
                source.clip = seven;
                break;
            case "EIGHT":
                source.clip = eight;
                break;
            case "NINE":
                source.clip = nine;
                break;
            case "TEN":
                source.clip = ten;
                break;

        }
       
        source.Play();

    }
}
