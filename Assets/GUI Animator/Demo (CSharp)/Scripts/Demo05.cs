﻿// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

#region Namespaces

using UnityEngine;
using System.Collections;

#endregion

/**************
* Demo05 class
* This class handles "Demo05 (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

public class Demo05 : MonoBehaviour
{
	
	#region Variables

	// Canvas
	public Canvas m_Canvas;
	
	// GEAnim objects of title text
	public GEAnim m_Title1;
	public GEAnim m_Title2;
	
	// GEAnim objects of top and bottom bars
	public GEAnim m_TopBar;
	public GEAnim m_BottomBar;

	// GEAnim objects of dialogs
	public GEAnim m_Dialog1;
	public GEAnim m_Dialog2;
	public GEAnim m_Dialog3;
	public GEAnim m_Dialog4;
	
	#endregion
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################
	
	#region MonoBehaviour
	
	// Use this for initialization
	void Awake ()
	{
		//////////////////////////////////////////////////////////////////////
		// If you want to control all GEAnim elements in the scene via scripts, you have to call these line in Awake function.
		// Otherwise, GEAnimSystem will run all GEAnim elements automatically.
		//
		// If you disable this component by uncheck it from the GameObject that it is attached,
		// the GEAnimSystem will control all animations in the scene according to selected animations in Auto Animation of GEAnimSystem.
		//////////////////////////////////////////////////////////////////////
		if(enabled)
		{
			// Use this script to control all animations in the scene instead of GEAnimSystem auto test.
			GEAnimSystem.Instance.m_AutoAnimation = false;
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		// MoveIn m_TopBar and m_BottomBar
		m_TopBar.MoveIn(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveIn(eGUIMove.SelfAndChildren);
		
		// MoveIn m_Title1 and m_Title2
		StartCoroutine(MoveInTitleGameObjects());
		
		// Disable all scene switch buttons	
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	#endregion
	
	// ######################################################################
	// MoveIn/MoveOut functions
	// ######################################################################
	
	#region MoveIn/MoveOut
	
	// MoveIn m_Title1 and m_Title2
	IEnumerator MoveInTitleGameObjects()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn m_Dialog
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn m_Dialog
	IEnumerator MoveInPrimaryButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn dialogs
		m_Dialog1.MoveIn(eGUIMove.SelfAndChildren);	
		m_Dialog2.MoveIn(eGUIMove.SelfAndChildren);	
		m_Dialog3.MoveIn(eGUIMove.SelfAndChildren);	
		m_Dialog4.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	public void HideAllGUIs()
	{
		// MoveOut dialogs
		m_Dialog1.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog2.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog3.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog4.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut m_Title1 and m_Title2
		StartCoroutine(HideTitleTextMeshes());
	}
	
	// MoveOut m_Title1 and m_Title2
	IEnumerator HideTitleTextMeshes()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveOut m_Title1 and m_Title2
		m_Title1.MoveOut(eGUIMove.Self);
		m_Title2.MoveOut(eGUIMove.Self);
		
		// MoveOut m_TopBar and m_BottomBar
		m_TopBar.MoveOut(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveOut(eGUIMove.SelfAndChildren);
	}
	
	#endregion
	
	// ######################################################################
	// Enable/Disable button functions
	// ######################################################################
	
	#region Enable/Disable buttons
	
	// Enable/Disable all scene switch Coroutine	
	IEnumerator EnableAllDemoButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
		// Enable all scene switch buttons
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
	}
	
	// Disable all buttons for a few seconds
	IEnumerator DisableButtonForSeconds(GameObject GO, float DisableTime)
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableButton(GO.transform, false);
		
		yield return new WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GEAnimSystem.Instance.EnableButton(GO.transform, true);
	}
	
	#endregion
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
	
	#region Button Handler
	
	public void OnButton_Dialog1()
	{			
		// MoveOut m_Dialog1
		m_Dialog1.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog1 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog1.gameObject, 2.5f));
		
		// MoveIn m_Dialog1
		StartCoroutine(Dialog1_MoveIn());
	}
	
	public void OnButton_Dialog2()
	{
		// MoveOut m_Dialog2
		m_Dialog2.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog2 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog2.gameObject, 2.5f));
		
		// MoveIn m_Dialog2
		StartCoroutine(Dialog2_MoveIn());
	}
	
	public void OnButton_Dialog3()
	{
		// MoveOut m_Dialog3
		m_Dialog3.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog3 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog3.gameObject, 2.5f));
		
		// MoveIn m_Dialog3
		StartCoroutine(Dialog3_MoveIn());
	}
	
	public void OnButton_Dialog4()
	{
		// MoveOut m_Dialog4
		m_Dialog4.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog4.gameObject, 2.5f));
		
		// MoveIn m_Dialog4
		StartCoroutine(Dialog4_MoveIn());
	}
	
	public void OnButton_MoveOutAllDialogs()
	{		
		// Disable m_Dialog1, m_Dialog2, m_Dialog3, m_Dialog4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog1.gameObject, 2.5f));
		StartCoroutine(DisableButtonForSeconds(m_Dialog2.gameObject, 2.5f));
		StartCoroutine(DisableButtonForSeconds(m_Dialog3.gameObject, 2.5f));
		StartCoroutine(DisableButtonForSeconds(m_Dialog4.gameObject, 2.5f));

		// MoveOut dialogs
		m_Dialog1.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog2.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog3.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog4.MoveOut(eGUIMove.SelfAndChildren);
		
		// Move dialogs back to screen with Coroutines
		StartCoroutine(Dialog1_MoveIn());
		StartCoroutine(Dialog2_MoveIn());
		StartCoroutine(Dialog3_MoveIn());
		StartCoroutine(Dialog4_MoveIn());
	}
	
	#endregion
	
	// ######################################################################
	// Move dialog functions
	// ######################################################################
	
	#region Move Dialog
	
	// MoveIn m_Dialog1
	IEnumerator Dialog1_MoveIn()
	{
		yield return new WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog1
		m_Dialog1.ResetAllChildren();
		
		// Moves m_Dialog1 back to screen to screen
		m_Dialog1.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// MoveIn m_Dialog2
	IEnumerator Dialog2_MoveIn()
	{
		yield return new WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog2
		m_Dialog2.ResetAllChildren();
		
		// Moves m_Dialog2 back to screen to screen
		m_Dialog2.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// MoveIn m_Dialog3
	IEnumerator Dialog3_MoveIn()
	{
		yield return new WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog3
		m_Dialog3.ResetAllChildren();
		
		// Moves m_Dialog3 back to screen to screen
		m_Dialog3.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// MoveIn m_Dialog4
	IEnumerator Dialog4_MoveIn()
	{
		yield return new WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog4
		m_Dialog4.ResetAllChildren();
		
		// Moves m_Dialog4 back to screen to screen
		m_Dialog4.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	#endregion
}
