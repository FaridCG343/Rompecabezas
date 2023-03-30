namespace Rompecabezas
{
    
    public partial class frmcgfRompecabezas : Form
    {
        private List<List<Button>> numeros = new();
        private Dictionary<Button, int[]> coordenadas = new();
        private int movimientos = 0;
        public frmcgfRompecabezas()
        {
            InitializeComponent();
            get_buttons();
            get_coordenadas();
            set_values();
        }

        private void btncgfN_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int[] coordenadas_boton = coordenadas[button];
            int x = coordenadas_boton[1];
            int y = coordenadas_boton[0];
            if (x > 0)
            {
                if (!numeros[y][x - 1].Visible)
                {
                    movimientos++;
                    numeros[y][x - 1].Visible = true;
                    numeros[y][x - 1].Text = button.Text;
                    button.Visible = false;
                }
            }
            if (x < 3)
            {
                if (!numeros[y][x + 1].Visible)
                {
                    movimientos++;
                    numeros[y][x + 1].Visible = true;
                    numeros[y][x + 1].Text = button.Text;
                    button.Visible = false;
                }
            }
            if (y > 0)
            {
                if (!numeros[y - 1][x].Visible)
                {
                    movimientos++;
                    numeros[y - 1][x].Visible = true;
                    numeros[y - 1][x].Text = button.Text;
                    button.Visible = false;
                }
            }
            if (y < 3)
            {
                if (!numeros[y + 1][x].Visible)
                {
                    movimientos++;
                    numeros[y + 1][x].Visible = true;
                    numeros[y + 1][x].Text = button.Text;
                    button.Visible = false;
                }
            }
            lblcgfMov.Text = "Movimientos: " + movimientos;
            if (check())
            {
                string res = MessageBox.Show("Ganaste en "+movimientos+" movimientos, \nDeseas continuar?", "Felicidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if(res == "No")
                {
                    Application.Exit();
                }
                movimientos = 0;
                set_values();
            }
        }

        public void get_buttons()
        {
            numeros = new List<List<Button>>()
            {
                new List<Button>() { btncgfN1, btncgfN2, btncgfN3, btncgfN4 },
                new List<Button>() { btncgfN5, btncgfN6, btncgfN7, btncgfN8 },
                new List<Button>() { btncgfN9, btncgfN10, btncgfN11, btncgfN12 },
                new List<Button>() { btncgfN13, btncgfN14, btncgfN15, btncgfN16 }
            };
        }

        public void get_coordenadas()
        {
            int x = 0;
            int y = 0;
            foreach(List<Button> list in numeros)
            {
                foreach(Button button in list)
                {
                    coordenadas.Add(button, new int[] { y, x });
                    x++;
                }
                x = 0;
                y++;
            }
        }

        private void set_values()
        {
            bool band;
            Random random = new();
            List<int> numeros_creados = new();
            int numero;
            foreach(List<Button> list in numeros)
            {
                foreach(Button button in list)
                {
                    band = true;
                    while (band)
                    {
                        numero = random.Next(0, 16);
                        if (!numeros_creados.Contains(numero))
                        {
                            band = false;
                            button.Text = numero.ToString();
                            numeros_creados.Add(numero);
                            button.Visible = true;
                            if(numero == 0)
                            {
                                button.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            movimientos = 0;
            lblcgfMov.Text = "Movimientos: 0";
            set_values();
        }

        private bool check()
        {
            int[] coor;
            int x, y, pos;
            foreach(List<Button> list in numeros)
            {
                foreach(Button button in list)
                {
                    coor = coordenadas[button];
                    x = coor[1];
                    y = coor[0];
                    pos = (y * 4) + x + 1;
                    //MessageBox.Show(button.Text + " " + pos + " " + button.Name);
                    if (button.Text != pos.ToString() && pos != 16)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void btnSalir_Click(object sender, EventArgs e)
        {
            string res = MessageBox.Show("¿Deseas salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (res == "Yes")
            {
                Application.Exit();
            }
        }

        private void btncgfFacil_Click(object sender, EventArgs e)
        {
            movimientos = 0;
            lblcgfMov.Text = "Movimientos: 0";
            int numero = 1;
            foreach (List<Button> list in numeros)
            {
                foreach (Button button in list)
                {
                    
                    
                    button.Text = numero.ToString();
                    button.Visible = true;
                    if (numero == 15)
                    {
                        button.Text = "0";
                        button.Visible = false;
                    }
                    if (numero == 16)
                    {
                        button.Text = "15";
                    }
                    numero++;
                    
                }
            }
        }
    }
}