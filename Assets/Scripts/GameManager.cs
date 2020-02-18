using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public GameObject enemigo, coleccionable, coleccionableV;
    public Vector3 posicion;
    public int numeroEnemigos;
    public float esperaInicial;
    public float esperaEntreEnemigos;
    public float esperaEntreOlas, esperaEntreColeccionables, esperaEntreColeccionablesV;
	//array de posiciones donde apareceran los enemigos
	public float [] posEx = {-4.1f, 3.8f, 6.85f, 1.6f, -7.23f, -8.8f, 9.1f};
	public float [] posEz = {-7.3f, -3.9f, -5.9f, 5.4f, 5.4f, -1.3f, 0.86f};
    public Text TextPlayAgain;
	

    void Start()
    {

        //LLamo a la rutina de crear enemigos
        StartCoroutine(crearEnemigos());

        //LLamo a la rutina de crear coleccionables
        StartCoroutine(crearColeccionables());
        TextPlayAgain.enabled = false;

    }
		
    IEnumerator crearEnemigos()
    {
       //Espero un tiempo antes de crear enemigos
       yield return new WaitForSeconds(esperaInicial);

        //Bucle durante toda la vida del juego
        while (true)
        {
            //Bucle de número de enemigos
            for (int i = 0; i < numeroEnemigos; i++)
            {
			
                //Instancio el enemigo en una posición aleatoria del tablero
                //Vector3 posicionEnemigo = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
				int indicePos = Random.Range(0,7);
				Vector3 posicionEnemigo = new Vector3((posEx[indicePos]), posicion.y, (posEz[indicePos]));
                Quaternion rotacionEnemigo = Quaternion.identity;
                Instantiate(enemigo, posicionEnemigo, rotacionEnemigo);

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreEnemigos);
            }

            //Espero un tiempo entre oleadas de enemigos
            yield return new WaitForSeconds(esperaEntreOlas);
        }
    }

    IEnumerator crearColeccionables()
    {
        yield return new WaitForSeconds(esperaInicial);
        while (true)
        {
            //Instancio el coleccionable en una posición aleatoria del tablero
            Vector3 posicionColeccionable = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
            Quaternion rotacionColeccionable = Quaternion.identity;
            Instantiate(coleccionable, posicionColeccionable, rotacionColeccionable);

			Vector3 posicionColeccionableV = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
            Quaternion rotacionColeccionableV = Quaternion.identity;
			Instantiate(coleccionableV, posicionColeccionableV, rotacionColeccionableV);

            //Espero un tiempo entre la creación de cada coleccionable
            yield return new WaitForSeconds(esperaEntreColeccionables);
			yield return new WaitForSeconds(esperaEntreColeccionablesV);
               

        }
		}

		void Update () {
        //Reiniciar el juego con la tecla R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("PrpyectoPacmanModificado2");
        }


    }
}