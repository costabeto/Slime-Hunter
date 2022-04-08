using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
  public int life = 5;
  Animator anim;
  Transform target;
  public float moveSpeed = 3f;
  public bool facingRight = true;

  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();

    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

  }

  // Update is called once per frame
  void Update()
  {
    if (life <= 0)
    {
      Destroy(gameObject);
    }

    if (Vector2.Distance(transform.position, target.position) > 1)
    {
      FollowPlayer();
    }


  }

  void FollowPlayer()
  {
    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

    if (target.position.x > transform.position.x && !facingRight)
    {
      Flip();
    }
    else if (target.position.x < transform.position.x && facingRight)
    {
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


  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Colliders/Hitbox")
    {
      life -= 1;
      anim.SetTrigger("isHurt");
    }
    else if (collision.gameObject.tag == "Colliders/Hurtbox")
    {
      collision.GetComponentInParent<player>().hp -= 1;
      collision.GetComponentInParent<player>().isHurt = true;
    }

  }
}
