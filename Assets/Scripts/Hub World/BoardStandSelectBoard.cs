﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStandSelectBoard : SelectedObject
{
    BoardManager boardManager;

    //our material and board types are stored in the BoardStandScript
    BoardStandProperties selectionVariables;

    Material renderMat = null;

    [SerializeField] Color emissionColor;

    new private void Start()
    {
        base.Start();
        boardManager = GameManager.instance.boardScript;

        selectionVariables = GetComponentInParent<BoardStandProperties>();
        renderMat = gameObject.GetComponent<Renderer>().material;
        //Color boardColor = renderMat.color;
        renderMat.SetColor("_EmissionColor", Color.black);
        //renderMat.DisableKeyword("_EMISSION");
    }

    protected override void SelectedFunction()
    {
        base.SelectedFunction();
        //renderMat.EnableKeyword("_EMISSION");
        renderMat.SetColor("_EmissionColor", emissionColor);
    }
    protected override void DeselectedFunction()
    {
        base.DeselectedFunction();
        //renderMat.DisableKeyword("_EMISSION");
        renderMat.SetColor("_EmissionColor", Color.black);
    }
    override public void SuccessFunction()
    {
        //set the player board to one of our pre-defined boards
        boardManager.BoardSelect(selectionVariables.boardType);

        EventManager.OnCallBoardMenuEffects();
    }

}
