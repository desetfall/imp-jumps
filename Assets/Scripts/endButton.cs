using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endButton : MonoBehaviour
{
    public Text a;

    private void Start()
    {
        a.text = PlayerPrefs.GetInt("lastScore").ToString();
    }
    public void again()
    {
        SceneManager.LoadScene(1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
