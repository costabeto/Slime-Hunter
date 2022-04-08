using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{

  public float speed;
  public Rigidbody2D rig2D;
  public bool facingRight = true;
  public float hp;

  float moveX;
  float moveY;
  bool isMoving;
  public bool isHurt;
  Animator anim;
  public Image heart;
  public float hpMax = 100;



  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
    hp = hpMax;
  }

  // Update is called once per frame
  void Update()
  {
    if (hp > 0)
    {
      Movement();
      Attack();
      UpdateUI();
    }
    else
    {
      anim.SetTrigger("isDead");
    }
  }
  void UpdateUI()
  {
    heart.fillAmount = hp / hpMax;
  }

  void Movement()
  {
    moveX = Input.GetAxisRaw("Horizontal");
    moveY = Input.GetAxisRaw("Vertical");
    rig2D.MovePosition(transform.position + new Vector3(moveX, moveY, 0) * speed * Time.deltaTime);
    FixedUpdate();
    Animation();

    if (isHurt)
    {
      anim.SetTrigger("isHurt");
      isHurt = false;
    }
  }

  void FixedUpdate()
  {
    float h = Input.GetAxis("Horizontal");
    if (hp > 0)
    {
      if (h > 0 && !facingRight)
        Flip();
      else if (h < 0 && facingRight)
        Flip();
    }
  }
  void Flip()
  {
    facingRight = !facingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }

  void Animation()
  {
    if (moveX == 0 && moveY == 0)
    {
      isMoving = false;
    }
    else
    {
      isMoving = true;
    }
    anim.SetBool("isMoving", isMoving);
  }

  void Attack()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      anim.SetTrigger("isAttacking");
    }
  }
}
