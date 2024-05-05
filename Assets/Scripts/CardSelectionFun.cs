using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.IO;
using UnityEditor;
public class CardSelectionFun : MonoBehaviour
{
    InfoCard selectCardInfo;

    //VisualElement botonGuardar;

    string imageCard;

    VisualElement photoContainer;

    VisualElement desk;

    List<InfoCard> list_infoCard = new List<InfoCard>();
    private void OnEnable()
    {

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        desk = root.Q("Desk");

        //botonGuardar = root.Q<Button>("BotonGuardar");

        desk.RegisterCallback<ClickEvent>(selectionCard);

        photoContainer = root.Q("CardSelection");

        List<VisualElement> list_ve_h = new();
        list_ve_h.AddRange(photoContainer.Children().ToList());


        list_ve_h.ForEach(elem => {

            elem.RegisterCallback<ClickEvent, VisualElement>(ChangeCard, elem);

        });

        //botonGuardar.RegisterCallback<ClickEvent>(guardarInfo);

        InicializarTarjetas();

    }

    void InicializarTarjetas()
    {
        list_infoCard.ForEach(elem =>
        {

            VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Description");
            VisualElement cardPlantilla = plantilla.Instantiate();

            desk.Add(cardPlantilla);
            card_borde_negro();
            card_borde_blanco(cardPlantilla);

            InfoCard cardInfo = new InfoCard(elem.elixir, elem.image);
            Card tarjeta = new Card(cardPlantilla, cardInfo);
            selectCardInfo = cardInfo;
        });
    }


    //void guardarInfo(ClickEvent evt)
    //{

    //    string listaToJson = JSONHelperIndividuo.ToJson(list_individuo, true);

    //    string path = Path.Combine(Application.persistentDataPath, "lista_individuos");

    //    File.WriteAllText(path, listaToJson);

    //    Debug.Log(path);

    //}

    void selectionCard(ClickEvent evt)
    {
        VisualElement card = evt.target as VisualElement;
        selectCardInfo = card.userData as InfoCard;

        card_borde_negro();
        card_borde_blanco(card);

    }

    void ChangeCard(ClickEvent evt, VisualElement selected)
    {

        selectCardInfo.image = (string)AssetDatabase.GetAssetPath(selected.resolvedStyle.backgroundImage.texture);
        //selectCardInfo.elixir = selected.
        selectCardInfo.ActivateChange();

    }

    void card_borde_negro()
    {
        List<VisualElement> list_tarjetas = desk.Children().ToList();
        list_tarjetas.ForEach(elem =>
        {

            VisualElement tarjeta = elem.Q("Tarjeta");

            tarjeta.style.borderBottomColor = Color.black;
            tarjeta.style.borderRightColor = Color.black;
            tarjeta.style.borderTopColor = Color.black;
            tarjeta.style.borderLeftColor = Color.black;

        });
    }

    void card_borde_blanco(VisualElement card)
    {

        VisualElement carta = card.Q("Tarjeta");

        carta.style.borderBottomColor = Color.yellow;
        carta.style.borderRightColor = Color.yellow;
        carta.style.borderTopColor = Color.yellow;
        carta.style.borderLeftColor = Color.yellow;

    }



}
