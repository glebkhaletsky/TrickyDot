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
    bool run;
    bool check;
    bool home;
    Vector3 homePos;
    public int score;
    void Start()
    {
        TryAgainButton.SetActive(false);
        score = 0;
        check = false;
        run = false;
        home = true;
        homePos = new Vector3(0, -3.69f, 0);
    }

    void FixedUpdate()
    {
        transform.LookAt2D(transform.up, aim.transform.position);
        if (run == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aim.transform.position, 0.2f);
        }
        else
        {
            aimPlume.SetActive(true);
        }
        if (check == true)
        {
            run = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, -3.69f), 0.2f);
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
            Destroy(this.gameObject, 0);
            var clone = Instantiate(Dead, transform.position, Quaternion.identity);
            Destroy(clone, 1f);
            //Invoke("tryAgain", 1f);
            TryAgainButton.SetActive(true);
        }
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
