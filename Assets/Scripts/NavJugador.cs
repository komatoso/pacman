using UnityEngine;

public class NavJugador : MonoBehaviour {

    private Rigidbody rb;
    public float velocidad;
    public bool huir = false;
    public float tempblancos;

	void Start () {

        //Capturo el componente rigidbody del jugador
        rb = GetComponent<Rigidbody>();
		
	}
	
	void FixedUpdate () {
        /*
                //Capturo el movimiento en los ejes
                float movimientoH = Input.GetAxis("Horizontal");
                float movimientoV = Input.GetAxis("Vertical");

                //Genero el vector de movimiento
                Vector3 movimiento = new Vector3(-movimientoH, 0, -movimientoV);

                //Muevo el jugador
                transform.position += movimiento * velocidad;
                */

        //Si los enemigos están huyendo y no se ha acabado el tiempo, decremento el tiempo
        


    }

    void OnTriggerEnter(Collider other)
    {

        //Si atraviesaa con el coleccionable
        if (other.gameObject.CompareTag("Coleccionable")){
            //Borro el coleccionable
            other.gameObject.SetActive(false);

            //Inicio el contador hacia atrás y pongo a true el booleano
            tempblancos = 10;
            Debug.Log(tempblancos);
            huir = true;
            Debug.Log(huir);
            

        }
		//Si atraviesaa con el coleccionable
        if (other.gameObject.CompareTag("ColeccionableV")){
            //Borro el coleccionable
            other.gameObject.SetActive(false);

            //Inicio el contador hacia atrás y pongo a true el booleano
            tempblancos = 10;
           
        }
        
    }
}