using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    [SerializeField] private int heart;
    [SerializeField] private int sword;
    [SerializeField] private int shield;
    public string[] ctype = new string[]{"Red", "Green", "Blue"};
    [SerializeField] private string colortype;
    private Hero_Movement1 targeted_player;

    private void Awake() {
        heart = Random.Range(10, 20);
        sword = Random.Range(2, 8);
        shield = Random.Range(0, 3);
        colortype = ctype[Random.Range(0, 2)];
    }

    public void Damage (int amount, string type){
        if (this.colortype == type){
            amount *= 2;
        }
        amount -= this.shield;
        amount = Mathf.Clamp(amount, 1, int.MaxValue);
        this.heart -= amount;
        if (heart <= 0){
            Die();
        }
    }

    public int getHeart(){
        return heart;
    }

    public int getSword(){
        return sword;
    }

    public int getShield(){
        return shield;
    }
    
    public string getColorType(){
        return colortype;
    }



   

    public void Die(){
        Destroy(gameObject);
    }
}
