// Copyright 2026 Screen Play

// Set Orientation to LANDSCAPE orientation
//                                               // Height: 4
//                                               // Width: 6

void Start()
{

    private int x1,y1,x2,y2;
    
    private int SPad_size;
    private int SPad_half;
    
    if (screen.height <= screen.width / 2)
    {
        SPad_size = screen.height
    } else {
        SPad_size = screen.height / 2;                // Size: 2
    }
    SPad_half = SPad_size / 2;                        // Half: 1

    // Xa is X-All   // Xd is X-Draw  // Xt is X-Touch

    private int    SPad_L_orig_Xa = 0;                                // LorigXa: 0 = 0
    private int    SPad_L_orig_Yg = screen.height - SPad_size;        // LorigYg: 4-2 = 2
    private int    SPad_L_orig_Yt = screen.height - SPad_L_orig_Yg;   // LorigYt: 4-2 = 2

    private int    SPad_L_cent_Xa = SPad_L_orig_Xa + SPad_half;       // LcentXa: 0+1 = 1
    private int    SPad_L_cent_Yg = SPad_L_orig_Yg + SPad_half;       // LcentYg: 2+1 = 3
    private int    SPad_L_cent_Yt = screen.height - SPad_L_cent_Yg;   // LcentYt: 4-3 = 1

    private int    SPad_R_orig_Xa = screen.width - SPad_size;        // RorigXa: 6-2 = 4
    private int    SPad_R_orig_Yg = screen.height - SPad_size;       // RorigYg: 4-2 = 2
    private int    SPad_R_orig_Yt = screen.height - SPad_R_orig_Yg;  // RorigYt: 4-2 = 2

    private int    SPad_R_cent_Xa = screen.width - SPad_half;        // RcentXa: 6-1 = 5
    private int    SPad_R_cent_Yg = screen.height - SPad_half;       // RcentYg: 4-1 = 3
    private int    SPad_R_cent_Yt = screen.height - SPad_R_cent_Yg;  // Rcentt: 4-3 = 1

    private int    SPad_R_topR_Xa = SPad_R_orig_Xa + SPad_half;      // RtopXa: 4+1 = 5
    private int    SPad_R_topR_Yg = SPad_R_orig_Yg;                  // RtopYg: 2 = 2
    private int    SPad_R_topR_Yt = screen.height - SPad_R_topR_Yg;  // RtopYt: 4-2 = 2

    private int    SPad_R_botL_Xa = SPad_R_orig_Xa;                  // RbotXa: 4 = 4
    private int    SPad_R_botL_Yg = SPad_R_orig_Yg + SPad_half;      // RbotYg: 2+1 = 3
    private int    SPad_R_botL_Yt = screen.height - SPad_R_botL_Yg;  // RbotYt: 4-3 = 1

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

    // LEFT SPad - Box @ Position
    GUI.color = Color.white;
    xi - SPad_L_orig_Xa;
    y1 = SPad_L_orig_Yg;
    x2 - SPad_L_orig_Xa + SPad_size;
    y2 = SPad_L_orig_Yg + SPad_size;
    GUI.Box(new Rect(x1, y1, x2, y2), "joy");


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
}

