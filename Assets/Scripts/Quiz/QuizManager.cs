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
    public TextMeshProUGUI finalScoreText;

    [Header("Score")]
    public int score = 0;

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

    public void CheckAnswer(string selected)
    {
        string correct = quizData.questions[currentIndex].correctAnswer;

        // Reset warna (agar selalu bersih untuk kasus tertentu)
        ResetAllOptionColors();

        // Jika jawaban benar
        if (selected == correct)
        {
            // +1 POIN
            score++;

            // Warnai opsi benar
            Image correctImg = GetImage(correct);
            TextMeshProUGUI correctTxt = GetText(correct);

            correctImg.color = correctColor;
            correctTxt.color = correctTextColor;

             score += 10;

            // Jika sudah soal terakhir → buka Final Panel
            if (currentIndex == quizData.questions.Length - 1)
            {
                Invoke(nameof(ShowFinalPanel), 2.0f);
                return;
            }

            // Lanjut ke soal berikutnya dalam 3 detik
            Invoke(nameof(NextQuestion), 3f);
        }
        else
        {
            // Opsi salah → merah 1 detik lalu kembali default
            Image selectedImg = GetImage(selected);
            TextMeshProUGUI selectedTxt = GetText(selected);

            selectedImg.color = wrongColor;
            selectedTxt.color = correctTextColor;

            // Setelah 1 detik reset kembali
            Invoke(nameof(ResetAllOptionColors), 1f);
        }
    }

    void ShowFinalPanel()
    {
        finalPanel.SetActive(true);
        finalScoreText.text = score.ToString();
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
