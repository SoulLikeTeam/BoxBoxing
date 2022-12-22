using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public float Speed; // ¼Óµµ 

    private void Start()
    {
        Invoke("Destroy", 2);
    }
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);

        transform.Rotate(Vector2.up * Time.deltaTime);
    }
    private IEnumerator Destory(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plate"))
        {
            DestroyJudge();
        }
    }
    void DestroyJudge()
    {
        Destroy(gameObject);
    }
}