using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    public GameObject enemies;
    private float nrEnemies;
    private void Start()
    {
        nrEnemies = enemies.transform.childCount;
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = (((nrEnemies - enemies.transform.childCount)/nrEnemies)*20).ToString();
    }
}
