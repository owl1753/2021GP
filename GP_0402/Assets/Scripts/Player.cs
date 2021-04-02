using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 3;
    public int speed = 10;

    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0 )
        {
            Vector3 posInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            Vector3 pos = transform.position;

            pos += posInput * Time.deltaTime * speed;

            if (pos.x < -4.68)
            {
                pos.x = -4.68f;
            }
            else if (pos.x > 4.68)
            {
                pos.x = 4.68f;
            }
            if (pos.y < -2.65)
            {
                pos.y = -2.65f;
            }
            else if (pos.y > 2.65)
            {
                pos.y = 2.65f;
            }

            transform.position = pos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hp -= 1;
            print(hp);
        }
    }
}
