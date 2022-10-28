using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    //Aca en este script creamos las balas de la navecita

    //HIDEININSPECTOR lo usamos cuando queremos que la variable sea pública pero no queremos quemos verla en Unity
    //porque no queremos tocar las variables desde ahí

    [HideInInspector] public float speed;
    [HideInInspector] public int damage;

    private void Update(){
        
        TranslationMovement();
        WhenOutofBounds();
    }   
    
    //La translación la hacemos por transform y no por físicas

    private void TranslationMovement(){

        transform.Translate(translation: Vector3.up * speed * Time.deltaTime);
    }
    
    //Esta función es para que la bala se destruya cuando se sale de la pantalla
    private void WhenOutofBounds() {

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (transform.position.y > screenBounds.y) {

            Destroy(gameObject);

        }
    }

    // Esta funcion es publica y no la vamos a implementar en este script, sino en otro script
    public void OnStart(float initial_speed, int initial_dmg)
    {
        speed = initial_speed;
        damage = initial_dmg;
    }

    //OnTriggerEnter es una funcion de Unity que detecta las colisiones gracias al sistema de TAGS

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detecta que lo que toca es tiene un tag ENEMY
        if (collision.gameObject.tag == "Enemy") {

            collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable);
            damageable.Damage(damage);
            Destroy(gameObject);
        }
    }
}
