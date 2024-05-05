using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Unity.VisualScripting.LudiqRootObjectEditor;
using UnityEngine.UIElements;

public class Card
{

    InfoCard info;

    VisualElement cardRoot;

    Label elixirLabel;

    VisualElement image;

    public Card(VisualElement cardRoot, InfoCard info)
    {

        this.cardRoot = cardRoot;
        this.info = info;

        elixirLabel = cardRoot.Q<Label>("amount");

        image = cardRoot.Q<VisualElement>("Card");

        this.cardRoot.userData = info;

        UpdateUI();

        info.Cambio += UpdateUI;

    }

    void UpdateUI()
    {
        elixirLabel.text = info.elixir;

        image.style.backgroundImage = Resources.Load<Texture2D>(Path.GetFileNameWithoutExtension(info.image));
    }




}
