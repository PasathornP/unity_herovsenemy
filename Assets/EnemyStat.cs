using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private int heart;
    [SerializeField] private int sword;
    [SerializeField] private int shield;
    public string[] ctype = new string[]{"Red", "Green", "Blue"};
    [SerializeField] private string colortype;
    private Hero_Movement1 targeted_player;
    private Hero_Movement1 Hero_Movement1;

    private void Awake() {
        heart = Random.Range(5,15);
        sword = Random.Range(5,10);
        shield = Random.Range(0, 3);
        colortype = ctype[Random.Range(0, 2)];
    }

    public void Damage (int amount, string type, Collider2D player){
        if (this.colortype == type){
            amount *= 2;
        }
        amount -= this.shield;
        amount = Mathf.Clamp(amount, 1, int.MaxValue);
        this.heart -= amount;
        if (heart <= 0){
            Time.fixedDeltaTime -= 0.002f;
            targeted_player = player.GetComponent<Hero_Movement1>();
            targeted_player.addScore(targeted_player._party[1].GetComponent<CharacterStat>().getHeart());
            Die();
        } else if (heart > 0){
            targeted_player = player.GetComponent<Hero_Movement1>();
            targeted_player._party[1].GetComponent<CharacterStat>().Damage(this.sword, this.colortype);
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


    private void Die(){
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D player){
        targeted_player = player.GetComponent<Hero_Movement1>();
        if (player.tag == "Player"){
            Damage(targeted_player._party[1].GetComponent<CharacterStat>().getSword(), targeted_player._party[1].GetComponent<CharacterStat>().getColorType(), player);
        }
    }

    
    
}
