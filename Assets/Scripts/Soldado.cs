using UnityEngine;

public class Soldado : MonoBehaviour
{
    [SerializeField] protected int danio;
    [SerializeField] protected int vida;
    [SerializeField] protected float velocidad_movimiento = 1000;
    [SerializeField] protected bool isPlayer = false;
    [SerializeField] protected States currentState = States.idle;
    protected Rigidbody2D rb;

    public enum States
    {
        idle,
        moving,
        attack,
        death
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            currentState = States.attack;
        Debug.Log("Attack");
    }

    private void FixedUpdate()
    {
        if (isPlayer)
        {
            Move();
        }
    }

    public int get_soldado_dmg()
    {
        return danio;
    }

    public void set_soldado_dmg(int new_soldado_dmg)
    {
        danio = new_soldado_dmg;
    }

    public int get_soldado_vida()
    {
        return vida;
    }

    public void set_luchador_vida(int new_soldado_vida)
    {
        vida = new_soldado_vida;
    }

    public void Move()
    {
        Vector2 velocity = new Vector2();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("izquierda");
            velocity.x = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("derecha");
            velocity.x = 1;
        }
        velocity.Normalize();
        if (velocity.magnitude != 0)
        {
            currentState = States.moving;
        }
        else
        {
            currentState = States.idle;
        }
    }

    public void SetCurrentStates (States state)
    {
        if (currentState != state)
        {
            currentState = state;
            switch(currentState)
            {
                case States.idle:
                    rb.velocity = new Vector2();
                    Debug.Log("Nuevo estado: IDLE");
                    break;
                case States.moving:
                    Debug.Log("Nuevo estado: MOVING");
                    break;
                case States.attack:
                    Debug.Log("Nuevo estado: ATTACK");
                    break;
                case States.death:
                    Debug.Log("Nuevo estado: DEATH");
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D");
    }
}