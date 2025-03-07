using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quinelero.DTO;

namespace quinelero
{
    public partial class Form1 : Form
    {
        private List<NumeroDTO> numerosSeleccionados = new List<NumeroDTO>{ new NumeroDTO("0000",0),
            new NumeroDTO("01", 0), new NumeroDTO("02", 0), new NumeroDTO("03", 0), new NumeroDTO("04", 0), new NumeroDTO("05", 0),
            new NumeroDTO("06", 0), new NumeroDTO("07", 0), new NumeroDTO("08", 0), new NumeroDTO("09", 0), new NumeroDTO("10", 0),
            new NumeroDTO("11", 0), new NumeroDTO("12", 0), new NumeroDTO("13", 0), new NumeroDTO("14", 0), new NumeroDTO("15", 0),
            new NumeroDTO("16", 0), new NumeroDTO("17", 0), new NumeroDTO("18", 0), new NumeroDTO("19", 0), new NumeroDTO("20", 0),
            new NumeroDTO("21", 0), new NumeroDTO("22", 0), new NumeroDTO("23", 0), new NumeroDTO("24", 0), new NumeroDTO("25", 0),
            new NumeroDTO("26", 0), new NumeroDTO("27", 0), new NumeroDTO("28", 0), new NumeroDTO("29", 0), new NumeroDTO("30", 0),
            new NumeroDTO("31", 0), new NumeroDTO("32", 0), new NumeroDTO("33", 0), new NumeroDTO("34", 0), new NumeroDTO("35", 0),
            new NumeroDTO("36", 0), new NumeroDTO("37", 0), new NumeroDTO("38", 0), new NumeroDTO("39", 0), new NumeroDTO("40", 0),
            new NumeroDTO("41", 0), new NumeroDTO("42", 0), new NumeroDTO("43", 0), new NumeroDTO("44", 0), new NumeroDTO("45", 0),
            new NumeroDTO("46", 0), new NumeroDTO("47", 0), new NumeroDTO("48", 0), new NumeroDTO("49", 0), new NumeroDTO("50", 0),
            new NumeroDTO("51", 0), new NumeroDTO("52", 0), new NumeroDTO("53", 0), new NumeroDTO("54", 0), new NumeroDTO("55", 0),
            new NumeroDTO("56", 0), new NumeroDTO("57", 0), new NumeroDTO("58", 0), new NumeroDTO("59", 0), new NumeroDTO("60", 0),
            new NumeroDTO("61", 0), new NumeroDTO("62", 0), new NumeroDTO("63", 0), new NumeroDTO("64", 0), new NumeroDTO("65", 0),
            new NumeroDTO("66", 0), new NumeroDTO("67", 0), new NumeroDTO("68", 0), new NumeroDTO("69", 0), new NumeroDTO("70", 0),
            new NumeroDTO("71", 0), new NumeroDTO("72", 0), new NumeroDTO("73", 0), new NumeroDTO("74", 0), new NumeroDTO("75", 0),
            new NumeroDTO("76", 0), new NumeroDTO("77", 0), new NumeroDTO("78", 0), new NumeroDTO("79", 0), new NumeroDTO("80", 0),
            new NumeroDTO("81", 0), new NumeroDTO("82", 0), new NumeroDTO("83", 0), new NumeroDTO("84", 0), new NumeroDTO("85", 0),
            new NumeroDTO("86", 0), new NumeroDTO("87", 0), new NumeroDTO("88", 0), new NumeroDTO("89", 0), new NumeroDTO("90", 0),
            new NumeroDTO("86", 0), new NumeroDTO("87", 0), new NumeroDTO("88", 0), new NumeroDTO("89", 0), new NumeroDTO("90", 0),
            new NumeroDTO("91", 0), new NumeroDTO("92", 0), new NumeroDTO("93", 0), new NumeroDTO("94", 0), new NumeroDTO("95", 0),
            new NumeroDTO("96", 0), new NumeroDTO("97", 0), new NumeroDTO("98", 0), new NumeroDTO("99", 0), new NumeroDTO("00", 0),
        };

        private int pares = 0;
        private int impares = 0;
        private int primerGrupo = 0;
        private int segundoGrupo = 0;
        private int tercerGrupo = 0;
        private List<NumeroDTO> primeros15ALaCabeza = new List<NumeroDTO>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox101_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox101.Text.Length > 1)
            {
                this.button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numeroIngresado = this.textBox101.Text;
            if (int.Parse(this.label2.Text) > 0)
            {
                this.actualizarNumerosSeleccionados(sender, e, numeroIngresado);
                this.actualizarTablero(sender, e, numeroIngresado);
                this.actualizarContadores(sender, e);
                this.posicionarseEnTextBox(sender, e);
            }
            if (int.Parse(this.label2.Text) == 0)
            {
                this.actualizarTableroFinal(sender, e, numeroIngresado);
            }
        }

