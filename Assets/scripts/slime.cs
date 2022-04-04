using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
  public int life = 5;
  Animator anim;
  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (life <= 0)
    {
      Destroy(gameObject);
    }

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
