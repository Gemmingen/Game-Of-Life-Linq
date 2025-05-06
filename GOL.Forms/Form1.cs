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

            if (!int.TryParse(widthInput.Text, out int width) || !int.TryParse(heightInput.Text, out int height))
            {
                MessageBox.Show("Bitte nur Zahlen eingeben!");
                return;
            }
            if (width > 50 || width < 0 || height > 50 || height < 0)//Bei Spielfeld initialisierung von über 50 kommt es zu einem Fehler
            {
                MessageBox.Show("Die Dimensionen müssen zwischen 0 und 50 liegen! Bitte ändern Sie die Eingaben und versuchen Sie es erneut.");
                return;
            }

            grid.Clear();
            buttonPanel.Controls.Clear();

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
                        Tag = cell
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

            startButton.Enabled = false;
            heightInput.Enabled = false;
            widthInput.Enabled = false;
            startSim.Enabled = true;
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
                if (!int.TryParse(intervalInput.Text, out int interval))
                {
                    MessageBox.Show("Bitte nur Zahlen eingeben!");
                    return;
                }
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
            if (!int.TryParse(widthInput.Text, out int width) || !int.TryParse(heightInput.Text, out int height))
                return;
            grid = ReadButtons();
            grid = _gameEngine.NextGeneration(grid, width, height);
            WriteButtons();
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

        private void intervalSped_Click(object sender, EventArgs e)
        {

        }

        private void BuildShape(List<(int dx, int dy)> pattern)
        {
            foreach (var (dx, dy) in pattern)
            {
                int x = (int.Parse(widthInput.Text)/2) + dx;
                int y = (int.Parse(heightInput.Text)/2) + dy;

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
            BuildShape(gliderPattern);
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
            BuildShape(lwssPattern);
        }

        private void fpentoButton_Click(object sender, EventArgs e)
        {
            var fpentoPattern = new List<(int dx, int dy)> 
            {
                    (1, 0), (2, 0), 
            (0, 1), (1, 1),
                    (1, 2)
            };
            BuildShape(fpentoPattern);
        }
    }
}
