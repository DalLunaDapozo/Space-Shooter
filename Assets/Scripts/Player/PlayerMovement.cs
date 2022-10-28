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
    
    //Ac� le asignamos un valor a nuestra variable de fisica. Si no hacemos esto nos va a tirar un error diciendo que nuestra variables
    //est� vac�a, o "null"
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

    //Como estamos moviendo nuestra nave a trav�s de f�sicas, ponemos nuestra variable dentro del FIXED UPDATE
    private void FixedUpdate(){

        //PassAxisValueToVelocity();
    }

    //Ac� creo una funci�n, una funci�n es un pedazo de c�digo que podemos reutilizar todo el tiempo y que cumple una funci�n 
    //que le asignemos

    //PassAxisValueToVelocity es el nombre que yo le asign�

    //rb.velocity es como accedemos al movimiento de nuestra fisica
    //Le pasamos la funcion ReadInputAxis que creamos m�s abajo que lee el input de nuestra clase InputManager y lo multiplica
    //por nuestra velocidad de movimiento, variable que creamos m�s arriba y tambi�n lo multiplica por "tiempo delta", es una fraccion 
    //de milisegundos que sucede entre frame y frame, no se preocupen por este detalle. Pero se hace as� para mover de forma flu�da nuestras 
    //fisicas
    
    //Las funciones suelen ser de tipo "void" (vac�o en ingl�s) porque no devuelven ning�n valor, pero la funci�n de abajo en vez de "void"
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
