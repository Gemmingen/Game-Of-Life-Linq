using GOL.Business;
using GOL.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using Timer = System.Windows.Forms.Timer;

namespace GOL.Forms
{
    public partial class Form1 : Form
    {
        private const int CELL_SIZE = 16;
        private int INTERVAL = 500; //Standart Wert für die Geschwindigkeit
        private int WIDTH = 50; //Bei Start des Forms werden die Dimensionen auf 50 gesetzt
        private int HEIGHT = 50; 

        private Timer _timer;
        private List<Cell> grid = new List<Cell>();
        private readonly IGameEngine _gameEngine;

        public Form1(IGameEngine gameEngine)
        {
            InitializeComponent();

            _gameEngine = gameEngine;
            _timer = new Timer
            {
                Interval = INTERVAL
            };
            _timer.Tick += Timer_Tick;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var WIDTH = (int)widthInput.Value;
            var HEIGHT = (int)heightInput.Value;
            
            grid.Clear();
            buttonPanel.Controls.Clear();

            BuildButtonGrid(WIDTH, HEIGHT); 
            DisableInputs();
        }

        private void startSim_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
                intervalInput.Enabled = true;
                buttonPanel.Enabled = true;
                startSim.Text = "Start Simulation";
            }
            else
            {
                var interval = (int)intervalInput.Value;    

                _timer.Interval = interval;
                _timer.Start();
                buttonPanel.Enabled = false;
                intervalInput.Enabled = false;
                startSim.Text = "Stop Simulation";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RunNextGeneration();
        }

        private void RunNextGeneration()
        {
            grid = ReadButtons();
            grid = _gameEngine.NextGeneration(grid, WIDTH, HEIGHT);
            WriteButtons();
        }
        private void BuildButtonGrid(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var cell = new Cell { X = x, Y = y, IsAlive = false };
                    grid.Add(cell);

                    Button b = new Button
                    {
                        Name = $"button_{x}_{y}",
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        BackColor = Color.White,
                        Location = new Point(x * CELL_SIZE, y * CELL_SIZE),
                        Tag = cell,
                        Margin = Padding.Empty,
                        Padding = Padding.Empty,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0 },
                        AutoSize = false,
                    };

                    b.Click += (s, e2) =>
                    {
                        var btn = (Button)s;
                        var c = (Cell)btn.Tag;
                        c.IsAlive = !c.IsAlive;
                        btn.BackColor = c.IsAlive ? Color.Black : Color.White;
                    };

                    buttonPanel.Controls.Add(b);
                }
            }
        }
        private void WriteButtons()
        {
            foreach (Control ctrl in buttonPanel.Controls)
            {
                if (ctrl is Button btn)
                {
                    var parts = btn.Name.Split('_');
                    int x = int.Parse(parts[1]);
                    int y = int.Parse(parts[2]);

                    var cell = grid.FirstOrDefault(c => c.X == x && c.Y == y);
                    btn.BackColor = (cell != null && cell.IsAlive) ? Color.Black : Color.White;
                }
            }
        }
        private List<Cell> ReadButtons()
        {
            var result = new List<Cell>();

            foreach (Control ctrl in buttonPanel.Controls)
            {
                if (ctrl is Button btn)
                {
                    var parts = btn.Name.Split('_');
                    int x = int.Parse(parts[1]);
                    int y = int.Parse(parts[2]);

                    var isAlive = btn.BackColor == Color.Black;

                    result.Add(new Cell
                    {
                        X = x,
                        Y = y,
                        IsAlive = isAlive
                    });
                }
            }

            return result;
        }

        private void resetAll_Click(object sender, EventArgs e)
        {
            grid.Clear();
            buttonPanel.Controls.Clear();
            startButton.Enabled = true;
            heightInput.Enabled = true;
            widthInput.Enabled = true;
            startSim.Enabled = false;
            intervalInput.Enabled = true;
            startSim.Text = "Start Simulation";
            buttonPanel.Enabled = true;
            _timer.Stop();
        }
        private void DisableInputs()
        {
            startButton.Enabled = false;
            heightInput.Enabled = false;
            widthInput.Enabled = false;
            startSim.Enabled = true;
        }

        private void SpawnShape(List<(int dx, int dy)> pattern)
        {
            foreach (var (dx, dy) in pattern)
            {
                int x = (int.Parse(widthInput.Text) / 2) + dx;
                int y = (int.Parse(heightInput.Text) / 2) + dy;

                // Finde die entsprechende Zelle im Grid
                var cell = grid.FirstOrDefault(c => c.X == x && c.Y == y);
                if (cell != null)
                {
                    cell.IsAlive = true;

                    // Finde auch den passenden Button und färbe ihn schwarz
                    var btn = buttonPanel.Controls.Find($"button_{x}_{y}", false).FirstOrDefault() as Button;
                    if (btn != null)
                    {
                        btn.BackColor = Color.Black;
                    }
                }
            }
        }

        private void gliderLabel_Click(object sender, EventArgs e)
        {
            var gliderPattern = new List<(int dx, int dy)>
            {
                          (1, 0),
                                  (2, 1),
                  (0, 2), (1, 2), (2, 2)
            };
            SpawnShape(gliderPattern);
        }

        private void spaceshipButton_Click(object sender, EventArgs e)
        {
            var lwssPattern = new List<(int dx, int dy)>
            {
                   (1, 0), (2, 0), (3, 0), (4, 0),
              (0, 1),                      (4, 1),
                                           (4, 2),
              (0, 3),              (3, 3),

            };
            SpawnShape(lwssPattern);
        }

        private void fpentoButton_Click(object sender, EventArgs e)
        {
            var fpentoPattern = new List<(int dx, int dy)>
            {
                    (1, 0), (2, 0),
            (0, 1), (1, 1),
                    (1, 2)
            };
            SpawnShape(fpentoPattern);
        }

        private void golLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void intervalSped_Click(object sender, EventArgs e)
        {

        }
    }
}
