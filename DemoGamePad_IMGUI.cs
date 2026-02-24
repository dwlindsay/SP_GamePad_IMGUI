// Copyright 2026 Screen Play

using UnityEngine;

// Set Orientation to LANDSCAPE orientation
//                                               // Height: 4
//                                               // Width: 6

public class Pcode : MonoBehaviour
{

    private float joystickRadius;
    private Vector2 joystickCenter;

    private Texture2D blackTexture;
    private Texture2D whiteTexture;

    private int x1,y1,x2,y2;
    
    private int SPad_size;
    private int SPad_half;
    
    // Xa is X-All   // Xd is X-Draw  // Xt is X-Touch

    private int    SPad_L_orig_Xa;
    private int    SPad_L_orig_Yg;
    private int    SPad_L_orig_Yt;

    private int    SPad_L_cent_Xa;
    private int    SPad_L_cent_Yg;
    private int    SPad_L_cent_Yt;

    private int    SPad_R_orig_Xa;
    private int    SPad_R_orig_Yg;
    private int    SPad_R_orig_Yt;

    private int    SPad_R_cent_Xa;
    private int    SPad_R_cent_Yg;
    private int    SPad_R_cent_Yt;

    private int    SPad_R_topR_Xa;
    private int    SPad_R_topR_Yg;
    private int    SPad_R_topR_Yt;

    private int    SPad_R_botL_Xa;
    private int    SPad_R_botL_Yg;
    private int    SPad_R_botL_Yt;

//============================================================================================================
void Start()
{

    if (screen.height <= screen.width / 2)
    {
        SPad_size = screen.height
    } else {
        SPad_size = screen.height / 2;                // Size: 2
    }
    SPad_half = SPad_size / 2;                        // Half: 1

    SPad_L_orig_Xa = 0;                                // LorigXa: 0 = 0
    SPad_L_orig_Yg = screen.height - SPad_size;        // LorigYg: 4-2 = 2
    SPad_L_orig_Yt = screen.height - SPad_L_orig_Yg;   // LorigYt: 4-2 = 2

    SPad_L_cent_Xa = SPad_L_orig_Xa + SPad_half;       // LcentXa: 0+1 = 1
    SPad_L_cent_Yg = SPad_L_orig_Yg + SPad_half;       // LcentYg: 2+1 = 3
    SPad_L_cent_Yt = screen.height - SPad_L_cent_Yg;   // LcentYt: 4-3 = 1

    SPad_R_orig_Xa = screen.width - SPad_size;        // RorigXa: 6-2 = 4
    SPad_R_orig_Yg = screen.height - SPad_size;       // RorigYg: 4-2 = 2
    SPad_R_orig_Yt = screen.height - SPad_R_orig_Yg;  // RorigYt: 4-2 = 2

    SPad_R_cent_Xa = screen.width - SPad_half;        // RcentXa: 6-1 = 5
    SPad_R_cent_Yg = screen.height - SPad_half;       // RcentYg: 4-1 = 3
    SPad_R_cent_Yt = screen.height - SPad_R_cent_Yg;  // Rcentt: 4-3 = 1

    SPad_R_topR_Xa = SPad_R_orig_Xa + SPad_half;      // RtopXa: 4+1 = 5
    SPad_R_topR_Yg = SPad_R_orig_Yg;                  // RtopYg: 2 = 2
    SPad_R_topR_Yt = screen.height - SPad_R_topR_Yg;  // RtopYt: 4-2 = 2

    SPad_R_botL_Xa = SPad_R_orig_Xa;                  // RbotXa: 4 = 4
    SPad_R_botL_Yg = SPad_R_orig_Yg + SPad_half;      // RbotYg: 2+1 = 3
    SPad_R_botL_Yt = screen.height - SPad_R_botL_Yg;  // RbotYt: 4-3 = 1
    
    // Create solid color textures
    blackTexture = MakeTex(2, 2, Color.black);
    whiteTexture = MakeTex(2, 2, Color.white);

    joystickRadius = SPad_size / 2f;
    joystickCenter = new Vector2(SPad_L_cent_Xa, Screen.height / 2f);

} // END Start()

//============================================================================================================
void OnGUI()
{
    // RIGRT SPad - Box @ position
    GUI.color = Color.cyan;
    xi - SPad_R_orig_Xa;
    y1 = SPad_R_orig_Yg;
    x2 - SPad_R_orig_Xa + SPad_size;
    y2 = SPad_R_orig_Yg + SPad_size;
    GUI.Box(new Rect(x1, y1, x2, y2), "btns");

    // RIGHT Spad - Button TR - RED
    GUI.color = Color.red;
    xi - SPad_R_topR_Xa;
    y1 = SPad_R_topR_Yg;
    x2 - SPad_R_topR_Xa + SPad_half;
    y2 = SPad_R_topR_Yg + SPad_half;
    GUI.Box(new Rect(x1, y1, x2, y2), "TR");

    // RIGHT Spad - Button TL - BLUE
    GUI.color = Color.blue;
    xi - SPad_R_orig_Xa;
    y1 = SPad_R_orig_Yg;
    x2 - SPad_R_orig_Xa + SPad_half;
    y2 = SPad_R_orig_Yg + SPad_half;
    GUI.Box(new Rect(x1, y1, x2, y2), "TL");

    // RIGHT Spad - Button BR - GREEN
    GUI.color = Color.green;
    xi - SPad_R_cent_Xa;
    y1 = SPad_R_cent_Yg;
    x2 - SPad_R_cent_Xa + SPad_half;
    y2 = SPad_R_cent_Yg + SPad_half;
    GUI.Box(new Rect(x1, y1, x2, y2), "BR");

    // RIGHT Spad - Button BL - YELLOW
    GUI.color = Color.yellow;
    xi - SPad_R_botL_Xa;
    y1 = SPad_R_botL_Yg;
    x2 - SPad_R_botL_Xa + SPad_half;
    y2 = SPad_R_botL_Yg + SPad_half;
    GUI.Box(new Rect(x1, y1, x2, y2), "BL");

    // LEFT SPad - Box @ Position - CYAN
    GUI.color = Color.cyan;
    xi - SPad_L_orig_Xa;
    y1 = SPad_L_orig_Yg;
    x2 - SPad_L_orig_Xa + SPad_size;
    y2 = SPad_L_orig_Yg + SPad_size;
    GUI.Box(new Rect(x1, y1, x2, y2), "joy");

    // LEFT SPad - Circle filled - BLACK
    DrawFilledCircle(joystickCenter, joystickRadius, Color.black);

    // LEFT SPad - White Ring 5-wide - WHITE
    DrawCircle(screenCenter, joystickRadius-5f, whiteTexture, 5f);

} // END of OnGUI()

//============================================================================================================
// ADVANCED DRAWING UTILITY METHODS

