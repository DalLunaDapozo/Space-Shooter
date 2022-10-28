using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Hola gente!
   
    //Aca declaramos la variable rigidbody que nos permite acceder a nuestro componente
    //que creamos en unity y nos permite controlar las fisicas de nuestra navecita
    private Rigidbody2D rb;
    
    //Esta es una variable de tipo vector 2, es decir un par de numeros x e y, que siempre estan juntos
    //y son muy importante para posicionarnos en el mundo de nuestro juego 2d
    private Vector2 input_axis = Vector2.zero;

    //Esta variable va a ser la que controle la velocidad de movimiento de nuestra nave, aca la declaramos pero
    //vamos a verla implimentada mas abajo
    [SerializeField] private float velocidadDeMovimiento = 10f;
    [SerializeField] private float transformVelocidad;

    public bool can_move;

    //Esto es un poco mas complejo: yo utilizo un sistema de input un poco mas avanzado, que consiste en crear una clase
    //llamada inputmanager donde creo funciones que me permiten acceder a los inputs de forma mas controlada. pueden entrar
    //al script de input manager en las carpeta inputs para ver como funciona

    //On enable es una funcion que se activa cada vez que activamos nuestro objeto. usamos la funcion enableinput de unity 
    //para activar nuestro input
    private void OnEnable(){
       
        InputManager.GetInstance().EnableInput();
    }
    
    //Acá le asignamos un valor a nuestra variable de fisica. Si no hacemos esto nos va a tirar un error diciendo que nuestra variables
    //está vacía, o "null"
    private void Awake(){
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!can_move) return;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-transformVelocidad, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(transformVelocidad, 0) * Time.deltaTime);
        }
        else return;
    }

    //Como estamos moviendo nuestra nave a través de físicas, ponemos nuestra variable dentro del FIXED UPDATE
    private void FixedUpdate(){

        //PassAxisValueToVelocity();
    }

    //Acá creo una función, una función es un pedazo de código que podemos reutilizar todo el tiempo y que cumple una función 
    //que le asignemos

    //PassAxisValueToVelocity es el nombre que yo le asigné

    //rb.velocity es como accedemos al movimiento de nuestra fisica
    //Le pasamos la funcion ReadInputAxis que creamos más abajo que lee el input de nuestra clase InputManager y lo multiplica
    //por nuestra velocidad de movimiento, variable que creamos más arriba y también lo multiplica por "tiempo delta", es una fraccion 
    //de milisegundos que sucede entre frame y frame, no se preocupen por este detalle. Pero se hace así para mover de forma fluída nuestras 
    //fisicas
    
    //Las funciones suelen ser de tipo "void" (vacío en inglés) porque no devuelven ningún valor, pero la función de abajo en vez de "void"
    //dice "Vector2", eso es porque devuelve un valor de este tipo. Por ahora tampoco se preocupen tanto por esto.
    
    private void PassAxisValueToVelocity(){
        
        rb.velocity = ReadInputAxis() * velocidadDeMovimiento * Time.deltaTime;
    }
    private Vector2 ReadInputAxis()
    {
        input_axis = InputManager.GetInstance().GetMoveDirection();
        return input_axis;
    }
}
