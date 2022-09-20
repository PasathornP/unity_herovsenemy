using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Hero_Movement1 : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    public List<Transform> _party;
    public GameOverScreen GameOverScreen;
    public int score = 0;
    public TMP_Text points;
    private void Start() {
         _party = new List<Transform>();
         _party.Add(this.transform);
         _party.Add(GameObject.Find("start_hero").transform);
    }
    private void Update() {
        _party.RemoveAll(s => s == null);
        points.text = score.ToString() + " POINTS";
        if (_party.Count < 2){
            Destroy(points.GetComponent<TMP_Text>());
            GameOverScreen.Setup(score);
        }
        _party[1].position = _party[0].position;
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            _direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)){
            _direction = Vector2.right;
            _party[1].GetComponent<SpriteRenderer>().flipX = false;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            _direction = Vector2.left;
            _party[1].GetComponent<SpriteRenderer>().flipX = true;
        }
        
        

        if (Input.GetKeyDown(KeyCode.A)){
            SwapF();
        } else if (Input.GetKeyDown(KeyCode.D)){
            SwapB();
        }

        
        
    }

    private void FixedUpdate() {
        
        for (int i = _party.Count - 1; i > 0; i--)
        {
                _party[i].position = _party[i-1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );


    }
    
    private void JoinParty(GameObject other){
        other.tag = "Player"; 
        other.transform.position = _party[_party.Count - 1].position; 
        _party.Add(other.transform); 
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Hero"){
            JoinParty(other.gameObject);
        } else if (other.tag == "WallUp"){
            _party[1].GetComponent<CharacterStat>().Die();
            _direction = Vector2.up;
        } else if (other.tag == "WallDown"){
            _party[1].GetComponent<CharacterStat>().Die();
            _direction = Vector2.down;
        } else if (other.tag == "WallRight"){
            _party[1].GetComponent<CharacterStat>().Die();
            _direction = Vector2.right;
            
        } else if (other.tag == "WallLeft"){
            _party[1].GetComponent<CharacterStat>().Die();
            _direction = Vector2.left;
            
        }
    }
    
    void SwapB(){
        for (int i = _party.Count - 1; i > 1; i--)
        {
            Transform temp = _party[i];
            _party[i].position = _party[i-1].position;
            _party[i]= _party[i-1];
            _party[i-1] = temp;
            
        }
         
     }

     void SwapF(){
        for (int i = 2; i < _party.Count; i++)
        {
            Transform temp = _party[i-1];
            _party[i-1].position = _party[i].position;
            _party[i-1]= _party[i];
            _party[i] = temp;
            
        }
         
     }


    public void addScore(int number){
        score += number;
    }
}
