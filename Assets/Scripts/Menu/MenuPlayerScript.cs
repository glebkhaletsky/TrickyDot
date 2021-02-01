using UnityEngine;
using UnityEngine.UI;

public class MenuPlayerScript : MonoBehaviour
{
    [SerializeField] GameObject aim;
    [SerializeField] GameObject aimPlume;
    [SerializeField] GameObject Bingo;
    [SerializeField] Text highScoreText;

    bool run;
    bool check;
    bool home;
    int highScore;
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        highScore = PlayerPrefs.GetInt("HighScore");
        check = false;
        run = false;
        home = true;
    }

    void FixedUpdate()
    {
        transform.LookAt2D(transform.up, aim.transform.position);
        if (run == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aim.transform.position, 6f * Time.deltaTime);
        }
        else
        {
            aimPlume.SetActive(true);
        }
        if (check == true)
        {
            run = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, -3.69f), 6f * Time.deltaTime);
        }
        if (home == false)
        {
            aimPlume.SetActive(false);
        }
        if (home == true)
        {
            aimPlume.SetActive(true);
        }
        highScoreText.text = "High score: " + highScore.ToString();
    }

    public void onClick()
    {
        run = true;
        home = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            check = true;
            var clone = Instantiate(Bingo, transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0);
            Destroy(clone, 0.5f);
            Destroy(this.gameObject, 0);
        }
    }
}
