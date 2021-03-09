using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public GameObject Platforms;
    public GameObject PowerUpPrefab;
    GameObject PowerUpObject;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool PowerUp = false;
    public float powerUpTimer = 5.0f;
    float deltaPowerUpTimer = 0f;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }



    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        if (deltaPowerUpTimer >= powerUpTimer)
        {
            deltaPowerUpTimer = 0f;
            PowerUp = false;
        }else if (PowerUp)
        {
            deltaPowerUpTimer += Time.fixedDeltaTime;
            if (PowerUpObject != null)
            {
                PowerUpObject.transform.GetChild(0).GetComponent<PowerUp>().setTime(1-(deltaPowerUpTimer / powerUpTimer));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {  
        GameOver gameOver = hitInfo.collider.GetComponent<GameOver>();
        if (gameOver != null)
        {
            GameOver.gameOverScreen();
        }
        // if play collide with enemy and has power up = enemy dies
        else if (hitInfo.gameObject.tag == "enemy" && PowerUp)
        {
            StartCoroutine(hitInfo.gameObject.GetComponent<Enemy>().Die());
        }
        // if play collide with enemy and dont have power up = player dies
        else if (hitInfo.gameObject.tag == "enemy" && !PowerUp)
        {
            GameOver.gameOverScreen();
        }
        else if (hitInfo.gameObject.tag == "powerUp")
        {
            Destroy(hitInfo.gameObject);
            PowerUp = true;
            Vector2 powerUpPos = new Vector2(transform.position.x, transform.position.y + 1);
            PowerUpObject = Instantiate(PowerUpPrefab, powerUpPos, Quaternion.identity);
            PowerUpObject.transform.parent = transform;
            PowerUpObject.transform.GetChild(0).GetComponent<PowerUp>().setTime(1);
            Destroy(PowerUpObject, powerUpTimer);
        }
        else if (hitInfo.gameObject.tag == "end")
        {
            GameOver.gameOverScreen();
        }
    }


}