    void DrawLine(Vector2 start, Vector2 end, Texture2D texture, float thickness)
    {
        Vector2 dir = end - start;
        float distance = dir.magnitude;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GUIUtility.RotateAroundPivot(angle, start);
        GUI.DrawTexture(new Rect(start.x, start.y - thickness / 2f, distance, thickness), texture);
        GUIUtility.RotateAroundPivot(-angle, start);
    }

    void DrawCircle(Vector2 center, float radius, Texture2D texture, float thickness)
    {
        int segments = 64;
        for (int i = 0; i < segments; i++)
        {
            float angle1 = (i / (float)segments) * 2f * Mathf.PI;
            float angle2 = ((i + 1) / (float)segments) * 2f * Mathf.PI;

            Vector2 p1 = center + new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * radius;
            Vector2 p2 = center + new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2)) * radius;

            DrawLine(p1, p2, texture, thickness);
        }
    }

    void DrawFilledCircle(Vector2 center, float radius, Color color)
    {
        Texture2D tex = MakeTex(2, 2, color);
        int segments = 32;

        for (int i = 0; i < segments; i++)
        {
            float angle1 = (i / (float)segments) * 2f * Mathf.PI;
            float angle2 = ((i + 1) / (float)segments) * 2f * Mathf.PI;

            Vector2 p1 = center;
            Vector2 p2 = center + new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * radius;
            Vector2 p3 = center + new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2)) * radius;

            DrawTriangle(p1, p2, p3, tex);
        }
    }

    void DrawTriangle(Vector2 p1, Vector2 p2, Vector2 p3, Texture2D texture)
    {
        Vector2 min = Vector2.Min(Vector2.Min(p1, p2), p3);
        Vector2 max = Vector2.Max(Vector2.Max(p1, p2), p3);

        GUI.DrawTexture(new Rect(min.x, min.y, max.x - min.x, max.y - min.y), texture);
    }

    Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }


//============================================================================================================
// INTERPRETING TOUCH AREAS

    Boolean Button_ANY(int Xt, int Yt)
    {
        Boolean result = false;
        if (Xt > SPad_R_orig_Xa ) && (Yt < SPad_R_orig_Yt ) 
        {
              result = true;
        }
        return result;
    } 

    Boolean Button_BR(int Xt, int Yt)
    {
        Boolean result = false;
        if (Xt > SPad_R_cent_Xa ) && (Yt < SPad_R_cent_Yt ) 
        {
              result = true;
        }
        return result;
    } 

}  // END of CLASS
