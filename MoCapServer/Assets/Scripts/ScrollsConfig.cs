using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollsConfig : MonoBehaviour {

	public List<ScrollRect> scrolls;
	public List< LoopVerticalScrollRect> lScorlls;


	public void SetScroll( ){
		foreach( ScrollRect sr in scrolls ){
			sr.content.GetComponent<RectTransform>( ).anchoredPosition =  new Vector2( sr.content.GetComponent<RectTransform>( ).anchoredPosition.x , 0f );
		}

		foreach( LoopVerticalScrollRect sr in lScorlls ){
			if( sr.gameObject.activeInHierarchy ){
				sr.content.GetComponent<RectTransform>( ).anchoredPosition =  new Vector2( sr.content.GetComponent<RectTransform>( ).anchoredPosition.x , 0f );
				sr.RefillCells(0);
//				sr.RefreshCells( );
			}
		}
	}

}
