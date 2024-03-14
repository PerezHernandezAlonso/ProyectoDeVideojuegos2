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
        frasesNarrador.Add("Vivía en una humilde casa, sin muchas florituras. Aquel perro era tan inteligente como persistente. Se dedicaba a investigar y resolver crímenes en las ciudades italianas. Durante años fue el pionero entre los detectives, hasta que un día tuvo un fortuito accidente que lo dejó invidente de por vida.. Una historia realmente trágica. Su nombre, Sloof Dogmes. Habían pasado 30 años desde aquel suceso y no descansó ni un sólo día. Andaba tras la pista del delincuente más famoso de aquellos tiempos, un contrabandista de alcohol que se jactó de estar en contra de la ley seca, el escurridizo Al Catpone. Ambos dejaron una gran huella dolorosa e imborrable en el otro. No existía un sentimiento de venganza entre ellos, sino ganas de demostrar de qué son realmente capaces.");
        frasesNarrador.Add("Busca la llave que abre el cofre de los recuerdos perdidos, donde la risa es moneda de cambio y las melodías guardan secretos. En el lugar donde el humo se mezcla con las letras y las luces bailan al ritmo de la verdad oculta");

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