        private void actualizarNumerosSeleccionados(object sender, EventArgs e, string numeroIngresado)
        {
            foreach (NumeroDTO ns in numerosSeleccionados)
            {
                if (ns.Numero == numeroIngresado)
                {
                    ns.VecesSeleccionado += 1;
                    if (primeros15ALaCabeza.Count < 15)
                    {
                        primeros15ALaCabeza.Add(ns);
                    }
                }
            }
           
        }

        private void actualizarContadores(object sender, EventArgs e)
        {
            int contador = int.Parse(this.label2.Text) - 1;
            this.label2.Text = contador.ToString();
            this.label9.Text = primerGrupo.ToString();
            this.label11.Text = segundoGrupo.ToString();
            this.label13.Text = tercerGrupo.ToString();
            this.label4.Text = pares.ToString();
            this.label7.Text = impares.ToString();
        }

        public Boolean estaEnLosPrimeros15(string numeroIngresado)
        {
            foreach(NumeroDTO ns in primeros15ALaCabeza)
            {
                if (ns.Numero == numeroIngresado)
                {
                    return true;
                }
            }
            return false;
        }


        private void actualizarTablero(object sender, EventArgs e, string numeroIngresado)
        {
            if (numeroIngresado == "01")
            {
                this.textBox1.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;
            }
            if (numeroIngresado == "02")
            {
                this.textBox2.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "03")
            {
                this.textBox3.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;

            }
            if (numeroIngresado == "04")
            {
                this.textBox4.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "05")
            {
                this.textBox5.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "06")
            {
                this.textBox6.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "07")
            {
                this.textBox7.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "08")
            {
                this.textBox8.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "09")
            {
                this.textBox9.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "10")
            {
                this.textBox10.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "11")
            {
                this.textBox11.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "12")
            {
                this.textBox12.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "13")
            {
                this.textBox13.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "14")
            {
                this.textBox14.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "15")
            {
                this.textBox15.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "16")
            {
                this.textBox16.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "17")
            {
                this.textBox17.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "18")
            {
                this.textBox18.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "19")
            {
                this.textBox19.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }

            if (numeroIngresado == "20")
            {
                this.textBox20.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "21")
            {
                this.textBox21.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "22")
            {
                this.textBox22.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "23")
            {
                this.textBox23.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "24")
            {
                this.textBox24.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "25")
            {
                this.textBox25.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "26")
            {
                this.textBox26.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "27")
            {
                this.textBox27.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "28")
            {
                this.textBox28.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "29")
            {
                this.textBox29.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "30")
            {
                this.textBox30.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "31")
            {
                this.textBox31.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "32")
            {
                this.textBox32.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "33")
            {
                this.textBox33.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.primerGrupo += 1;
                this.impares += 1;


            }
            if (numeroIngresado == "34")
            {
                this.textBox34.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "35")
            {
                this.textBox35.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "36")
            {
                this.textBox36.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "37")
            {
                this.textBox37.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "38")
            {
                this.textBox38.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "39")
            {
                this.textBox39.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "40")
            {
                this.textBox40.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "41")
            {
                this.textBox41.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "42")
            {
                this.textBox42.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "43")
            {
                this.textBox43.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "44")
            {
                this.textBox44.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "45")
            {
                this.textBox45.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "46")
            {
                this.textBox46.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "47")
            {
                this.textBox47.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "48")
            {
                this.textBox48.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "49")
            {
                this.textBox49.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "50")
            {
                this.textBox50.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "51")
            {
                this.textBox51.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "52")
            {
                this.textBox52.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "53")
            {
                this.textBox53.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "54")
            {
                this.textBox54.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "55")
            {
                this.textBox55.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "56")
            {
                this.textBox56.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "57")
            {
                this.textBox57.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "58")
            {
                this.textBox58.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "59")
            {
                this.textBox59.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "60")
            {
                this.textBox60.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "61")
            {
                this.textBox61.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "62")
            {
                this.textBox62.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "63")
            {
                this.textBox63.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "64")
            {
                this.textBox64.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "65")
            {
                this.textBox65.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "66")
            {
                this.textBox66.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.segundoGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "67")
            {
                this.textBox67.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
            }
            if (numeroIngresado == "68")
            {
                this.textBox68.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "69")
            {
                this.textBox69.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "70")
            {
                this.textBox70.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "71")
            {
                this.textBox71.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "72")
            {
                this.textBox72.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "73")
            {
                this.textBox73.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "74")
            {
                this.textBox74.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "75")
            {
                this.textBox75.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "76")
            {
                this.textBox76.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "77")
            {
                this.textBox77.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "78")
            {
                this.textBox78.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "79")
            {
                this.textBox79.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "80")
            {
                this.textBox80.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "81")
            {
                this.textBox81.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "82")
            {
                this.textBox82.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "83")
            {
                this.textBox83.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "84")
            {
                this.textBox84.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "85")
            {
                this.textBox85.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "86")
            {
                this.textBox86.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "87")
            {
                this.textBox87.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "88")
            {
                this.textBox88.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "89")
            {
                this.textBox89.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "90")
            {
                this.textBox90.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "91")
            {
                this.textBox91.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "92")
            {
                this.textBox92.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "93")
            {
                this.textBox93.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "94")
            {
                this.textBox94.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "95")
            {
                this.textBox95.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "96")
            {
                this.textBox96.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "97")
            {
                this.textBox97.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "98")
            {
                this.textBox98.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.pares += 1;

            }
            if (numeroIngresado == "99")
            {
                this.textBox99.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.tercerGrupo += 1;
                this.impares += 1;

            }
            if (numeroIngresado == "00")
            {
                this.textBox100.BackColor = estaEnLosPrimeros15(numeroIngresado) ? Color.Yellow : Color.Purple;
                this.pares += 1;
            }
        }

