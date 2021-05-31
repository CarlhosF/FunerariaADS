﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica_De_Negocios.Service;


namespace FunerariaPrototipo.View
{

    public partial class ClientesGestor : Form
    {
        ClientesServices clienteservice;
        //ViewModel.ClienteViewModel clientesviewmodel;        
        
        public ClientesGestor()
        {
            InitializeComponent();
            clienteservice = new ClientesServices();
            //clientesviewmodel = new ViewModel.ClienteViewModel();
           
        }

        private void ClientesGestor_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos() 
        {
            //clientesviewmodel._clientes = (List<Clientes_Modulo.CLS.Clientes>)clienteservice.getAll();
            dataGridView1.DataSource = CLSConvert.ToDataTable<Clientes_Modulo.CLS.Clientes>((List<Clientes_Modulo.CLS.Clientes>)clienteservice.getAll());
        }
       
    }
}
