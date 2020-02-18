using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MostrarNoticias : MonoBehaviour
{
    [SerializeField] private Text textoNoticias, textoError;
    [SerializeField] private InputField inputUsuario;
    [SerializeField] private InputField inputContrasena;
    
    private Usuario usuario;
    private string puedo = "";
    private string urlLogin = "http://35.180.254.5/aaaProyectoPacman/public/index.php/comprobar";
    private string urlPartidas = "http://35.180.254.5/aaaProyectoPacman/public/index.php/json";
    private RectTransform rt;
    private bool jugar = false;
    public float velocidad = 100;
    void Start()
    {
        
        GetComponent<Button>().onClick.AddListener(() => ComprobarUsuario());
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void ComprobarUsuario()
    {
        //Recupero el usuario del input
        if (inputUsuario.text == "" || inputContrasena.text=="")
        {
            textoError.text = "Debes introducir un usuario y contraseña";
        }
        else
        {
            
            
                textoError.text = "";
                usuario = new Usuario(inputUsuario.text, inputContrasena.text);
                StartCoroutine(ApiLogin(urlLogin, usuario));

                StartCoroutine(ApiJson(urlPartidas, usuario));
            




        }

    }

    
    IEnumerator ApiLogin(string urlLogin, Usuario usuario)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario.usuario);
        form.AddField("contrasena", usuario.contrasena);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlLogin, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                textoError.text = webRequest.error;
                
            }
            else if (webRequest.downloadHandler.text == "no")
            {
                textoError.text = "Usuario no autorizado";
            }
            else { puedo=webRequest.downloadHandler.text;
                SceneManager.LoadScene("PrpyectoPacmanModificado2");

            }
            /*{
                string jsonResponse = webRequest.downloadHandler.text;
                Noticia[] noticias = JsonHelper.getJsonArray<Noticia> (jsonResponse);
                string listado = "";
                for (int i = 0; i < noticias.Length; i++)
                {
                    listado += noticias[i].titulo + "\n" + noticias[i].entradilla + "\n\n";
                }
                textoNoticias.text = listado;
                roll = true;
            }*/
        }
    }
    IEnumerator ApiJson(string urlPartidas, Usuario usuario)
    {
        WWWForm form = new WWWForm();
        //form.AddField("usuario", usuario.usuario);
        //form.AddField("contrasena", usuario.contrasena);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlPartidas, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                textoError.text = webRequest.error;

            }
            else if (webRequest.downloadHandler.text == "no")
            {
                textoError.text = "Usuario no autorizado";
            }
            else 
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Partida[] noticias = JsonHelper.getJsonArray<Partida> (jsonResponse);
                
                for (int i = 0; i < noticias.Length; i++)
                {
                    if (noticias[i].usuario == usuario.usuario)
                    {
                        textoError.text += noticias[i].fecha + "  Puntos: " + noticias[i].puntuacion + "  Duración: " + noticias[i].duracion;
                    }
                }
                

            }
            
        }
    }

}
