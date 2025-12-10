using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    [Header("Quiz Reference")]
    public QuizData quizData;

    [Header("UI")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI questionText;

    public Image optionAImage;
    public Image optionBImage;
    public Image optionCImage;
    public Image optionDImage;

    public TextMeshProUGUI optionAText;
    public TextMeshProUGUI optionBText;
    public TextMeshProUGUI optionCText;
    public TextMeshProUGUI optionDText;

    [Header("Colors")]
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    public Color defaultBGColor = Color.white;
    public Color defaultTextColor = Color.black;
    public Color correctTextColor = Color.white;  

    [Header("Final UI")]
    public GameObject finalPanel; // Panel menuju Main Menu

    private int currentIndex = 0;
    private bool canAnswer = true;

    void Awake() => Instance = this;

    void Start()
    {
        finalPanel.SetActive(false);
        LoadQuestion();
    }

    public void LoadQuestion()
    {
        canAnswer = true;

        ResetAllOptionColors();

        var q = quizData.questions[currentIndex];

        levelText.text = (currentIndex + 1).ToString();
        questionText.text = q.questionText;

        optionAText.text = q.optionA;
        optionBText.text = q.optionB;
        optionCText.text = q.optionC;
        optionDText.text = q.optionD;
    }

    public void ReceiveMarkerAnswer(string selected)
    {
        if (!canAnswer) return;

        CheckAnswer(selected);
    }

    void CheckAnswer(string selected)
    {
        string correct = quizData.questions[currentIndex].correctAnswer;

        Image selectedImg = GetImage(selected);
        TextMeshProUGUI selectedText = GetText(selected);

        if (selected == correct)
        {
            // Benar
            selectedImg.color = correctColor;
            selectedText.color = correctTextColor;

            canAnswer = false;
            Invoke(nameof(NextQuestion), 3f);
        }
        else
        {
            // Salah → warnai merah lalu reset setelah 1 detik
            selectedImg.color = wrongColor;
            selectedText.color = correctTextColor;

            canAnswer = false;
            Invoke(nameof(ResetSelectedColorOnly), 1f);
        }
    }

    void ResetSelectedColorOnly()
    {
        ResetAllOptionColors();
        canAnswer = true;
    }

    void NextQuestion()
    {
        currentIndex++;

        if (currentIndex >= quizData.questions.Length)
        {
            ShowFinalUI();
            return;
        }

        LoadQuestion();
    }

    void ShowFinalUI()
    {
        finalPanel.SetActive(true);
    }

    void ResetAllOptionColors()
    {
        ResetOption(optionAImage, optionAText);
        ResetOption(optionBImage, optionBText);
        ResetOption(optionCImage, optionCText);
        ResetOption(optionDImage, optionDText);
    }

    void ResetOption(Image img, TextMeshProUGUI txt)
    {
        img.color = defaultBGColor;
        txt.color = defaultTextColor;
    }

    Image GetImage(string id)
    {
        switch (id)
        {
            case "A": return optionAImage;
            case "B": return optionBImage;
            case "C": return optionCImage;
            case "D": return optionDImage;
        }
        return null;
    }

    TextMeshProUGUI GetText(string id)
    {
        switch (id)
        {
            case "A": return optionAText;
            case "B": return optionBText;
            case "C": return optionCText;
            case "D": return optionDText;
        }
        return null;
    }
}
