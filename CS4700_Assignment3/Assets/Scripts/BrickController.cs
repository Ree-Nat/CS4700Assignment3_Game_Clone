using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    //Breaks when player hurtbox hit object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "playerHeadBox")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
