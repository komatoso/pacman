using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        Usuario usuario = new Usuario("jairo","12345678");
        string urlJson = "http://157.230.102.160/formacion/ceu/daw-2019-20/cms/public/index.php/unityjson";
        string urlPost = "http://157.230.102.160/formacion/ceu/daw-2019-20/cms/public/index.php/unitypost";
        string urlGet = "http://157.230.102.160/formacion/ceu/daw-2019-20/cms/public/index.php/unityget";

        //Recibir JSON
        StartCoroutine(Mostrar(urlJson));
        
        //Comprobar con POST
        StartCoroutine(ComprobarPost(usuario, urlPost));

        //Comprobar con GET
        StartCoroutine(ComprobarGet(usuario, urlGet));

    }

    IEnumerator Mostrar(string urlJson)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlJson))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Noticia[] noticias = JsonHelper.getJsonArray<Noticia> (jsonResponse);
                string listadoTitulos = "";

                for (int i = 0; i < noticias.Length; i++)
                {
                    listadoTitulos += noticias[i].titulo + " ";
                }
                Debug.Log(listadoTitulos);
            }
        }
   
    
    }

    IEnumerator ComprobarPost(Usuario usuario, string urlPost)
    {
       
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario.usuario);
        form.AddField("clave", usuario.clave);

        using (UnityWebRequest www = UnityWebRequest.Post(urlPost, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerator ComprobarGet(Usuario usuario, string urlGet)
    {

        string urlData = urlGet + "?usuario=" + usuario.usuario + "&clave=" + usuario.clave;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlData))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                 Debug.Log(webRequest.downloadHandler.text);
            }
        }
   
    
    }*/

}
