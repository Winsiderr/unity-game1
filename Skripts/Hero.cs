using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask enemy;
    public float range;
    public int damage;
    public Animator anim;
    public int wood;
    public int iq;
    public int iron;
    public static Hero singleton { get; private set; }
    private Rigidbody2D rb;
    public float speed;
    public GameObject nowsword;
    public int hp = 5;
    public GameObject dethpanel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    void Awake()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        if (hp <= 0)
        {
            Die();
        }
        if (timeBtwAttack <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                anim.SetTrigger("attack");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, range, enemy);
                for (int i = 0; i < enemies.Length; i ++)
                {
                    enemies[i].GetComponent<Enemy>().hp -= damage;
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        print("win");
        rb.velocity = new Vector2(Input.GetAxis("Vertical") * speed, rb.velocity.y);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.x);
    }
    public void Flip()
    {
        //if (Input.GetAxis("Horizontal") > 0)
           // transform.localRotation = Quaternion.Euler(0, 0, 0);
        //if (Input.GetAxis("Horizontal") < 0)
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    public void Kik()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            nowsword.GetComponent<Swords>().kik();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Movement>())
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                print("L");
                collision.gameObject.GetComponent<Movement>().LevelUp();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                print("U");
                collision.gameObject.GetComponent<Movement>().Use();
            }
        }
    }
    void Die()
    {
        dethpanel.SetActive(true);
        Time.timeScale = 0;
    }

}
