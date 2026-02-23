
// Set Orientation to LANDSCAPE orientation
//                                               // Height: 4
//                                               // Width: 6

if (screen.height <= screen.width / 2)
{
    SPad.size = screen.height
} else {
    SPad.size = screen.height / 2;                // Size: 2
}
SPad.half = SPad.size / 2;                        // Half: 1

// Xa is X-All   // Xd is X-Draw  // Xt is X-Touch

SPad_L_orig.Xa = 0;                                // LorigXa: 0 = 0
SPad_L_orig.Yg = screen.height - SPad.size;        // LorigYg: 4-2 = 2
SPad_L_orig.Yt = screen.height - SPad_L_orig.Yg;   // LorigYt: 4-2 = 2

SPad_L_cent.Xa = SPad_L_orig.Xa + SPad.half;       // LcentXa: 0+1 = 1
SPad_L_cent.Yg = SPad_L_orig.Yg + SPad.half;       // LcentYg: 2+1 = 3
SPad_L_cent.Yt = screen.height - SPad_L_cent.Yg;   // LcentYt: 4-3 = 1

SPad_R_orig.Xa = screen.width - SPad.size;        // RorigXa: 6-2 = 4
SPad_R_orig.Yg = screen.height - SPad.size;       // RorigYg: 4-2 = 2
SPad_R_orig.Yt = screen.height - SPad_R_orig.Yg;  // RorigYt: 4-2 = 2

SPad_R_cent.Xa = screen.width - SPad.half;        // RcentXa: 6-1 = 5
SPad_R_cent.Yg = screen.height - SPad.half;       // RcentYg: 4-1 = 3
SPad_R_cent.Yt = screen.height - SPad_R_cent.Yg;  // Rcentt: 4-3 = 1

SPad_R_topR.Xa = SPad_R_orig.Xa + SPad.half;      // RtopXa: 4+1 = 5
SPad_R_topR.Yg = SPad_R_orig.Yg;                  // RtopYg: 2 = 2
SPad_R_topR.Yt = screen.height - SPad_R_topR.Yg;  // RtopYt: 4-2 = 2

SPad_R_botL.Xa = SPad_R_orig.Xa;                  // RbotXa: 4 = 4
SPad_R_botL.Yg = SPad_R_orig.Yg + SPad.half;      // RbotYg: 2+1 = 3
SPad_R_botL.Yt = screen.height - SPad_R_botL.Yg;  // RbotYt: 4-3 = 1

void OnGUI()
{
    // RIGRT SPad - Box @ position
    GUI.color = Color.cyan;
    xi - SPad_R_orig.Xa;
    y1 = SPad_R_orig.Yg;
    x2 - SPad_R_orig.Xa + SPad.size;
    y2 = SPad_R_orig.Yg + SPad.size;
    GUI.Box(new Rect(x1, y1, x2, y2), "btns");

    // RIGHT Spad - Button TR - RED
    GUI.color = Color.red;
    xi - SPad_R_topR.Xa;
    y1 = SPad_R_topR.Yg;
    x2 - SPad_R_topR.Xa + SPad.half;
    y2 = SPad_R_topR.Yg + SPad.half;
    GUI.Box(new Rect(x1, y1, x2, y2), "TR");

    // RIGHT Spad - Button TL - BLUE
    GUI.color = Color.blue;
    xi - SPad_R_orig.Xa;
    y1 = SPad_R_orig.Yg;
    x2 - SPad_R_orig.Xa + SPad.half;
    y2 = SPad_R_orig.Yg + SPad.half;
    GUI.Box(new Rect(x1, y1, x2, y2), "TL");

    // RIGHT Spad - Button BR - GREEN
    GUI.color = Color.green;
    xi - SPad_R_cent.Xa;
    y1 = SPad_R_cent.Yg;
    x2 - SPad_R_cent.Xa + SPad.half;
    y2 = SPad_R_cent.Yg + SPad.half;
    GUI.Box(new Rect(x1, y1, x2, y2), "BR");

    // RIGHT Spad - Button BL - YELLOW
    GUI.color = Color.yellow;
    xi - SPad_R_botL.Xa;
    y1 = SPad_R_botL.Yg;
    x2 - SPad_R_botL.Xa + SPad.half;
    y2 = SPad_R_botL.Yg + SPad.half;
    GUI.Box(new Rect(x1, y1, x2, y2), "BL");

    // LEFT SPad - Box @ Position
    GUI.color = Color.white;
    xi - SPad_L_orig.Xa;
    y1 = SPad_L_orig.Yg;
    x2 - SPad_L_orig.Xa + SPad.size;
    y2 = SPad_L_orig.Yg + SPad.size;
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

