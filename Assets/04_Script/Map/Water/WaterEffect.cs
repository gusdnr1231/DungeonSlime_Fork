using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;
    void SummonParticle(Vector2 pos, float f)
    {
        ParticleSystem part = Instantiate(particle, pos, Quaternion.Euler(particle.gameObject.transform.rotation.x,0,f),this.transform);
        part.Play();
        Destroy(part.gameObject, 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 pos = collision.transform.position;
            Vector2 topos = new Vector2((int)pos.x/1, (int)pos.y/1);
            float f = Vector3.Angle(topos, pos) * Mathf.Rad2Deg;
            SummonParticle(pos, f);
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 pos = collision.transform.position;
            Vector2 topos = new Vector2((int)pos.x / 1, (int)pos.y / 1);
            float f = Vector3.Angle(topos, pos) * Mathf.Rad2Deg - 180f;
            SummonParticle(pos, f);
        }
    }
}
