using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscribirTextoNarrador : MonoBehaviour
{
    public List<string> frasesNarrador = new List<string>();
    public Text texto;
    public int indiceTextoSeleccionado = 0;

    // Start is called before the first frame update
    void Start()
    {
        frasesNarrador.Add("Vivía en una humilde casa, sin muchas florituras. Aquel perro era tan inteligente como persistente. Se dedicaba a investigar y resolver crímenes en las ciudades italianas. Durante años fue el pionero entre los detectives, hasta que un día tuvo un fortuito accidente que lo dejó invidente de por vida.. Una historia realmente trágica. Su nombre, Sloof Dogmes.");
        frasesNarrador.Add("¡SORPRESA! ¿Creías que me había olvidado de ti? La vida sería muy aburrida sin mi querido amigo Sloof persiguiéndome allá donde vaya... ¿Quieres encontrar a la gallina de los huevos de oro? Pues estás de suerte. Estoy tan cansado de que todo sea tan fácil que he dejado algo interesante para ti en ese bar al que solíamos ir de jóvenes. ¿Lo recuerdas?");

        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        string fraseActual = frasesNarrador[indiceTextoSeleccionado];

        foreach (char caracter in fraseActual)
        {
            texto.text += caracter;
            yield return new WaitForSeconds(0.04f);
        }
    }
}
