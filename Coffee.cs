using Business;
using Business.Items;
using Business.People;
using Business.Performance;
using Domain;
using Domain.DTO;
using Services.Datos.Contracts;
using Services.Domain.Composite;
using Services.Facade;
using Services.Security.Domain.Exceptions;
using Services.Security.Facade;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UI.Services;


namespace WindowsFormsApp1
{
    /// <summary>
    /// Formulario principal del Sistema.
    /// </summary>
    public partial class Coffee : Form, ILanguageObserver
    {
        private Usuario userControl;
        private LoginForm logForm;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Coffee"/>.
        /// Este constructor configura el formulario y realiza las acciones de inicialización necesarias, 
        /// como la actualización de combos de productos y pedidos, e inicia la actualización automática de tareas.
        /// </summary>
        /// <param name="user">El usuario que accede al sistema.</param>
        /// <param name="form">El formulario de inicio de sesión.</param>
        public Coffee(Usuario user, LoginForm form)
        {
            InitializeComponent();
            userControl = user;
            logForm = form;
            
            ActualiarCombosProduPedi();
            ActualizarDataPedido();

            tareaLogic.IniciarActualizacionAutomatica();

            LanguageService.Subscribe(this);
            UpdateLanguage();
        }

        /// <summary>
        /// Actualiza el idioma del formulario.
        /// </summary>
        public void UpdateLanguage()
        {
            LanguageService.TranslateForm(this);
        }

        /// <summary>
        /// Evento que se dispara al cargar el formulario.
        /// </summary>
        private void Coffee_Load(object sender, EventArgs e)
        {
            List<Control> controls = new List<Control> {tabPagePedidos, tabPageTareas, tabPageClientes, tabPageDesempeño, tabPageEmpleados, tabProductos, tabAdmin,
            btnMenosProdu, btnMasProdu, btnEliminarProduDetalles, txtCantProdu, groupManejoPedidos, groupCancelarPedido, groupProcesarPedido, groupProcesarTarea, 
            groupCrearTarea, btnEliminarCliente, groupCrearBono, tabBitacora};

            AccesoService.AplicarAcceso(userControl, controls);
        }

        /// <summary>
        /// Evento que se dispara al cerrar el formulario.
        /// </summary>
        private void Coffee_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageService.Unsubscribe(this);

            logForm.Close();
        }


