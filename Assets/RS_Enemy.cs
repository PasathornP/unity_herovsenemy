using UnityEngine;

public class RS_Enemy : MonoBehaviour
{
    public Sprite[] Enemy;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Enemy[Random.Range(0, Enemy.Length)];
    }

}
