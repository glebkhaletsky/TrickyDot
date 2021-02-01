using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject aim;
    [SerializeField] GameObject aimPlume;
    [SerializeField] GameObject Bingo;
    [SerializeField] GameObject Dead;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject TryAgainButton;
    [SerializeField] Text yourScoreText;
    [SerializeField] Text yourHighScoreText;
    [SerializeField] GameObject FadeOut;
    [SerializeField] GameObject FadeStart;
    [SerializeField] GameObject wow;
    
    int highScore;
    bool run;
    bool check;
    bool home;
    Vector3 homePos;
    public int score;
    void Start()
    {
        
        wow.SetActive(false);
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        highScore = PlayerPrefs.GetInt("HighScore");

        TryAgainButton.SetActive(false);
        score = 0;
        check = false;
        run = false;
        home = true;
        homePos = new Vector3(0, -3.69f, 0);
        Invoke("StartFade", 1f);
    }
     void StartFade()
    {
        FadeStart.SetActive(false);
    }
    void FixedUpdate()
    {
        transform.LookAt2D(transform.up, aim.transform.position);
        if (run == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aim.transform.position, 8f * Time.deltaTime);
        }
        else
        {
            aimPlume.SetActive(true);
        }
        if (check == true)
        {
            run = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, -3.69f), 8f * Time.deltaTime);
        }
        if (transform.position == homePos)
        {
            home = true;
            run = false;
            check = false;
        }
        if (home == false)
        {
            aimPlume.SetActive(false);
        }
        if (home == true)
        {
            aimPlume.SetActive(true);
        }
        
        scoreText.text = score.ToString();
        yourScoreText.text = "Your score: " + score.ToString();
        yourHighScoreText.text = "High score: " + highScore.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            wow.SetActive(true);
            

        }
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
            Invoke("spawnTarget", 1f);
            score += 1;            
        }

        if (collision.tag == "Dead")
        {
            this.gameObject.SetActive(false);
            var clone = Instantiate(Dead, transform.position, Quaternion.identity);
            Destroy(clone, 1f);
            Invoke("lose", 0.5f);
        }
    }

    void lose()
    {
        FadeOut.SetActive(true);
        Invoke("tryAgain", 1.5f);
    }
    void tryAgain()
    {
        TryAgainButton.SetActive(true);
    }
    void spawnTarget()
    {
        FindObjectOfType<SpawnTarget>().StartCoroutine("SpawnCD");
    }

    
}