        private void posicionarseEnTextBox(object sender, EventArgs e)
        {
            this.textBox101.Clear();
            this.textBox101.Focus();
        }


        private void actualizarTableroFinal(object sender, EventArgs e, string numeroIngresado)
        {
            if ((primerGrupo > segundoGrupo && primerGrupo > tercerGrupo) || 
                (primerGrupo == segundoGrupo && primerGrupo > tercerGrupo) ||
                (primerGrupo == tercerGrupo && primerGrupo > segundoGrupo))
            {
                this.textBox2.BackColor = Color.Red;
                this.textBox4.BackColor = Color.Red;
                this.textBox6.BackColor = Color.Red;
                this.textBox8.BackColor = Color.Red;
                this.textBox10.BackColor = Color.Red;
                this.textBox11.BackColor = Color.Red;
                this.textBox13.BackColor = Color.Red;
                this.textBox15.BackColor = Color.Red;
                this.textBox17.BackColor = Color.Red;
                this.textBox19.BackColor = Color.Red;
                this.textBox22.BackColor = Color.Red;
                this.textBox24.BackColor = Color.Red;
                this.textBox26.BackColor = Color.Red;
                this.textBox28.BackColor = Color.Red;
                this.textBox30.BackColor = Color.Red;
                this.textBox31.BackColor = Color.Red;
                this.textBox33.BackColor = Color.Red;
            }

            if ((segundoGrupo > primerGrupo && segundoGrupo > tercerGrupo) ||
                (segundoGrupo == primerGrupo && segundoGrupo > tercerGrupo) ||
                (segundoGrupo == tercerGrupo && segundoGrupo > primerGrupo))
            {
                this.textBox34.BackColor = Color.Red;
                this.textBox37.BackColor = Color.Red;
                this.textBox39.BackColor = Color.Red;
                this.textBox42.BackColor = Color.Red;
                this.textBox44.BackColor = Color.Red;
                this.textBox46.BackColor = Color.Red;
                this.textBox48.BackColor = Color.Red;
                this.textBox50.BackColor = Color.Red;
                this.textBox51.BackColor = Color.Red;
                this.textBox53.BackColor = Color.Red;
                this.textBox55.BackColor = Color.Red;
                this.textBox57.BackColor = Color.Red;
                this.textBox59.BackColor = Color.Red;
                this.textBox62.BackColor = Color.Red;
                this.textBox64.BackColor = Color.Red;
                this.textBox66.BackColor = Color.Red;
            }

            if ((tercerGrupo > primerGrupo && tercerGrupo > segundoGrupo) ||
                (tercerGrupo == primerGrupo && tercerGrupo > segundoGrupo) ||
                (tercerGrupo == segundoGrupo && tercerGrupo > primerGrupo))
            {
                this.textBox68.BackColor = Color.Red;
                this.textBox70.BackColor = Color.Red;
                this.textBox71.BackColor = Color.Red;
                this.textBox73.BackColor = Color.Red;
                this.textBox75.BackColor = Color.Red;
                this.textBox77.BackColor = Color.Red;
                this.textBox79.BackColor = Color.Red;
                this.textBox82.BackColor = Color.Red;
                this.textBox84.BackColor = Color.Red;
                this.textBox86.BackColor = Color.Red;
                this.textBox88.BackColor = Color.Red;
                this.textBox90.BackColor = Color.Red;
                this.textBox91.BackColor = Color.Red;
                this.textBox93.BackColor = Color.Red;
                this.textBox95.BackColor = Color.Red;
                this.textBox97.BackColor = Color.Red;
                this.textBox99.BackColor = Color.Red;

            }
        }
    }
}
