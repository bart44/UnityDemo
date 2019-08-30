using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float heroSpeed;
    public float jumpForce;
    public Transform groundTester;
    public LayerMask layersToTest;
    public Transform startPoint;

    private bool onTheGround;
    private float radius = 0.15f;

    Animator anim;
    Rigidbody2D rgdBody;
    bool dirToRight = true;


	// Use this for initialization
	void Start () {
        
        anim = GetComponent<Animator> ();
        rgdBody = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {

              
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("objectContact")) // jezeli dotknie kaktusa to sie zatrzymuje (powinien)
        {
            rgdBody.velocity = new Vector2(0,0); // przypisanie speed wartosci zero *rgdBody.velocity = new Vector(0,0)*
            return; // wyjscie z metody
        }
      
        onTheGround = Physics2D.OverlapCircle(groundTester.position, radius, layersToTest); // sprawdza groundera czy koliduje z nim i wtedy nie moze skakac x(infinity)

        float horizontalMove = Input.GetAxis("Horizontal"); //przy nacisnieciu d/-> uruchamia sie animacja run
        rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y); // przypisanie...
       
        if(Input.GetKeyDown(KeyCode.Space) && onTheGround) // jezeli spacja zostanie nacisnieta... i jest ziomek na ziemi (groundTester)
        { 
            
            rgdBody.AddForce(new Vector2(0f, jumpForce)); // ...to se przypisujemy vektor 2d do skakania 
            anim.SetTrigger("jump"); // sprawdzanie czy trigger nazywa sie "jump"   
        }

        anim.SetFloat ("speed", Mathf.Abs(horizontalMove)); // przekazujemy do parametru speed wartosc bezwzgledna horizontalMove a/d && <-/->   
        

        /**
         * ifami sprawdzam, czy horizontal jest -1 lub 1 (lewo/prawo) no i sobie flipuje ziomeczka
         * */
        if (horizontalMove < 0 && dirToRight == true)
        {
            Flip();
        }
        if (horizontalMove > 0 && dirToRight == false)
        {
            Flip();
        }     		
	}

     /**
     * metoda do odwracania ziomeczka
     * */
    void Flip()
    {
        dirToRight = !dirToRight; //jezeli bedzie true przypisujemy false i odwrotnie
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }
    /**
     * metoda do restart ziomeczka po kolizji z jakims obstacle
     * */
    public void RestartHero()
    {
        gameObject.transform.position = startPoint.position;
    }

}
