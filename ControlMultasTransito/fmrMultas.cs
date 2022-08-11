namespace ControlMultasTransito
{
    public partial class fmrMultas : Form
    {
        ListViewItem item;
        public fmrMultas()
        {
            InitializeComponent();
        }

        private void fmrMultas_Load(object sender, EventArgs e)
        {
            lblfecha.Text=DateTime.Today.Date.ToShortDateString();
            lblhoras.Text=DateTime.Now.ToShortTimeString();
        }

        private void btnreguistrar_Click(object sender, EventArgs e)
        {
            //Calcular datos
            string placa=txtplaca.Text;
            double velocidad= double.Parse(textvelocidad.Text);
            DateTime fecha= DateTime.Parse(lblfecha.Text);
            DateTime dateTime= DateTime.Parse(lblhoras.Text);

            //procesar informacion
            double multa = 0;
            if (velocidad <= 70)
                multa = 0;
            else if (velocidad > 70 && velocidad <= 90)
                multa = 120;
            else if (velocidad > 90 && velocidad <= 100)
                multa = 240;
            else if (velocidad > 100)
                multa = 350;

            //Imprimiendo resultados
            ListViewItem fila=new ListViewItem(placa);
            fila.SubItems.Add(lblfecha.Text);
            fila.SubItems.Add(lblhoras.Text);
            fila.SubItems.Add(velocidad.ToString("0.00"));
            fila.SubItems.Add(multa.ToString("C"));
            lvMultas.Items.Add(fila);

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Está seguro de salir?",
                                "Control de pago",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void lvMultas_MouseClick(object sender, MouseEventArgs e)
        {
           item = lvMultas.GetItemAt(e.X, e.Y);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(item != null)
            {
                lvMultas.Items.Remove(item);
                MessageBox.Show("Multa eliminada correctamente!!");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una multa de la lista..");
            }
        }
    }
}