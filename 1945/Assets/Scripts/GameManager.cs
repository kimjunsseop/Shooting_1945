using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Text text;
    public int sum;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            sum = 0;
            text.text = "Score : 0";
        }
    }

    public void AddScore(int score)
    {
        sum += score;
        text.text = "Score : " + sum;
    }
}
