using UnityEngine;

[System.Serializable]
public class QuizQuestion
{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;

    public string correctAnswer; // "A", "B", "C", or "D"
}

public class QuizData : MonoBehaviour
{
    public QuizQuestion[] questions;
}
