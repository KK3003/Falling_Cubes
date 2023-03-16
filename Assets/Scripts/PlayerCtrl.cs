using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCtrl : MonoBehaviour
{

    Rigidbody2D playerRB;
    float x_dir;
    public float moveSpeed = 5.0f;

    bool isShieldOn = false;

    public GameObject shieldtext;

    public UIManager uimn;

    public GameObject player;
    public Vector3 sizeChangeB,sizeChangeD;
    Vector3 sizeChange, sizeChanged;



  

    // Start is called before the first frame update
    void Start()
    {
        
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        x_dir = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        playerRB.velocity = new Vector2(x_dir, 0f);
    }

   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // player died
            if (isShieldOn == false)
            {
                Restart();
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield")
        {

            // show effect
            Debug.Log("Shield on");

            StartCoroutine(ShieldOn());

        }
        else if (other.tag == "Bomb")
        {

            // show effect
            Debug.Log("Bomb");

            if (isShieldOn == false)
            {
                Restart();
            }

        }
        else if (other.tag == "SizeD")
        {

            // show effect
            Debug.Log("Size --");

            sizeChange = new Vector3(0.8f, 0.8f, 0);
            if(player.transform.localScale == sizeChange)
            {
                player.transform.localScale = player.transform.localScale - sizeChangeD;
            }
            
            
        }
        else if (other.tag == "SizeB")
        {

            // show effect
            Debug.Log("Size ++");
            sizeChanged = new Vector3(0.5f, 0.5f, 0);
            if (player.transform.localScale == sizeChanged)
            {
                player.transform.localScale = player.transform.localScale + sizeChangeB;
            }

           
        }



    }



    void Restart()
     {
        playerRB.velocity = Vector2.zero;
        Debug.Log("Player Died");
       // Time.timeScale = 0f;
        uimn.GameOver();
        // show gameover menu
    }


    IEnumerator ShieldOn()
    {
        yield return new WaitForSeconds(0.1f);
        isShieldOn = true;
        shieldtext.SetActive(true);

        yield return new WaitForSeconds(20);
        isShieldOn = false;
        shieldtext.SetActive(false);

    }

    


}
