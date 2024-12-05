using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public GameObject[] swords = new GameObject[5];
    public GameObject[] guns = new GameObject[5];
    public GameObject nowsword;
    public GameObject nowgun;
    public GameObject myself;

    private bool sword;

    public static Hero singleton { get; private set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Rechardg();

    }
    void FixedUpdate()
    {
        print("win");
        rb.velocity = new Vector2(Input.GetAxis("Vertical") * speed, rb.velocity.y);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.x);
    }
    public void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Swords>() || collision.gameObject.GetComponent<Guns>())
        {
            for (int i = 0; i < swords.Length; i++)
            {
                if (collision.gameObject.name == swords[i].name)
                {
                    print("sword");
                    nowsword.SetActive(false);
                    nowsword = swords[i];
                    nowsword.SetActive(true);
                    nowgun.SetActive(false);
                    nowsword.GetComponent<Guns>().Aktivated();
                }
                if (collision.gameObject.name == guns[i].name)
                {
                    print("gun");
                    nowgun.SetActive(false);
                    nowgun = guns[i];
                    nowgun.SetActive(true);
                    nowsword.SetActive(false);
                    nowgun.GetComponent<Guns>().Aktivated();
                }
            }
        }
    }
    public void Shoot()
    {

    }
    public void Kik()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            nowsword.GetComponent<Swords>().kik();
        }
    }
    public void Rechardg()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowgun.SetActive(false);
            nowsword.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowsword.SetActive(false);
            nowgun.SetActive(true);
        }
    }
    public void Aktivated()
    {
        Destroy(myself);
    }
}
