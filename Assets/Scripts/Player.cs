using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    public AudioSource jump_source;
    SpriteRenderer pl_ren;
    public Text text_score;
    public GameObject bpl;

    public Sprite[] player_sprite;
    Sprite pl_1, pl_2;

    public static float Yspeed = 6.45f;
    public float Xspeed = 1.0f;
    private int newScore = 0;
    float acs;
    int mc = 0;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        pl_ren = gameObject.GetComponent<SpriteRenderer>();
        int clrIndex = PlayerPrefs.GetInt("playerColor");
        switch (clrIndex)
        {
            case 1:
                pl_1 = player_sprite[0];
                pl_2 = player_sprite[1];
                break;
            case 2:
                pl_1 = player_sprite[2];
                pl_2 = player_sprite[3];
                break;
            case 3:
                pl_1 = player_sprite[4];
                pl_2 = player_sprite[5];
                break;
            case 4:
                pl_1 = player_sprite[6];
                pl_2 = player_sprite[7];
                break;
            case 5:
                pl_1 = player_sprite[8];
                pl_2 = player_sprite[9];
                break;
            case 6:
                pl_1 = player_sprite[10];
                pl_2 = player_sprite[11];
                break;
            default:
                pl_1 = player_sprite[0];
                pl_2 = player_sprite[1];
                break;
        }
        pl_ren.sprite = pl_1;
    }

    IEnumerator cor_bpl()
    {
        yield return new WaitForSeconds(0.21f);
        pl_ren.sprite = pl_1;
        yield return new WaitForSeconds(3);
        int a = Random.Range(1, 4);
        if (a == 1)
        {
            float lX = Random.Range(-2.2f, 2.2f);
            float lY = transform.position.y + 8.0f;
            Vector3 uuu = new Vector3(lX, lY, 0);
            Instantiate(bpl, uuu, Quaternion.identity);
        }

    }

    void Update()
    {
        newScore = Mathf.RoundToInt(transform.position.y * 100.0f);
        if (newScore > int.Parse(text_score.text))
        {
            text_score.text = newScore.ToString();
        }
    }

    void FixedUpdate()
    {
        acs = Input.acceleration.x;
        if (acs > -0.15 && acs < 0.15)
        {
            acs /= 2;
        }
        if (acs > 0.5 || acs < -0.5)
        {
            acs *= 1.3f;
        }
        transform.Translate(acs * Xspeed, 0.0f, 0.0f);  
        if (acs > 0.03)
        {
            pl_ren.flipX = true;
        }
        if (acs < -0.03)
        {
            pl_ren.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("end_sc_tag"))
        {
            if (transform.position.x > 0) 
            {
                transform.position = new Vector2(-transform.position.x + 0.3f, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(-transform.position.x - 0.3f, transform.position.y);
            }
        }

        if (collision.CompareTag("deadTag"))
            
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameButtons.superY = 13.0f;
            if (newScore > PlayerPrefs.GetInt("playerRecord"))
            {
                PlayerPrefs.SetInt("playerRecord", newScore);
                PlayerPrefs.Save();
            }
            int mc = int.Parse(text_score.text);
            PlayerPrefs.SetInt("lastScore", mc);
            PlayerPrefs.Save();
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(oasd());            
        }
    }

    IEnumerator oasd()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y > 0)
        {
            rig.velocity = Vector2.up * Yspeed;
            pl_ren.sprite = pl_2;
            jump_source.Play();
            StartCoroutine(cor_bpl());
        }              
    }
}
