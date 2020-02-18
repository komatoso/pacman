using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    public float velocidad = 0.1f;
	public float velocidadV = 0.02f;
	public Text textoContador;
	public int puntuacion = 0;
	public float tiempo = 0;
	public Text Temporizador;
	private string minutos, segundos;
	
	
	

	
	
	void FixedUpdate () {

        //Capturo el movimiento en los ejes
         float movimientoH = Input.GetAxis("Horizontal");
         float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento
         Vector3  movimiento = new Vector3(movimientoH, 0, movimientoV);

        //Muevo el jugador
        transform.position += -movimiento * velocidad;
		tiempo += Time.deltaTime;
		minutosSegundos(tiempo);
		//prueba
		if(GetComponent<NavJugador>().huir && GetComponent<NavJugador>().tempblancos > 0)
        {
			GetComponent<NavJugador>().tempblancos -= Time.deltaTime;
			Debug.Log(GetComponent<NavJugador>().tempblancos);

        }
        else
        {
			GetComponent<NavJugador>().huir = false;

		}
		


	}
	private void OnTriggerEnter(Collider other)
    {

        //Si se come al Coleccionable que da velocidad
        if (other.gameObject.CompareTag("ColeccionableV")){

		velocidad += velocidadV;
		}
		 //Debug.Log (other.gameObject.tag);
    if (other.gameObject.tag == "Enemigo"){
        puntuacion = puntuacion + 10;
        textoContador.text = puntuacion.ToString();
    }
		
	}

	public void updateScore(int points){
    Debug.Log ("updateScore");
    puntuacion = puntuacion + points;
    textoContador.text = puntuacion.ToString();
		}

		void minutosSegundos(float tiempo){

		//Minutos
		if (tiempo > 120){
			minutos = "03";
		}
		else if (tiempo > 60){
			minutos = "02";
		}
		else if(tiempo < 60){
			minutos = "00";
		}
		else{
			minutos = "04";
		}

		//Segundos
		int numSegundos = Mathf.RoundToInt(tiempo % 60);
		if (numSegundos > 9){
			segundos = numSegundos.ToString();
		}
		else{
			segundos = "0" + numSegundos.ToString();
		}

		//Escribo en la caja de texto
		Temporizador.text = minutos + ":" + segundos;

	}

	}


