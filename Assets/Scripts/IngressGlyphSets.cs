using UnityEngine;
using System.Collections.Generic;
using System;

public class IngressGlyphSets : MonoBehaviour {

	void Update(){}
	void Start(){}


	public int[][] generateQn(int lvl){
		int[][] ans = new int[lvl][];
		Glyphs[] seq = getSequence(lvl);
		for(int i=0; i<lvl; i++){
			ans[i] = getGlyph(seq[i]);
		}
		return ans;
	}

	private Glyphs[] getSequence(int lvl){
		//generate random number, obtain a sequence corresponding to diff lvl

		//number of options for each difficulty level
		int[] optionSizes = new int[]{1,1,0,0};	//value cannot be 0

		UnityEngine.Random.seed = (int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);

		int randNo = UnityEngine.Random.Range(0,optionSizes[lvl-1]-1);
		switch(lvl){
		case 1:
			switch(randNo){
			case 1: 	return new Glyphs[]{Glyphs.SHAPER};
			default: 	return new Glyphs[]{Glyphs.BODY};
			}
		
		case 2:
			switch(randNo){
			case 1: 	return new Glyphs[]{Glyphs.DESTROY,Glyphs.PORTAL};
			default: 	return new Glyphs[]{Glyphs.OPEN,Glyphs.AGAIN};
			}

		default:		return new Glyphs[]{Glyphs.OPEN};

		}


	}

	private int[] getGlyph(Glyphs g){
		switch(g){
		
		case Glyphs.ADVANCE:	return new int[]{10,4,6};
		case Glyphs.AGAIN:		return new int[]{7,1,3,0,2,4};
		case Glyphs.ATTACK:		return new int[]{};
		case Glyphs.DESTROY: 	return new int[]{5,1,0,4,8};
		case Glyphs.BODY:		return new int[]{0,1,2,0};
		case Glyphs.BREATHE: 	return new int[]{5,1,0,2,6};
		case Glyphs.JOURNEY: 	return new int[]{10,7,5,1,0,2,6};
		case Glyphs.OPEN:		return new int[]{3,4,10,3};
		case Glyphs.PORTAL:		return new int[]{5,1,2,6,8,4,3,7,5};
		case Glyphs.SHAPER:		return new int[]{7,3,1,9,2,4,8};
		
		
		default:
		
			return null;


		}
	}

	//open mind obtain enlightenment



	public enum Glyphs{
		ADVANCE,
		AGAIN,
		ATTACK,
		BREATHE,
		BODY,
		HUMAN,
		DESTROY,
		DIE,
		DISCOVER,
		END,
		ENLIGHTEN,
		FUTURE,
		JOURNEY,
		MIND,
		NOT,
		OPEN,
		PORTAL,
		SEEK,
		SELF,
		SHAPER,
		SOUL,
		TRUTH,
		PAST
	};
}




