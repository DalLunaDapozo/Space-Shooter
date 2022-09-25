using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public int damage;

    private void Update(){
        
        TranslationMovement();
        WhenOutofBounds();
    }   
    private void TranslationMovement(){

        transform.Translate(translation: Vector3.up * speed * Time.deltaTime);
    }
    public void OnStart(float initial_speed, int initial_dmg){

        speed = initial_speed;
        damage = initial_dmg;
    }
    private void WhenOutofBounds() {

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (transform.position.y > screenBounds.y) {

            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {

            collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable);
            damageable.Damage(damage);
            Destroy(gameObject);
        }
    }
}
