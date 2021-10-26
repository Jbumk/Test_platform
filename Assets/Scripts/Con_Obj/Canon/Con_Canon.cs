using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_Canon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Button;    
    public double CoolTime=2f;
    public float Power = 1000f;
    public GameObject Canon;

    private Renderer BtnRender;
    private float Timer = 0f;

    private AudioSource ShootSound;

    void Start()
    {
        ShootSound = GetComponent<AudioSource>();
        if (Button != null)
        {
            BtnRender = Button.gameObject.GetComponent<Renderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Button == null)
        {
            if (Timer >= CoolTime)
            {
                Timer = 0;
                var Bullet = CanonPool.GetObj();

                ShootSound.Play();
                Bullet.CanonShoot(Canon.transform.position, Canon.transform.forward, Power);

            }
        }
        else
        {
            if (BtnRender.material.color == Color.green)
            {
                if (Timer >= CoolTime)
                {
                    Timer = 0;
                    var Bullet = CanonPool.GetObj();
                    ShootSound.Play();
                    Bullet.CanonShoot(Canon.transform.position, Canon.transform.forward, Power);

                }
            }

        }
    }

}
