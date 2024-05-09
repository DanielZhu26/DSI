using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Textoenriquezido : MonoBehaviour
{
    public void startComponent()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement rootVe = uiDoc.rootVisualElement;
      

            Label texto = rootVe.Q<Label>("Comun");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team A>Comun</gradient></b>";
            }

             texto = rootVe.Q<Label>("Comun2");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team A>Comun</gradient></b>";
            }

             texto = rootVe.Q<Label>("Comun3");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team A>Comun</gradient></b>";
            }


            texto = rootVe.Q<Label>("Rara");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team B>Rara</gradient></b>";
            }

            texto = rootVe.Q<Label>("Rara2");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team B>Rara</gradient></b>";
            }


            texto = rootVe.Q<Label>("Rara3");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team B>Rara</gradient></b>";
            }

            texto = rootVe.Q<Label>("Epica");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team C>Epica</gradient></b>";
            }

            texto = rootVe.Q<Label>("Epica2");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team C>Epica</gradient></b>";
            }



            texto = rootVe.Q<Label>("Legendaria");

            if (texto != null)
            {
                texto.text = @"<b><color=black><gradient=Team D>Legend</gradient></b>";
            }
           
   

       
    }
}
