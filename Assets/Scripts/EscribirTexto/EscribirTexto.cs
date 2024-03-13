
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscribirTextoNarrador : MonoBehaviour
{
    string frase = "Vivía en una humilde casa, sin muchas florituras. Aquel perro era tan inteligente como persistente. Se dedicaba a investigar y resolver crímenes en las ciudades italianas. Durante años fue el pionero entre los detectives, hasta que un día tuvo un fortuito accidente que lo dejó invidente de por vida.. Una historia realmente trágica. Su nombre, Sloof Dogmes. Habían pasado 30 años desde aquel suceso y no descansó ni un sólo día. Andaba tras la pista del delincuente más famoso de aquellos tiempos, un contrabandista de alcohol que se jactó de estar en contra de la ley seca, el escurridizo Al Catpone. Ambos dejaron una gran huella dolorosa e imborrable en el otro. No existía un sentimiento de venganza entre ellos, sino ganas de demostrar de qué son realmente capaces.";
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.08f);
        }
    }
}