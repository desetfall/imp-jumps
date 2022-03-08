using UnityEngine;
using UnityEngine.UI;

public class MMplayer_prefs : MonoBehaviour
{
    public Button colorBtn;
    public Text recf;
    public static int Adcount = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("firstLoad"))
        {
            PlayerPrefs.SetInt("firstLoad", 1);
            PlayerPrefs.SetInt("playerColor", 1); //1 - red, 2 - bir, 3 - blue, 4 - green, 5 - orange, 6 - yellow
            PlayerPrefs.SetInt("playerRecord", 0);
            PlayerPrefs.SetInt("lastScore", 0);
            PlayerPrefs.Save();
        }
        int clrIndex = PlayerPrefs.GetInt("playerColor");
        switch (clrIndex)
        {
            case 1:
                colorBtn.image.color = Color.red;
                break;
            case 2:
                colorBtn.image.color = Color.cyan;
                break;
            case 3:
                colorBtn.image.color = Color.blue;
                break;
            case 4:
                colorBtn.image.color = Color.green;
                break;
            case 5:
                colorBtn.image.color = new Color(1, 0.5f, 0);
                break;
            case 6:
                colorBtn.image.color = Color.yellow;
                break;
            default:
                colorBtn.image.color = Color.red;
                break;
        }
        recf.text = PlayerPrefs.GetInt("playerRecord").ToString();

    }

}
