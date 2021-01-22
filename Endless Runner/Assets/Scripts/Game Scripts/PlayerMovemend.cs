using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemend : MonoBehaviour
{
    public float jumpForce = 6f;
    private Rigidbody2D rigidbody;
    private Collider2D colider;
    private bool darfSpringen;
    private bool darfSliden = true;

    private Vector2 coliderOffset;
    private Vector2 coliderSize;



    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D> ();
        colider = GetComponent<BoxCollider2D>();

        coliderOffset = colider.offset;
        coliderSize = GetComponent<BoxCollider2D>().size;

    }
    //Jump Funktion 
    private void Jump() {
        GameObject.Find("SoundAndAudioManager").GetComponent<SoundManager>().PlaySound(playerActions.jump);
        rigidbody.velocity = new Vector2(0, jumpForce); 
        //Debug.Log(GameObject.Find("SoundAndAudioManager"));


    }

    //Slide Funktion 
    private void Slide()
    {   

        StartCoroutine(SlideAnimationHandling());
        GetComponent<BoxCollider2D>().size = new Vector2(1.7f,1.3f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0.3f, -1f);

    }
    //SLide Animation Handler
    private IEnumerator SlideAnimationHandling()
    {
        yield return new WaitForSeconds(1f);
        darfSliden = true;
        animator.SetBool("isSliding", !darfSliden);


        resetHitbox();
    }

    private void resetHitbox() {
        GetComponent<BoxCollider2D>().size = coliderSize;
        GetComponent<BoxCollider2D>().offset = coliderOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Überprüft ob einer der Definierten Buttons für Jump gedrückt wird und es dem spiler erlaubt ist zu springen
        if (Input.GetButton("Jump") && darfSpringen)  {
            darfSpringen = false;
           
            animator.SetBool("isJumping", !darfSpringen);
            

            Jump();
            resetHitbox();
        }

        if (Input.GetButton("Slide") && darfSliden && darfSpringen)
        {
            darfSliden = false;
            animator.SetBool("isSliding", !darfSliden);
            Slide();
        }

        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Ground") {
            darfSpringen = true;
            animator.SetBool("isJumping", !darfSpringen);
        }
    }
}
