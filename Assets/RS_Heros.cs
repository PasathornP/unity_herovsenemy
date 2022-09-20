using UnityEngine;

public class RS_Heros : MonoBehaviour
{
    public Sprite[] Heros;
    // Start is called before the first frame update

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Heros[Random.Range(0, Heros.Length)];
    }
    
}
