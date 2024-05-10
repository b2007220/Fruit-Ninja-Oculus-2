using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
  //public Text scoreText;
  //public Text scoreValue;
  //public Text HeartsText;
  public GameObject GameOver;
  public GameObject[] Turrets;
  public TextMeshProUGUI scoreTextMesh;
  public TextMeshProUGUI scoreValueMesh;
  public TextMeshProUGUI HeartsTextMesh;

  public static GameManager Instance;


  private int score;
  private int hearts;

  private bool isDoubleScoreActive = false;

  private void Start()
  {
    NewGame();
  }
  public void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }

  public void NewGame()
  {
    score = 0;
    hearts = 5;
    //scoreText.text = score.ToString();
    //HeartsText.text = hearts.ToString();

    scoreTextMesh.text = score.ToString();
    HeartsTextMesh.text = hearts.ToString();
  }

  public void IncreaseScore()
  {
    if (isDoubleScoreActive)
    {
      score += 20; // Tăng lên gấp đôi nên cộng thêm 20 điểm
    }
    else
    {
      score += 10;
    }

    //scoreText.text = score.ToString();
    scoreTextMesh.text = score.ToString();
  }
  public void DecreaseScore()
  {
    //HeartsText.text = hearts.ToString();
    if (hearts > 0){
      hearts -= 1;

      HeartsTextMesh.text = hearts.ToString();
    }
    else{
      HeartsTextMesh.text = "0";
    }
    HeartsTextMesh.text = hearts.ToString();
    if (hearts == 0)
    {
      GameOver.SetActive(true);
      //scoreValue.text=score.ToString();
      scoreValueMesh.text = score.ToString();
      foreach (GameObject tur in Turrets)
      {
        tur.SetActive(false);
      }
    }
  }

  public void IncreaseHearts(int heartsToAdd)
  {
    // Tăng số lượng hearts
    hearts += heartsToAdd;

    // Cập nhật hiển thị số lượng hearts
    HeartsTextMesh.text = hearts.ToString();
  }

  public void ActivateDoubleScore(float duration)
  {
    if (!isDoubleScoreActive)
    {
      StartCoroutine(DoubleScoreTimer(duration));
    }
    else
    {
      // Nếu DoubleScore đã được kích hoạt trước đó, chỉ cập nhật lại thời gian.
      StopCoroutine("DoubleScoreTimer");
      StartCoroutine(DoubleScoreTimer(duration));
    }
  }

  private IEnumerator DoubleScoreTimer(float duration)
  {
    isDoubleScoreActive = true;
    yield return new WaitForSeconds(duration);
    isDoubleScoreActive = false;
  }

}