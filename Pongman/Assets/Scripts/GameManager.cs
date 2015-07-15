using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public int server = 1337, client = 42;
	static public int connectionType = 0;

	static public string userName = "Unknown";
	static public int maximumNumberOfPlayersConnected = -1;
	static public int connectedPlayers=0;

	static public string gameState;
	static public string waitingForConnections="WAITING";
	static public string playingGame="GAME";

	static public void setGameState(string gs){
		gameState = gs;
	}

	static public string serverIP;
	static public int serverPort=4444;

	static public void setServer(){
		connectionType = server;
	}

	static public void setClient(){
		connectionType = client;
	}

	static public string displayType(){
		if (connectionType == server)
			return "Server";
		else if (connectionType == client)
			return "Client";
		return "unknown type";
	}

	static public int BUTTON_WIDTH = 200;
	static public int BUTTON_HEIGHT = 50;
	static public int SPACER_COL = 25;
	static public int SPACER_ROW = 25;

	static public int COLUMNS;
	static public int ROWS;

	static public void setTableLayout(int _rows, int _columns){
		ROWS = _rows;
		COLUMNS = _columns;
	}


	static public Rect getShrekt(int idxRow, int idxColumn)    //adds rectangular widget into 'table' defined by ROWSxCOLUMNS on position [idxROWxidxColumn]
	{ 
		int TOTAL_HEIGHT = (COLUMNS-1)*SPACER_COL + COLUMNS * BUTTON_HEIGHT;
		int TOTAL_WIDTH = (ROWS-1)*SPACER_ROW + ROWS * (BUTTON_WIDTH);
		return new Rect (Screen.width / 2 - TOTAL_WIDTH/2 + idxRow*BUTTON_WIDTH + (idxRow)*SPACER_ROW, 
		            Screen.height / 2 - TOTAL_HEIGHT/2 + idxColumn * BUTTON_HEIGHT + (idxColumn) * SPACER_COL,
		            BUTTON_WIDTH,
		            BUTTON_HEIGHT);
	} 

	static public Rect getShrekt(int idxRow, int idxColumn, float scaleWidth, float scaleHeight)    //adds rectangular widget into 'table' defined by ROWSxCOLUMNS on position [idxROWxidxColumn]
	{ 
		int TOTAL_HEIGHT = (COLUMNS-1)*SPACER_COL + COLUMNS * BUTTON_HEIGHT;
		int TOTAL_WIDTH = (ROWS-1)*SPACER_ROW + ROWS * (BUTTON_WIDTH);
		return new Rect (Screen.width / 2 - TOTAL_WIDTH/2 + idxRow*BUTTON_WIDTH + (idxRow)*SPACER_ROW, 
		                 Screen.height / 2 - TOTAL_HEIGHT/2 + idxColumn * BUTTON_HEIGHT + (idxColumn) * SPACER_COL,
		                 BUTTON_WIDTH * scaleWidth,
		                 BUTTON_HEIGHT * scaleHeight);
	}

	static public void drawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}

	static public void drawBoxAroundScene(Color color){
		drawQuad (new Rect (Screen.width/2-ROWS*BUTTON_WIDTH/2 - (ROWS-1)*SPACER_ROW/2 - 2,
		                    Screen.height/2-COLUMNS*BUTTON_HEIGHT/2 - (COLUMNS-1)*SPACER_COL/2 - 2,
		                    ROWS*BUTTON_WIDTH+(ROWS-1)*SPACER_ROW + 4,
		                    COLUMNS*BUTTON_HEIGHT+(COLUMNS-1)*SPACER_COL+4), color);
	}

	static public void drawBorderAroundScene(Color color, int size){
		drawQuad (new Rect (Screen.width/2-ROWS*BUTTON_WIDTH/2 - (ROWS-1)*SPACER_ROW/2 - size - 2,
		                    Screen.height/2-COLUMNS*BUTTON_HEIGHT/2 - (COLUMNS-1)*SPACER_COL/2 - size - 2,
		                    ROWS*BUTTON_WIDTH+(ROWS-1)*SPACER_ROW + size*2 + 4,
		                    COLUMNS*BUTTON_HEIGHT+(COLUMNS-1)*SPACER_COL + size*2 + 4), color);
	}
}
