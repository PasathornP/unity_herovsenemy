using UnityEngine;
using System.Collections.Generic;

public class RandomHero_Monster : MonoBehaviour
{
    public BoxCollider2D Area;
    public GameObject[] RandomType;
    public Vector3 Rpos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawntime", 0, 9.0f);
    }
    public void stopInvoke(){
        CancelInvoke("Spawntime");
    }
    public void Spawntime(){
        Instantiate(RandomType[Random.Range(0, RandomType.Length)], RandomizePosition(), Quaternion.identity);
    }

    private Vector3 RandomizePosition(){
        Bounds bounds = this.Area.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Rpos = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        transform.position = Rpos;
        return transform.position;
    }
}