        private void Coffee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)  // Cambia F1 por la tecla que desees
            {
                // Asegúrate de usar la ruta correcta hacia tu archivo de ayuda
                string helpFilePath = Path.Combine(Application.StartupPath, "Help", "Manual de Ayuda.chm");

                if (File.Exists(helpFilePath))
                {
                    Process.Start(helpFilePath);
                }
                else
                {
                    MessageBox.Show("Algo salio mal");
                }
            }
        }

        #region ManejadorCliente

        ClienteLogic clienteLogic = ClienteLogic.GetInstance();

        /// <summary>
        /// Actualiza los grids de clientes con la información más reciente.
        /// </summary>
        public void ActualizarGridsCliente()
        {
            try
            {
                var dtos = clienteLogic.GetClientes();
                dataALLClientes.DataSource = null;
                dataALLClientes.DataSource = dtos;
                dataALLClientes.Columns["Id"].Visible = false;
                
            }
            catch(BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para actualizar los datos de clientes.
        /// </summary>
        private void btnActDataClientes_Click(object sender, EventArgs e)
        {
            ActualizarGridsCliente();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para registrar un nuevo cliente.
        /// </summary>
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new CLIENTE();

                client.NOMBRE = txtNameRegCliente.Text;
                client.APELLIDO = txtApellidoRegCliente.Text;
                client.DNI = Convert.ToInt32(txtDNIRegCliente.Text);
                client.ESTADO = true;

                clienteLogic.Add(client);

                txtNameRegCliente.Clear();
                txtApellidoRegCliente.Clear();
                txtDNIRegCliente.Clear();

                ActualizarGridsCliente();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para buscar un cliente existente.
        /// </summary>
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = clienteLogic.GetByDNI(Convert.ToInt32(txtDNIBuscarCliente.Text));

                dataOneCliente.DataSource = null;
                dataOneCliente.DataSource = cliente;
                dataOneCliente.Columns["Id"].Visible = false;

                txtDNIBuscarCliente.Clear();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para deshabilitar/habilitar un cliente.
        /// </summary>
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Parse(dataALLClientes.SelectedRows[0].Cells["Id"].Value.ToString());
                var cliente = clienteLogic.GetById(id);

                if (cliente.ESTADO == true)
                {
                    cliente.ESTADO = false;
                }
                else if (cliente.ESTADO == false)
                {
                    cliente.ESTADO = true;
                }

                clienteLogic.Update(cliente);

                ActualizarGridsCliente();

            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en la fila del dataGridView que contiene los clientes.
        /// </summary>
        private void dataALLClientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataALLClientes.SelectedRows.Count > 0)
                {
                    var selectedRow = dataALLClientes.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var client = clienteLogic.GetById(id);

                        txtNameModCliente.Text = client.NOMBRE;
                        txtApellidoModCliente.Text = client.APELLIDO;
                        txtDNIModCliente.Text = Convert.ToString(client.DNI);
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para modificar un cliente.
        /// </summary>
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Parse(dataALLClientes.SelectedRows[0].Cells["Id"].Value.ToString());

                var client = clienteLogic.GetById(id);

                client.NOMBRE = txtNameModCliente.Text;
                client.APELLIDO = txtApellidoModCliente.Text;
                client.DNI = Convert.ToInt32(txtDNIModCliente.Text);

                clienteLogic.Update(client);

                ActualizarGridsCliente();

                txtNameModCliente.Clear();
                txtApellidoModCliente.Clear();
                txtDNIModCliente.Clear();

                ActualizarGridsCliente();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region ManejadorPedidos

        PedidoLogic pedidoLogic = PedidoLogic.GetInstance();
        DetallePedidoLogic detallePedidoLogic = DetallePedidoLogic.GetInstance();

        private List<DETALLE_PEDIDO> detalles = new List<DETALLE_PEDIDO>();
        private List<ProductoDetalleDTO> productoDetalles;
        private bool isUpdatingDataSource = false;

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para ingresar numeros.
        /// </summary>
        private void btnNumericoP_Click(object sender, EventArgs e)
        {
            Button botonpresionado = sender as Button;

            if (botonpresionado != null)
            {
                txtCodEMPPedido.Text += botonpresionado.Text;
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para eliminar el contenido de un textBox.
        /// </summary>
        private void btnBorrarP_Click1(object sender, EventArgs e)
        {
            if (txtCodEMPPedido.Text.Length > 0)
            {
                txtCodEMPPedido.Text = txtCodEMPPedido.Text.Substring(0, txtCodEMPPedido.Text.Length - 1);
            }
        }

        /// <summary>
        /// Actualiza los comboBox con la información de los productos.
        /// </summary>
        public void ActualiarCombosProduPedi()
        {
            try
            {
                var bebidas = productoLogic.GetBebidas();
                comboBebidas.DataSource = null;
                comboBebidas.DataSource = bebidas;
                comboBebidas.DisplayMember = "Nombre";
                comboBebidas.ValueMember = "Id";

                var comidas = productoLogic.GetComidas();
                comboComidas.DataSource = null;
                comboComidas.DataSource = comidas;
                comboComidas.DisplayMember = "Nombre";
                comboComidas.ValueMember = "Id";
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza los grids con la información de los pedidos.
        /// </summary>
        public void ActualizarDataPedido()
        {
            try
            {
                var pedidosBD = pedidoLogic.GetPedidos();

                dataPedidos.DataSource = null;
                dataPedidos.DataSource = pedidosBD;
                dataPedidos.Columns["Id"].Visible = false;
                dataPedidos.Columns["Cliente"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza los grids con la información de los detalles de un pedido.
        /// </summary>
        public void ActualizarDataDetalle(Guid id)
        {
            try
            {
                var detalles = detallePedidoLogic.ObtenerDetallesPorPedido(id);

                dataDetallesMomentum.DataSource = null;
                dataDetallesMomentum.DataSource = detalles;
                dataDetallesMomentum.Columns["Id_Detalle"].Visible = false;
                dataDetallesMomentum.Columns["Id_Producto"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para registrar un Pedido.
        /// </summary>
        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoPedido = new PEDIDO();
                nuevoPedido.FECHA_HORA = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
                nuevoPedido.ESTADO = "Pendiente";

                if (txtDNIped.Text == "")
                {
                    var clienteSelecc = clienteLogic.GetOneByDNI(0);

                    if (clienteSelecc != null)
                    {
                        nuevoPedido.ID_CLIENTE = clienteSelecc.ID_CLIENTE;
                    }
                }
                else
                {
                    var clienteSelecc = clienteLogic.GetOneByDNI(Convert.ToInt32(txtDNIped.Text));

                    if (clienteSelecc != null)
                    {
                        nuevoPedido.ID_CLIENTE = clienteSelecc.ID_CLIENTE;
                    }
                }

                pedidoLogic.Add(nuevoPedido);

                if (detalles.Count == 0) throw new BusinessRuleException("Debe agregar productos antes de Registrar un Pedido");

                foreach (var detalle in detalles)
                {
                    detalle.ID_PEDIDO = nuevoPedido.ID_PEDIDO;
                    detallePedidoLogic.Add(detalle);
                }

                detalles = new List<DETALLE_PEDIDO>();
                productoDetalles = new List<ProductoDetalleDTO>();
                txtDNIped.Clear();
                ActualizarDataPedido();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza la lista de detalles de productos y los muestra en un control de datos (DataGridView).
        /// Este método obtiene los detalles de los productos a partir de una lista de detalles, 
        /// los procesa y actualiza el origen de datos del control, ocultando columnas específicas.
        /// Si no hay detalles disponibles, se muestra un mensaje informando al usuario.
        /// </summary>
        public void UpdateListaDetalles()
        {
            try
            {
                isUpdatingDataSource = true;
                productoDetalles = new List<ProductoDetalleDTO>();

                foreach (var detalle in detalles)
                {
                    var produ = productoLogic.GetById(detalle.ID_PRODUCTO);

                    ProductoDetalleDTO dto = new ProductoDetalleDTO
                    {
                        Id_Detalle = detalle.ID_DETALLE,
                        Id_Producto = detalle.ID_PRODUCTO,
                        Producto = produ.NOMBRE,
                        Cantidad = detalle.CANTIDAD
                    };

                    productoDetalles.Add(dto);
                }

                if (productoDetalles != null && productoDetalles.Count > 0)
                {
                    dataDetallesMomentum.DataSource = null;
                    dataDetallesMomentum.DataSource = productoDetalles;

                    dataDetallesMomentum.Columns["Id_Detalle"].Visible = false;
                    dataDetallesMomentum.Columns["Id_Producto"].Visible = false;
                }
                else
                {
                    dataDetallesMomentum.DataSource = null;
                    MessageBox.Show("No hay detalles disponibles");
                }

                isUpdatingDataSource = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para agregar un Detalle a la lista.
        /// </summary>
        private void btnAddComida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataPedidos.SelectedRows.Count > 0)
                {
                    var selectedRow = dataPedidos.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var pedido = pedidoLogic.GetById(id);

                        var detalleAgregado = new DETALLE_PEDIDO();
                        detalleAgregado.ID_PEDIDO = pedido.ID_PEDIDO;
                        detalleAgregado.ID_PRODUCTO = (Guid)comboComidas.SelectedValue;

                        if (txtCantC.Text == "0" || txtCantC.Text == "") throw new BusinessRuleException("No puede agregar 0 comidas");

                        detalleAgregado.CANTIDAD = Convert.ToInt32(txtCantC.Text);

                        detallePedidoLogic.Add(detalleAgregado);

                        ActualizarDataDetalle(id);

                        ActualizarDataPedido();
                    }
                }
                else
                {
                    var detalle = new DETALLE_PEDIDO();
                    detalle.ID_DETALLE = Guid.NewGuid();
                    detalle.ID_PRODUCTO = (Guid)comboComidas.SelectedValue;
                    detalle.CANTIDAD = Convert.ToInt32(txtCantC.Text);

                    detalles.Add(detalle);
                    UpdateListaDetalles();
                    txtCantC.Clear();
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para agregar un Detalle a la lista.
        /// </summary>
        private void btnAddBebida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataPedidos.SelectedRows.Count > 0)
                {
                    var selectedRow = dataPedidos.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var pedido = pedidoLogic.GetById(id);

                        var detalleAgregado = new DETALLE_PEDIDO();
                        detalleAgregado.ID_PEDIDO = pedido.ID_PEDIDO;
                        detalleAgregado.ID_PRODUCTO = (Guid)comboComidas.SelectedValue;

                        if (txtCantB.Text == "0" || txtCantB.Text == "") throw new BusinessRuleException("No puede agregar 0 bebidas");

                        detalleAgregado.CANTIDAD = Convert.ToInt32(txtCantB.Text);

                        detallePedidoLogic.Add(detalleAgregado);

                        ActualizarDataDetalle(id);

                        ActualizarDataPedido();
                    }
                }
                else
                {
                    var detalle = new DETALLE_PEDIDO();

                    detalle.ID_DETALLE = Guid.NewGuid();
                    detalle.ID_PRODUCTO = (Guid)comboBebidas.SelectedValue;
                    detalle.CANTIDAD = Convert.ToInt32(txtCantB.Text);

                    detalles.Add(detalle);
                    UpdateListaDetalles();
                    txtCantB.Clear();
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para realizar un pedido.
        /// </summary>
        private void btnHacerPedido_Click(object sender, EventArgs e)
        {
            try
            {
                var pedidoDTO = (PedidoCompletoDTO)dataPedidos.SelectedRows[0].DataBoundItem;
                Guid id = pedidoDTO.Id;

                var pedido = pedidoLogic.GetById(id);
                pedido.COD_EMPLEADO = Convert.ToInt32(txtCodEMPPedido.Text);

                pedidoLogic.ProcesarPedido(pedido);

                ActualizarDataPedido();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para finalizar un pedido.
        /// </summary>
        private void btnFinPedido_Click(object sender, EventArgs e)
        {
            try
            {
                var pedidoDTO = (PedidoCompletoDTO)dataPedidos.SelectedRows[0].DataBoundItem;
                Guid id = pedidoDTO.Id;

                var pedido = pedidoLogic.GetById(id);
                
                pedidoLogic.ProcesarPedido(pedido);

                ActualizarDataPedido();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para cancelar un pedido.
        /// </summary>
        private void btnCancelPedido_Click(object sender, EventArgs e)
        {
            try
            {
                var pedidoDTO = (PedidoCompletoDTO)dataPedidos.SelectedRows[0].DataBoundItem;
                Guid id = pedidoDTO.Id; 

                var pedido = pedidoLogic.GetById(id);
                pedido.ESTADO = "Cancelado";
                pedidoLogic.ProcesarPedido(pedido);

                ActualizarDataPedido();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para sumar cantidad de bebida a un textbox.
        /// </summary>
        private void btnMasDrink_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtCantB.Text, out int cantidad))
            {
                cantidad++;
                txtCantB.Text = cantidad.ToString();
            }
            else
            {
                txtCantB.Text = "1";
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para restar cantidad de bebida a un textbox.
        /// </summary>
        private void btnMenosDrink_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtCantB.Text, out int cantidad))
            {
                if(cantidad > 1)
                {
                    cantidad--;
                }
                txtCantB.Text = cantidad.ToString();
            }
            else
            {
                txtCantB.Text= "1";
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para sumar cantidad de comida a un textbox.
        /// </summary>
        private void btnMasFood_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantC.Text, out int cantidad))
            {
                cantidad++;
                txtCantC.Text = cantidad.ToString();
            }
            else
            {
                txtCantC.Text = "1";
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para restar cantidad de comida a un textbox.
        /// </summary>
        private void btnMenosFood_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantC.Text, out int cantidad))
            {
                if (cantidad > 1)
                {
                    cantidad--;
                }
                txtCantC.Text = cantidad.ToString();
            }
            else
            {
                txtCantC.Text = "1";
            }
        }


        /// <summary>
        /// Evento que se dispara cuando cambia la selección en el DataGridView de pedidos.
        /// Actualiza el DataGridView de detalles con los detalles del pedido seleccionado.
        /// </summary>
        private void dataPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataPedidos.SelectedRows.Count > 0)
                {
                    var selectedRow = dataPedidos.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var detalles = detallePedidoLogic.ObtenerDetallesPorPedido(id);

                        dataDetallesMomentum.DataSource = null;
                        dataDetallesMomentum.DataSource = detalles;
                        dataDetallesMomentum.Columns["Id_Detalle"].Visible = false;
                        dataDetallesMomentum.Columns["Id_Producto"].Visible = false;

                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la selección en el DataGridView de detalles.
        /// Muestra la cantidad del producto seleccionado en el TextBox correspondiente.
        /// </summary>
        private void dataDetallesMomentum_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (isUpdatingDataSource) return;

                if (dataDetallesMomentum.SelectedRows.Count > 0)
                {
                    var selectedRow = dataDetallesMomentum.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        if (dataPedidos.SelectedRows.Count > 0)
                        {
                            var detalle = detallePedidoLogic.GetById(id);

                            txtCantProdu.Text = detalle.CANTIDAD.ToString();
                        }
                        else
                        {
                            try
                            {
                                var detalleMemoria = detalles.FirstOrDefault(d => d.ID_DETALLE == id);
                                txtCantProdu.Text = detalleMemoria.CANTIDAD.ToString();
                            }
                            catch (Exception ex)
                            {
                                throw ex; 
                            }
     
                        }
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para aumentar la cantidad de productos.
        /// Incrementa la cantidad mostrada en el TextBox de cantidad.
        /// </summary>
        private void btnMasProdu_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantProdu.Text, out int cantidad))
            {
                cantidad++;
                txtCantProdu.Text = cantidad.ToString();
            }
            else
            {
                txtCantProdu.Text = "1";
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para disminuir la cantidad de productos.
        /// Decrementa la cantidad mostrada en el TextBox de cantidad, sin permitir que sea menor a 1.
        /// </summary>
        private void btnMenosProdu_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantProdu.Text, out int cantidad))
            {
                if (cantidad > 1)
                {
                    cantidad--;
                }
                txtCantProdu.Text = cantidad.ToString();
            }
            else
            {
                txtCantProdu.Text = "1";
            }
        }


        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para eliminar un producto de los detalles.
        /// Elimina el producto seleccionado del DataGridView de detalles y actualiza la lista.
        /// </summary>
        private void btnEliminarProduDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataDetallesMomentum.SelectedRows.Count > 0)
                {
                    var selectedRow = dataDetallesMomentum.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        if (dataPedidos.SelectedRows.Count <= 0)
                        {
                            var detalle = detalles.FirstOrDefault(d => d.ID_DETALLE == id);


                            txtCantProdu.Clear();
                            detalles.Remove(detalle);
                            UpdateListaDetalles();
                        }
                        else
                        {
                            detallePedidoLogic.Remove(id);


                            txtCantProdu.Clear();
                            dataPedidos_SelectionChanged(sender, e);
                            ActualizarDataPedido();
                        }

                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al presionar una tecla en el TextBox de cantidad.
        /// Actualiza la cantidad del producto seleccionado al presionar Enter.
        /// </summary>
        private void txtCantProdu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dataDetallesMomentum.SelectedRows.Count > 0)
                    {
                        var selectedRow = dataDetallesMomentum.SelectedRows[0];

                        if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                        {
                            var detalle = detallePedidoLogic.GetById(id);

                            detalle.CANTIDAD = Convert.ToInt32(txtCantProdu.Text);

                            detallePedidoLogic.Update(detalle);

                            txtCantProdu.Clear();

                            if (dataPedidos.SelectedRows.Count > 0)
                            {
                                var selectedPedido = dataPedidos.SelectedRows[0];

                                if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id2))
                                {
                                    var detalles = detallePedidoLogic.ObtenerDetallesPorPedido(id2);

                                    dataDetallesMomentum.DataSource = null;
                                    dataDetallesMomentum.DataSource = detalles;
                                    dataDetallesMomentum.Columns["Id_Detalle"].Visible = false;
                                    dataDetallesMomentum.Columns["Id_Producto"].Visible = false;

                                    ActualizarDataPedido();
                                }
                            }
                        }
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para borrar la selección de pedidos.
        /// Limpia la selección en el DataGridView de pedidos y vacía el TextBox de cantidad.
        /// </summary>
        private void btnBorrarSeleccion_Click(object sender, EventArgs e)
        {
            dataPedidos.ClearSelection();

            txtCantProdu.Clear();
        }


        #endregion

        #region ManejadorEmpleado

        EmpleadoLogic empleadoLogic = EmpleadoLogic.GetInstance();

        /// <summary>
        /// Actualiza la lista de empleados en el DataGridView.
        /// Obtiene la lista de empleados desde la lógica de negocio y la asigna como fuente de datos.
        /// </summary>
        public void ActualizarDataEmpleado()
        {
            try
            {
                var dtos = empleadoLogic.GetEmpleados();

                dataEmpleados.DataSource = null;
                dataEmpleados.DataSource = dtos;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para actualizar la lista de empleados.
        /// Llama al método ActualizarDataEmpleado.
        /// </summary>
        private void btnActDataEmpleados_Click(object sender, EventArgs e)
        {
            ActualizarDataEmpleado();
        }


        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para registrar un nuevo empleado.
        /// Crea un nuevo objeto EMPLEADO y lo agrega a la base de datos.
        /// </summary>
        private void btnRegistrarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = new EMPLEADO();
                emp.COD_EMPLEADO = Convert.ToInt32(txtCodEmpReg.Text);
                emp.NOMBRE = txtNameEmpReg.Text;
                emp.APELLIDO = txtApellidoEmpReg.Text;
                emp.ROL = txtRolEmpReg.Text;
                emp.TURNO = comboTurnoEmpReg.Text;
                emp.DNI = Convert.ToInt32(txtDNIEmpReg.Text);
                emp.TELEFONO = txtTelefonoEmpReg.Text;
                emp.ESTADO = true;

                empleadoLogic.Add(emp);

                txtCodEmpReg.Clear();
                txtNameEmpReg.Clear();
                txtApellidoEmpReg.Clear();
                txtRolEmpReg.Clear();
                txtDNIEmpReg.Clear();
                txtTelefonoEmpReg.Clear();

                ActualizarDataEmpleado();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la selección en el DataGridView de empleados.
        /// Carga los datos del empleado seleccionado en los campos de modificación.
        /// </summary>
        private void dataEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataEmpleados.SelectedRows.Count > 0)
                {
                    var selectedRow = dataEmpleados.SelectedRows[0];

                    if (Int32.TryParse(selectedRow.Cells[0].Value.ToString(), out int id))
                    {
                        var emp = empleadoLogic.GetOne(id);

                        txtNameEmpMod.Text = emp.NOMBRE;
                        txtApellidoEmpMod.Text = emp.APELLIDO;
                        txtDNIEmpMod.Text = emp.DNI.ToString();
                        txtTelefonoEmpMod.Text = emp.TELEFONO;
                        txtRolEmpMod.Text = emp.ROL;

                        comboTurnoEmpMod.SelectedItem = emp.TURNO == "Tarde" ? "Tarde" : "Mañana";
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para modificar un empleado.
        /// Actualiza los datos del empleado seleccionado en la base de datos.
        /// </summary>
        private void btnModificarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32((dataEmpleados.SelectedRows[0].Cells["Codigo"].Value.ToString()));

                var emp = empleadoLogic.GetOne(id);

                emp.NOMBRE = txtNameEmpMod.Text;
                emp.APELLIDO = txtApellidoEmpMod.Text;
                emp.DNI = Convert.ToInt32(txtDNIEmpMod.Text);
                emp.TELEFONO = txtTelefonoEmpMod.Text;
                emp.TURNO = comboTurnoEmpMod.Text;
                emp.ROL = txtRolEmpMod.Text;

                empleadoLogic.Update(emp);

                txtNameEmpMod.Clear();
                txtApellidoEmpMod.Clear();
                txtDNIEmpMod.Clear();
                txtTelefonoEmpMod.Clear();
                txtRolEmpMod.Clear();

                ActualizarDataEmpleado();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para buscar un empleado por nombre.
        /// Obtiene el empleado correspondiente y lo muestra en el DataGridView.
        /// </summary>
        private void btnBuscarOneEmp_Click(object sender, EventArgs e)
        {
            try
            {
                var oneEmp = empleadoLogic.GetByName(txtNameEmpBuscar.Text);

                dataOneEmpleado.DataSource = null;
                dataOneEmpleado.DataSource = oneEmp;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para eliminar (desactivar) un empleado.
        /// Cambia el estado del empleado seleccionado a inactivo.
        /// </summary>
        private void btnEliminarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int16.Parse(dataEmpleados.SelectedRows[0].Cells["Codigo"].Value.ToString());
                var emp = empleadoLogic.GetOne(id);

                if (emp.ESTADO == true)
                {
                    emp.ESTADO = false;
                }
                else if (emp.ESTADO == false)
                {
                    emp.ESTADO = true;
                }

                empleadoLogic.Update(emp);

                ActualizarDataEmpleado();

            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ManejoBono

        BonoLogic bonoLogic = BonoLogic.GetInstance();

        /// <summary>
        /// Actualiza la lista de bonos en el DataGridView.
        /// Obtiene la lista de bonos desde la lógica de negocio y la asigna como fuente de datos.
        /// </summary>
        public void ActualizarDataBono()
        {
            try
            {
                var lista = bonoLogic.GetBonos();
                dataBonos.DataSource = null;
                dataBonos.DataSource = lista;
                dataBonos.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para actualizar la lista de bonos.
        /// Llama al método ActualizarDataBono.
        /// </summary>
        private void btnActDataBono_Click(object sender, EventArgs e)
        {
            ActualizarDataBono();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para agregar un nuevo bono.
        /// Crea un nuevo objeto BONO y lo agrega a la base de datos.
        /// </summary>
        private void btnAgregarBono_Click(object sender, EventArgs e)
        {
            try
            {
                var bono = new BONO();

                bono.CATEGORIA = txtCategBono.Text;
                bono.MONTO = Convert.ToDecimal(txtMontoBono.Text);
                bono.MINIMO_TAREAS = Convert.ToInt32(txtMinTareasBono.Text);
                bono.ESTADO = true;

                bonoLogic.Add(bono);

                txtCategBono.Clear();
                txtMontoBono.Clear();
                txtMinTareasBono.Clear();

                ActualizarDataBono();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para eliminar (desactivar) un bono.
        /// Cambia el estado del bono seleccionado a inactivo o activo.
        /// </summary>
        private void btnEliminarBono_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Parse(dataBonos.SelectedRows[0].Cells["Id"].Value.ToString());
                var bono = bonoLogic.GetById(id);

                if (bono.ESTADO == true)
                {
                    bono.ESTADO = false;
                }
                else if (bono.ESTADO == false)
                {
                    bono.ESTADO = true;
                }

                bonoLogic.Update(bono);

                ActualizarDataBono();

            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ManejoTarea

        TareaLogic tareaLogic = TareaLogic.GetInstance();

        /// <summary>
        /// Actualiza la lista de tareas en el DataGridView.
        /// Obtiene la lista de tareas desde la lógica de negocio y la asigna como fuente de datos.
        /// </summary>
        public void ActualizarDataTareas()
        {
            try
            {
                var tareasDTO = tareaLogic.GetTareas();
                dataTareas.DataSource = null;
                dataTareas.DataSource = tareasDTO;
                dataTareas.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para actualizar la lista de tareas.
        /// Llama al método ActualizarDataTareas.
        /// </summary>
        private void btnActDataTareas_Click(object sender, EventArgs e)
        {
            ActualizarDataTareas();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón para crear una nueva tarea.
        /// Crea un nuevo objeto TAREA y lo agrega a la base de datos.
        /// </summary>
        private void btnCrearTarea_Click(object sender, EventArgs e)
        {
            try
            {
                TAREA tarea = new TAREA();
                tarea.NOMBRE = txtNameTareaCrear.Text;
                tarea.DESCRIPCION = txtDescpTareaCrear.Text;
                tarea.ESTADO = "Pendiente";

                tareaLogic.Add(tarea);

                ActualizarDataTareas();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Maneja el evento de clic en el botón para eliminar o restaurar una tarea seleccionada.
        /// Cambia el estado de la tarea entre "Deshabilitada" y su estado anterior.
        /// </summary>
        /// <param name="sender">El origen del evento, normalmente el botón que fue clicado.</param>
        /// <param name="e">Los datos del evento asociados al clic.</param>
        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Parse(dataTareas.SelectedRows[0].Cells["Id"].Value.ToString());
                var tarea = tareaLogic.GetById(id);

                if (tarea.ESTADO == "Pendiente" || tarea.ESTADO == "En Proceso" || tarea.ESTADO == "Finalizada")
                {
                    tarea.ESTADO = "Deshabilitada";
                }
                else if (tarea.ESTADO == "Deshabilitada")
                {
                    tarea.ESTADO = "Pendiente";
                }

                tareaLogic.Update(tarea);

                ActualizarDataTareas();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion


        #region ManejoDetalleTareas

        EmpleadoTareaLogic detalleTarealogic = EmpleadoTareaLogic.GetInstance();


        /// <summary>
        /// Manejador de eventos para los botones numéricos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnNumerico_Click(object sender, EventArgs e)
        {
            Button botonpresionado = sender as Button;

            if(botonpresionado != null)
            {
                txtCodEmpDoTarea.Text += botonpresionado.Text; 
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón de borrar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(txtCodEmpDoTarea.Text.Length > 0)
            {
                txtCodEmpDoTarea.Text = txtCodEmpDoTarea.Text.Substring(0, txtCodEmpDoTarea.Text.Length - 1);
            }
        }


        /// <summary>
        /// Actualiza la lista de detalles de tareas en la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Este método se encarga de obtener la lista de detalles de tareas desde la lógica de negocio y asignarla al origen de datos del control de datos.
        /// </remarks>
        public void ActualizarDetallesTarea()
        {
            try
            {
                var lista = detalleTarealogic.GetDetalles();
                dataDetalleTareas.DataSource = null;
                dataDetalleTareas.DataSource = lista;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Actualiza la lista de desempeños de los empleados en la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Este método obtiene la lista de desempeños del mes desde la lógica de negocio y la asigna al origen de datos del control de datos.
        /// También oculta la columna "Id" en la vista.
        /// </remarks>
        public void ActualizarDesempeñosEmpleados()
        {
            try
            {
                var lista = detalleTarealogic.ObtenerDesempDelMes();
                dataDesempEmp.DataSource = null;
                dataDesempEmp.DataSource = lista;
                dataDesempEmp.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos que se ejecuta cuando la selección del control de datos de desempeños de empleados cambia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void dataDesempEmp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataDesempEmp.SelectedRows.Count > 0)
                {
                    var selectedRow = dataDesempEmp.SelectedRows[0];

                    if (int.TryParse(selectedRow.Cells[0].Value.ToString(), out int id))
                    {
                        var desempPerEmp = detalleTarealogic.GetDetallesPorEmp(id);

                        dataTaskPerEmp.DataSource = null;
                        dataTaskPerEmp.DataSource = desempPerEmp;
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que actualiza los detalles de la tarea.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDetalleTarea_Click(object sender, EventArgs e)
        {
            ActualizarDetallesTarea();
        }

        /// <summary>
        /// Manejador de eventos para el botón que actualiza los desempeños de los empleados.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataDesempEmp_Click(object sender, EventArgs e)
        {
            ActualizarDesempeñosEmpleados();
        }


        /// <summary>
        /// Manejador de eventos para el botón que inicia la tarea seleccionada.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnHacerTarea_Click(object sender, EventArgs e)
        {
            try
            {
                var tareaDTO = (TareaDTO)dataTareas.SelectedRows[0].DataBoundItem;
                Guid id = tareaDTO.Id;

                if (tareaDTO.Estado != "Pendiente") throw new BusinessRuleException("Debe seleccionar una Tarea en estado Pendiente para realizar.");

                DETALLE_TAREA detalle = new DETALLE_TAREA();
                detalle.ID_TAREA = id;
                detalle.COD_EMPLEADO = Convert.ToInt32(txtCodEmpDoTarea.Text);

                detalleTarealogic.HacerTarea(detalle);

                var tarea = tareaLogic.GetById(id);
                tareaLogic.ProcesarTarea(tarea);

                ActualizarDataTareas();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que finaliza la tarea seleccionada.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnTerminarTarea_Click(object sender, EventArgs e)
        {
            try
            {
                var tareaDTO = (TareaDTO)dataTareas.SelectedRows[0].DataBoundItem;
                Guid id = tareaDTO.Id;

                if (tareaDTO.Estado != "En Proceso") throw new BusinessRuleException("Debe seleccionar una Tarea en estado En Proceso para finalizar.");

                detalleTarealogic.FinTarea(id);

                var tarea = tareaLogic.GetById(id);
                tareaLogic.ProcesarTarea(tarea);

                ActualizarDataTareas();
                ActualizarDetallesTarea();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        #endregion

        #region ManejoProductos

        ProductoLogic productoLogic = ProductoLogic.GetInstance();

        /// <summary>
        /// Actualiza la lista de productos en la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Este método obtiene la lista de productos desde la lógica de negocio y la asigna al origen de datos del control de datos.
        /// También oculta la columna "Id" en la vista.
        /// </remarks>
        public void ActualizarDataProductos()
        {
            try
            {
                var lista = productoLogic.GetProducts();

                dataAllProductos.DataSource = null;
                dataAllProductos.DataSource = lista;
                dataAllProductos.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que actualiza la lista de productos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataProd_Click(object sender, EventArgs e)
        {
            ActualizarDataProductos();
        }

        /// <summary>
        /// Manejador de eventos para el botón que agrega un nuevo producto.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var prod = new PRODUCTO();

                prod.NOMBRE = txtNameProdCrear.Text;
                prod.DESCRIPCION = txtDescrpProdCrear.Text;
                prod.TIPO = comboTipoProdCrear.Text;
                prod.PRECIO = Convert.ToDecimal(txtPrecioProdCrear.Text);
                prod.ESTADO = true;

                productoLogic.Add(prod);

                ActualizarDataProductos();

                txtNameProdCrear.Clear();
                txtDescrpProdCrear.Clear();
                txtPrecioProdCrear.Clear();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos que se ejecuta cuando la selección del control de datos de productos cambia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void dataAllProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataAllProductos.SelectedRows.Count > 0)
                {
                    var selectedRow = dataAllProductos.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var produ = productoLogic.GetById(id);

                        txtNameProdMod.Text = produ.NOMBRE;
                        txtDescrpProdMod.Text = produ.DESCRIPCION;
                        txtPrecioProdMod.Text = produ.PRECIO.ToString();

                        comboTipoProdMod.SelectedItem = produ.TIPO == "Comida" ? "Comida" : "Bebida";
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que modifica un producto seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Parse(dataAllProductos.SelectedRows[0].Cells["Id"].Value.ToString());

                var produ = productoLogic.GetById(id);

                produ.NOMBRE = txtNameProdMod.Text;
                produ.DESCRIPCION = txtDescrpProdMod.Text;
                produ.PRECIO = Convert.ToDecimal(txtPrecioProdMod.Text);
                produ.TIPO = Convert.ToString(comboTipoProdMod.SelectedItem);

                productoLogic.Update(produ);

                ActualizarDataProductos();

                txtNameProdMod.Clear();
                txtDescrpProdMod.Clear();
                txtPrecioProdMod.Clear();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que busca un producto por su nombre.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtNameProdBuscar.Text;
                var products = productoLogic.GetProductoByName(name);

                dataOneProdu.DataSource = null;
                dataOneProdu.DataSource = products;
                dataOneProdu.Columns["Id"].Visible = false;

                txtNameProdBuscar.Clear();
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que habilita o deshabilita un producto seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEnableProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Parse(dataAllProductos.SelectedRows[0].Cells["Id"].Value.ToString());
                var produ = productoLogic.GetById(id);

                if(produ.ESTADO == true)
                {
                    produ.ESTADO = false;
                }
                else if(produ.ESTADO == false)
                {
                    produ.ESTADO = true;
                }

                productoLogic.Update(produ);

            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #endregion

        #region ManejoUsuarios

        UserService userServe = new UserService();
        
       
        private List<Patente> patentes = new List<Patente>();

        /// <summary>
        /// Manejador de eventos para el botón que actualiza la lista de usuarios en la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataUsers_Click(object sender, EventArgs e)
        {
            try
            {
                dataAllUsers.DataSource = null;
                dataAllUsers.DataSource = userServe.GetUsuariosDTO();
                dataAllUsers.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos que se ejecuta cuando la selección del control de datos de usuarios cambia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void dataAllUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataAllUsers.SelectedRows.Count > 0)
                {
                    var selectedRow = dataAllUsers.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var familias = userServe.GetFamiliasByUsuarioId(id);

                        dataFamPorUser.DataSource = null;
                        dataFamPorUser.DataSource= familias;
                        dataFamPorUser.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que actualiza la lista de familias en la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataFam_Click(object sender, EventArgs e)
        {
            try
            {
                dataAllRoles.DataSource = null;
                dataAllRoles.DataSource = FamiliaService.GetAllFamilias();
                dataAllRoles.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que actualiza la lista de permisos en la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataPatent_Click(object sender, EventArgs e)
        {
            try
            {
                dataAllPermisos.DataSource = null;
                dataAllPermisos.DataSource = FamiliaService.GetAllPatentes();
                dataAllPermisos.Columns["Id"].Visible = false;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando la selección del control de datos de roles cambia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void dataAllRoles_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataAllRoles.SelectedRows.Count > 0)
                {
                    var selectedRow = dataAllRoles.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        var patentes = FamiliaService.GetPatentesByFamiliaId(id);

                        dataPermisosPorRol.DataSource = null;
                        dataPermisosPorRol.DataSource = patentes;
                        dataPermisosPorRol.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que crea un nuevo usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCrearUser_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario newUser = new Usuario();
                newUser.UserName = txtUserNameCreate.Text;
                newUser.Estado = true;

                string pass = txtPassCreate.Text;

                userServe.CreateUser(newUser, pass);

                btnActDataUsers_Click(sender, e);
                MessageBox.Show("Usuario registrado con exito!");
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Manejador de eventos para el botón que crea una nueva patente.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCrearPatent_Click(object sender, EventArgs e)
        {
            try
            {
                Patente patente = new Patente();
                patente.Nombre = txtPatentName.Text;
                patente.DataKey = txtDataKey.Text;

                FamiliaService.CreatePatente(patente);

                btnActDataPatent_Click(sender, e);
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que recopila los permisos seleccionados.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnGatherPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAllPermisos.SelectedRows.Count > 0)
                {
                    patentes.Clear();

                    foreach (DataGridViewRow row in dataAllPermisos.SelectedRows)
                    {
                        if (row.DataBoundItem is Patente patente)
                        {
                            patentes.Add(patente);
                        }
                    }

                    MessageBox.Show($"Se han seleccionado {patentes.Count} permisos.");
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que crea un nuevo rol con los permisos seleccionados.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                var famName = txtRolName.Text;

                FamiliaService.CrearFamiliaConPatentes(famName, patentes);

                patentes.Clear();
                dataAllPermisos.ClearSelection();
                btnActDataFam_Click(sender, e);
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Manejador de eventos para el botón que asocia permisos a un rol seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAsociarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAllRoles.SelectedRows.Count > 0)
                {
                    if(patentes.Count > 0)
                    {
                        var fam = (Familia)dataAllRoles.SelectedRows[0].DataBoundItem;

                        FamiliaService.AddPatentesToFamilia(fam, patentes);

                        btnActDataFam_Click(sender, e);
                    }
                    else
                    {
                        throw new Exception("No hay permisos seleccionados para asociar.");
                    }
                }
                else
                {
                    throw new Exception("No se ha seleccionado ningun rol para asociar.");
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que habilita o deshabilita un usuario seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEnableUser_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataAllUsers.SelectedRows.Count > 0)
                {
                    var user = (Usuario)dataAllUsers.SelectedRows[0].DataBoundItem;

                    if(user.Estado == true)
                    {
                        userServe.DisableUser(user.IdUsuario);
                    }
                    else if(user.Estado == false)
                    {
                        userServe.EnabledUsuario(user.IdUsuario);
                    }

                    btnActDataUsers_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Porfavor seleccione un usuario a habilitar/deshabilitar primero");
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que asocia un rol a un usuario seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnAssociateRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAllUsers.SelectedRows.Count > 0)
                {
                    if (dataAllRoles.SelectedRows.Count > 0)
                    {
                        var selectedRow = dataAllUsers.SelectedRows[0];

                        if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                        {
                            var fam = (Familia)dataAllRoles.SelectedRows[0].DataBoundItem;

                            FamiliaService.AsignarFamiliaAUsuario(id, fam);

                            btnActDataUsers_Click(sender, e);
                            dataAllUsers_SelectionChanged(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Primero seleccione un rol que asociar");
                    }
                }
                else
                {
                    MessageBox.Show("Primero seleccione un usuario al que asociar un rol");
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que elimina un usuario seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataAllUsers.SelectedRows.Count > 0)
                {
                    var selectedRow = dataAllUsers.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        userServe.DeleteUser(id);

                        btnActDataUsers_Click(sender, e);
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que elimina un rol seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAllRoles.SelectedRows.Count > 0)
                {
                    var selectedRow = dataAllRoles.SelectedRows[0];

                    if (Guid.TryParse(selectedRow.Cells[0].Value.ToString(), out Guid id))
                    {
                        FamiliaService.DeleteFamilia(id);

                        btnActDataFam_Click(sender, e);
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador de eventos para el botón que elimina una patente seleccionada.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminarPatente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAllPermisos.SelectedRows.Count > 0)
                {
                    var patente = (Patente)dataAllPermisos.SelectedRows[0].DataBoundItem;

                    FamiliaService.DeletePatente(patente.Id);

                    btnActDataPatent_Click(sender, e);

                }
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que actualiza y muestra la bitácora de eventos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataBitacora_Click(object sender, EventArgs e)
        {
            try
            {
                dataBitacora.DataSource = null;
                var bitacora = LoggerService.GetBitacora();
                var sortedBitacora = bitacora.OrderByDescending(log => log.Date).ToList();
                dataBitacora.DataSource = sortedBitacora;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón que actualiza y muestra los logs de eventos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnActDataLogs_Click(object sender, EventArgs e)
        {
            try
            {
                dataLogs.DataSource = null;
                var logs = LoggerService.GetLogs();
                var sortedLogs = logs.OrderByDescending(log => log.Date).ToList();
                dataLogs.DataSource = sortedLogs;
            }
            catch (BusinessRuleException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataAccessException ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}
