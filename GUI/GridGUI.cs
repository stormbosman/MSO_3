using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace mso_2;

public partial class GridGUI : UserControl
{
    int Columns;
    int Rows;
    ClientGUI clientGUI;

    private Bitmap playerSprite;
    private Bitmap goalSprite;

    public GridGUI(ClientGUI ClientGUI)
    {
        InitializeComponent();
        DoubleBuffered = true;
        ResizeRedraw = true;

        clientGUI = ClientGUI;

        playerSprite = new Bitmap(@"..\..\..\player.png");
        goalSprite = new Bitmap(@"..\..\..\goal.png");

        this.BackColor = Color.White;

        Vector2 gridSize = ClientGUI.GetGridSize();
        Columns = ((int)gridSize.X);
        Rows = ((int)gridSize.Y);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (Columns <= 0 || Rows <= 0) return;

        int width = ClientSize.Width - 1;
        int height = ClientSize.Height - 1;

        float cellWidth = (float)width / Columns;
        float cellHeight = (float)height / Rows;

        float size = Math.Min(cellHeight, cellWidth);


        DrawGrid(e.Graphics, size);
        DrawPath(e.Graphics, size);
        DrawPlayer(e.Graphics, size);
        DrawGoal(e.Graphics, size);
    }

    private void DrawGrid(Graphics g, float size)
    {
        using var pen = new Pen(Color.Black, 1);

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                float x = c * size;
                float y = r * size;
                g.DrawRectangle(pen, x, y, size, size);

                if (clientGUI.CheckGridOccupied(c, r))
                    g.FillRectangle(new SolidBrush(Color.OrangeRed), x + 1, y + 1, size - 2, size - 2);
            }
        }
    }

    private void DrawPath(Graphics g, float size)
    {
        List<Vector2> playerLastPositions = clientGUI.GetPlayerLastPositions();

        using var pen = new Pen(Color.Black, 1);

        for (int i = 0; i < playerLastPositions.Count - 1; i++)
        {
            Console.WriteLine(i);
            Vector2 prev = playerLastPositions[i] + new Vector2(0.5f, 0.5f);
            Vector2 next = playerLastPositions[i + 1] + new Vector2(0.5f, 0.5f);
            g.DrawLine(pen, prev.X * size, prev.Y * size, next.X * size, next.Y * size);
        }
    }
    
    private void DrawPlayer(Graphics g, float size)
    {
        Vector2 playerPos = clientGUI.GetPlayerPos();
        g.DrawImage(playerSprite, new RectangleF(playerPos.X * size, playerPos.Y * size, size, size));
    }

    private void DrawGoal(Graphics g, float size)
    {
        Vector2 gridPos = clientGUI.GetGridGoalPos();
        g.DrawImage(goalSprite, new RectangleF(gridPos.X * size, gridPos.Y * size, size, size));
    }
}
