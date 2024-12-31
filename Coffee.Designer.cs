using System;

namespace WindowsFormsApp1
{
    partial class Coffee
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Coffee));
            this.tabPageEmpleados = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label64 = new System.Windows.Forms.Label();
            this.comboTurnoEmpMod = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtRolEmpMod = new System.Windows.Forms.TextBox();
            this.txtTelefonoEmpMod = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnModificarEmp = new System.Windows.Forms.Button();
            this.txtDNIEmpMod = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtApellidoEmpMod = new System.Windows.Forms.TextBox();
            this.txtNameEmpMod = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.btnEliminarEmp = new System.Windows.Forms.Button();
            this.btnActDataEmpleados = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtRolEmpReg = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.comboTurnoEmpReg = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtTelefonoEmpReg = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnRegistrarEmp = new System.Windows.Forms.Button();
            this.txtCodEmpReg = new System.Windows.Forms.TextBox();
            this.txtDNIEmpReg = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtApellidoEmpReg = new System.Windows.Forms.TextBox();
            this.txtNameEmpReg = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnBuscarOneEmp = new System.Windows.Forms.Button();
            this.txtNameEmpBuscar = new System.Windows.Forms.TextBox();
            this.dataOneEmpleado = new System.Windows.Forms.DataGridView();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.dataEmpleados = new System.Windows.Forms.DataGridView();
            this.tabPageDesempeño = new System.Windows.Forms.TabPage();
            this.label62 = new System.Windows.Forms.Label();
            this.btnEliminarBono = new System.Windows.Forms.Button();
            this.dataTaskPerEmp = new System.Windows.Forms.DataGridView();
            this.btnActDataDesempEmp = new System.Windows.Forms.Button();
            this.groupCrearBono = new System.Windows.Forms.GroupBox();
            this.txtMinTareasBono = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.btnAgregarBono = new System.Windows.Forms.Button();
            this.txtMontoBono = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCategBono = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.dataDesempEmp = new System.Windows.Forms.DataGridView();
            this.btnActDataBono = new System.Windows.Forms.Button();
            this.btnActDetalleTarea = new System.Windows.Forms.Button();
            this.dataBonos = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.dataDetalleTareas = new System.Windows.Forms.DataGridView();
            this.label23 = new System.Windows.Forms.Label();
            this.tabPageClientes = new System.Windows.Forms.TabPage();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnActDataClientes = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.dataALLClientes = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtDNIModCliente = new System.Windows.Forms.TextBox();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtApellidoModCliente = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNameModCliente = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDNIBuscarCliente = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDNIRegCliente = new System.Windows.Forms.TextBox();
            this.btnRegistrarCliente = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtApellidoRegCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNameRegCliente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataOneCliente = new System.Windows.Forms.DataGridView();
            this.tabPageTareas = new System.Windows.Forms.TabPage();
            this.btnActDataTareas = new System.Windows.Forms.Button();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.groupCrearTarea = new System.Windows.Forms.GroupBox();
            this.txtDescpTareaCrear = new System.Windows.Forms.TextBox();
            this.txtNameTareaCrear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCrearTarea = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupProcesarTarea = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.txtCodEmpDoTarea = new System.Windows.Forms.TextBox();
            this.btnTerminarTarea = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHacerTarea = new System.Windows.Forms.Button();
            this.labelAllTareas = new System.Windows.Forms.Label();
            this.dataTareas = new System.Windows.Forms.DataGridView();
            this.tabPagePedidos = new System.Windows.Forms.TabPage();
            this.btnBorrarSeleccion = new System.Windows.Forms.Button();
            this.txtCantProdu = new System.Windows.Forms.TextBox();
            this.btnMasProdu = new System.Windows.Forms.Button();
            this.btnMenosProdu = new System.Windows.Forms.Button();
            this.btnEliminarProduDetalles = new System.Windows.Forms.Button();
            this.dataDetallesMomentum = new System.Windows.Forms.DataGridView();
            this.groupCancelarPedido = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnCancelPedido = new System.Windows.Forms.Button();
            this.groupProcesarPedido = new System.Windows.Forms.GroupBox();
            this.btnBorrarP = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.txtCodEMPPedido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHacerPedido = new System.Windows.Forms.Button();
            this.btnFinPedido = new System.Windows.Forms.Button();
            this.groupManejoPedidos = new System.Windows.Forms.GroupBox();
            this.btnMenosFood = new System.Windows.Forms.Button();
            this.btnMenosDrink = new System.Windows.Forms.Button();
            this.btnMasFood = new System.Windows.Forms.Button();
            this.btnMasDrink = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDNIped = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.btnAddComida = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.btnAddBebida = new System.Windows.Forms.Button();
            this.txtCantC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtCantB = new System.Windows.Forms.TextBox();
            this.comboComidas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBebidas = new System.Windows.Forms.ComboBox();
            this.btnAddPedido = new System.Windows.Forms.Button();
            this.labelDetallePedidos = new System.Windows.Forms.Label();
            this.dataPedidos = new System.Windows.Forms.DataGridView();
            this.labelAllPedidos = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.btnEnableProduct = new System.Windows.Forms.Button();
            this.txtNameProdBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnActDataProd = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.dataOneProdu = new System.Windows.Forms.DataGridView();
            this.groupManejoProductos = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.comboTipoProdMod = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            this.txtDescrpProdMod = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtPrecioProdMod = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.txtNameProdMod = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.comboTipoProdCrear = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtPrecioProdCrear = new System.Windows.Forms.TextBox();
            this.txtDescrpProdCrear = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtNameProdCrear = new System.Windows.Forms.TextBox();
            this.dataAllProductos = new System.Windows.Forms.DataGridView();
            this.label47 = new System.Windows.Forms.Label();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.groupNewPermit = new System.Windows.Forms.GroupBox();
            this.txtDataKey = new System.Windows.Forms.TextBox();
            this.txtPatentName = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.btnCrearPatent = new System.Windows.Forms.Button();
            this.groupNewRole = new System.Windows.Forms.GroupBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.txtRolName = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.groupNewUser = new System.Windows.Forms.GroupBox();
            this.txtPassCreate = new System.Windows.Forms.TextBox();
            this.txtUserNameCreate = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.btnCrearUser = new System.Windows.Forms.Button();
            this.btnEliminarPatente = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnGatherPermisos = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.dataPermisosPorRol = new System.Windows.Forms.DataGridView();
            this.label71 = new System.Windows.Forms.Label();
            this.dataFamPorUser = new System.Windows.Forms.DataGridView();
            this.btnEnableUser = new System.Windows.Forms.Button();
            this.btnAsociarPermiso = new System.Windows.Forms.Button();
            this.btnAssociateRol = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActDataPatent = new System.Windows.Forms.Button();
            this.btnActDataFam = new System.Windows.Forms.Button();
            this.btnActDataUsers = new System.Windows.Forms.Button();
            this.dataAllPermisos = new System.Windows.Forms.DataGridView();
            this.dataAllRoles = new System.Windows.Forms.DataGridView();
            this.dataAllUsers = new System.Windows.Forms.DataGridView();
            this.tabBitacora = new System.Windows.Forms.TabPage();
            this.btnActDataBitacora = new System.Windows.Forms.Button();
            this.btnActDataLogs = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.dataLogs = new System.Windows.Forms.DataGridView();
            this.dataBitacora = new System.Windows.Forms.DataGridView();
            this.tabPageEmpleados.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOneEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpleados)).BeginInit();
            this.tabPageDesempeño.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTaskPerEmp)).BeginInit();
            this.groupCrearBono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDesempEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalleTareas)).BeginInit();
            this.tabPageClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataALLClientes)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOneCliente)).BeginInit();
            this.tabPageTareas.SuspendLayout();
            this.groupCrearTarea.SuspendLayout();
            this.groupProcesarTarea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTareas)).BeginInit();
            this.tabPagePedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetallesMomentum)).BeginInit();
            this.groupCancelarPedido.SuspendLayout();
            this.groupProcesarPedido.SuspendLayout();
            this.groupManejoPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPedidos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOneProdu)).BeginInit();
            this.groupManejoProductos.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllProductos)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.groupNewPermit.SuspendLayout();
            this.groupNewRole.SuspendLayout();
            this.groupNewUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPermisosPorRol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFamPorUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllUsers)).BeginInit();
            this.tabBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageEmpleados
            // 
            this.tabPageEmpleados.Controls.Add(this.groupBox11);
            this.tabPageEmpleados.Controls.Add(this.btnEliminarEmp);
            this.tabPageEmpleados.Controls.Add(this.btnActDataEmpleados);
            this.tabPageEmpleados.Controls.Add(this.groupBox10);
            this.tabPageEmpleados.Controls.Add(this.btnBuscarOneEmp);
            this.tabPageEmpleados.Controls.Add(this.txtNameEmpBuscar);
            this.tabPageEmpleados.Controls.Add(this.dataOneEmpleado);
            this.tabPageEmpleados.Controls.Add(this.label34);
            this.tabPageEmpleados.Controls.Add(this.label31);
            this.tabPageEmpleados.Controls.Add(this.dataEmpleados);
            this.tabPageEmpleados.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmpleados.Name = "tabPageEmpleados";
            this.tabPageEmpleados.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmpleados.Size = new System.Drawing.Size(1165, 719);
            this.tabPageEmpleados.TabIndex = 4;
            this.tabPageEmpleados.Tag = "tabEmp";
            this.tabPageEmpleados.Text = "Empleados";
            this.tabPageEmpleados.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label64);
            this.groupBox11.Controls.Add(this.comboTurnoEmpMod);
            this.groupBox11.Controls.Add(this.label46);
            this.groupBox11.Controls.Add(this.txtRolEmpMod);
            this.groupBox11.Controls.Add(this.txtTelefonoEmpMod);
            this.groupBox11.Controls.Add(this.label32);
            this.groupBox11.Controls.Add(this.btnModificarEmp);
            this.groupBox11.Controls.Add(this.txtDNIEmpMod);
            this.groupBox11.Controls.Add(this.label39);
            this.groupBox11.Controls.Add(this.label40);
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.txtApellidoEmpMod);
            this.groupBox11.Controls.Add(this.txtNameEmpMod);
            this.groupBox11.Controls.Add(this.label42);
            this.groupBox11.Location = new System.Drawing.Point(631, 384);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(493, 315);
            this.groupBox11.TabIndex = 4;
            this.groupBox11.TabStop = false;
            this.groupBox11.Tag = "modEmp";
            this.groupBox11.Text = "Modificar Empleado";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(275, 163);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(26, 13);
            this.label64.TabIndex = 18;
            this.label64.Tag = "newRol";
            this.label64.Text = "Rol:";
            // 
            // comboTurnoEmpMod
            // 
            this.comboTurnoEmpMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurnoEmpMod.FormattingEnabled = true;
            this.comboTurnoEmpMod.Items.AddRange(new object[] {
            "Mañana",
            "Tarde"});
            this.comboTurnoEmpMod.Location = new System.Drawing.Point(354, 87);
            this.comboTurnoEmpMod.Name = "comboTurnoEmpMod";
            this.comboTurnoEmpMod.Size = new System.Drawing.Size(111, 21);
            this.comboTurnoEmpMod.TabIndex = 17;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(275, 90);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(38, 13);
            this.label46.TabIndex = 16;
            this.label46.Tag = "newTurno";
            this.label46.Text = "Turno:";
            // 
            // txtRolEmpMod
            // 
            this.txtRolEmpMod.Location = new System.Drawing.Point(354, 160);
            this.txtRolEmpMod.Name = "txtRolEmpMod";
            this.txtRolEmpMod.Size = new System.Drawing.Size(111, 20);
            this.txtRolEmpMod.TabIndex = 19;
            // 
            // txtTelefonoEmpMod
            // 
            this.txtTelefonoEmpMod.Location = new System.Drawing.Point(169, 251);
            this.txtTelefonoEmpMod.Name = "txtTelefonoEmpMod";
            this.txtTelefonoEmpMod.Size = new System.Drawing.Size(137, 20);
            this.txtTelefonoEmpMod.TabIndex = 13;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(33, 254);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(52, 13);
            this.label32.TabIndex = 12;
            this.label32.Tag = "newTelef";
            this.label32.Text = "Telefono:";
            // 
            // btnModificarEmp
            // 
            this.btnModificarEmp.Location = new System.Drawing.Point(364, 254);
            this.btnModificarEmp.Name = "btnModificarEmp";
            this.btnModificarEmp.Size = new System.Drawing.Size(87, 35);
            this.btnModificarEmp.TabIndex = 0;
            this.btnModificarEmp.Tag = "modify";
            this.btnModificarEmp.Text = "Modificar";
            this.btnModificarEmp.UseVisualStyleBackColor = true;
            this.btnModificarEmp.Click += new System.EventHandler(this.btnModificarEmp_Click);
            // 
            // txtDNIEmpMod
            // 
            this.txtDNIEmpMod.Location = new System.Drawing.Point(129, 196);
            this.txtDNIEmpMod.Name = "txtDNIEmpMod";
            this.txtDNIEmpMod.Size = new System.Drawing.Size(125, 20);
            this.txtDNIEmpMod.TabIndex = 11;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(33, 41);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(223, 13);
            this.label39.TabIndex = 4;
            this.label39.Tag = "modEmpExp";
            this.label39.Text = "Seleccione el Empleado que desea Modificar:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(33, 199);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 13);
            this.label40.TabIndex = 10;
            this.label40.Tag = "newDNI";
            this.label40.Text = "DNI:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(33, 90);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(47, 13);
            this.label41.TabIndex = 6;
            this.label41.Tag = "newName";
            this.label41.Text = "Nombre:";
            // 
            // txtApellidoEmpMod
            // 
            this.txtApellidoEmpMod.Location = new System.Drawing.Point(129, 140);
            this.txtApellidoEmpMod.Name = "txtApellidoEmpMod";
            this.txtApellidoEmpMod.Size = new System.Drawing.Size(125, 20);
            this.txtApellidoEmpMod.TabIndex = 9;
            // 
            // txtNameEmpMod
            // 
            this.txtNameEmpMod.Location = new System.Drawing.Point(129, 87);
            this.txtNameEmpMod.Name = "txtNameEmpMod";
            this.txtNameEmpMod.Size = new System.Drawing.Size(125, 20);
            this.txtNameEmpMod.TabIndex = 7;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(33, 143);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(47, 13);
            this.label42.TabIndex = 8;
            this.label42.Tag = "newApe";
            this.label42.Text = "Apellido:";
            // 
            // btnEliminarEmp
            // 
            this.btnEliminarEmp.Location = new System.Drawing.Point(291, 31);
            this.btnEliminarEmp.Name = "btnEliminarEmp";
            this.btnEliminarEmp.Size = new System.Drawing.Size(122, 23);
            this.btnEliminarEmp.TabIndex = 10;
            this.btnEliminarEmp.Tag = "enable";
            this.btnEliminarEmp.Text = "Eliminar";
            this.btnEliminarEmp.UseVisualStyleBackColor = true;
            this.btnEliminarEmp.Click += new System.EventHandler(this.btnEliminarEmp_Click);
            // 
            // btnActDataEmpleados
            // 
            this.btnActDataEmpleados.Location = new System.Drawing.Point(490, 31);
            this.btnActDataEmpleados.Name = "btnActDataEmpleados";
            this.btnActDataEmpleados.Size = new System.Drawing.Size(117, 23);
            this.btnActDataEmpleados.TabIndex = 10;
            this.btnActDataEmpleados.Tag = "update";
            this.btnActDataEmpleados.Text = "Actualizar y Mostrar";
            this.btnActDataEmpleados.UseVisualStyleBackColor = true;
            this.btnActDataEmpleados.Click += new System.EventHandler(this.btnActDataEmpleados_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtRolEmpReg);
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.comboTurnoEmpReg);
            this.groupBox10.Controls.Add(this.label26);
            this.groupBox10.Controls.Add(this.txtTelefonoEmpReg);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.btnRegistrarEmp);
            this.groupBox10.Controls.Add(this.txtCodEmpReg);
            this.groupBox10.Controls.Add(this.txtDNIEmpReg);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Controls.Add(this.label35);
            this.groupBox10.Controls.Add(this.txtApellidoEmpReg);
            this.groupBox10.Controls.Add(this.txtNameEmpReg);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Location = new System.Drawing.Point(631, 60);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(493, 318);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Tag = "regEmp";
            this.groupBox10.Text = "Registrar Empleado";
            // 
            // txtRolEmpReg
            // 
            this.txtRolEmpReg.Location = new System.Drawing.Point(340, 141);
            this.txtRolEmpReg.Name = "txtRolEmpReg";
            this.txtRolEmpReg.Size = new System.Drawing.Size(111, 20);
            this.txtRolEmpReg.TabIndex = 21;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(288, 144);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(26, 13);
            this.label30.TabIndex = 20;
            this.label30.Tag = "rol";
            this.label30.Text = "Rol:";
            // 
            // comboTurnoEmpReg
            // 
            this.comboTurnoEmpReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurnoEmpReg.FormattingEnabled = true;
            this.comboTurnoEmpReg.Items.AddRange(new object[] {
            "Mañana",
            "Tarde"});
            this.comboTurnoEmpReg.Location = new System.Drawing.Point(340, 96);
            this.comboTurnoEmpReg.Name = "comboTurnoEmpReg";
            this.comboTurnoEmpReg.Size = new System.Drawing.Size(111, 21);
            this.comboTurnoEmpReg.TabIndex = 15;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(276, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 13);
            this.label26.TabIndex = 14;
            this.label26.Tag = "turno";
            this.label26.Text = "Turno:";
            // 
            // txtTelefonoEmpReg
            // 
            this.txtTelefonoEmpReg.Location = new System.Drawing.Point(145, 240);
            this.txtTelefonoEmpReg.Name = "txtTelefonoEmpReg";
            this.txtTelefonoEmpReg.Size = new System.Drawing.Size(149, 20);
            this.txtTelefonoEmpReg.TabIndex = 13;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(31, 243);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 13);
            this.label38.TabIndex = 12;
            this.label38.Tag = "telefono";
            this.label38.Text = "Telefono:";
            // 
            // btnRegistrarEmp
            // 
            this.btnRegistrarEmp.Location = new System.Drawing.Point(364, 261);
            this.btnRegistrarEmp.Name = "btnRegistrarEmp";
            this.btnRegistrarEmp.Size = new System.Drawing.Size(87, 35);
            this.btnRegistrarEmp.TabIndex = 0;
            this.btnRegistrarEmp.Tag = "reg";
            this.btnRegistrarEmp.Text = "Registrar";
            this.btnRegistrarEmp.UseVisualStyleBackColor = true;
            this.btnRegistrarEmp.Click += new System.EventHandler(this.btnRegistrarEmp_Click);
            // 
            // txtCodEmpReg
            // 
            this.txtCodEmpReg.Location = new System.Drawing.Point(129, 40);
            this.txtCodEmpReg.Name = "txtCodEmpReg";
            this.txtCodEmpReg.Size = new System.Drawing.Size(111, 20);
            this.txtCodEmpReg.TabIndex = 1;
            // 
            // txtDNIEmpReg
            // 
            this.txtDNIEmpReg.Location = new System.Drawing.Point(115, 186);
            this.txtDNIEmpReg.Name = "txtDNIEmpReg";
            this.txtDNIEmpReg.Size = new System.Drawing.Size(125, 20);
            this.txtDNIEmpReg.TabIndex = 11;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(15, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(108, 13);
            this.label33.TabIndex = 4;
            this.label33.Tag = "codEmp";
            this.label33.Text = "Codigo de Empleado:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(43, 189);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 10;
            this.label37.Tag = "dni";
            this.label37.Text = "DNI:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(43, 97);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(47, 13);
            this.label35.TabIndex = 6;
            this.label35.Tag = "name";
            this.label35.Text = "Nombre:";
            // 
            // txtApellidoEmpReg
            // 
            this.txtApellidoEmpReg.Location = new System.Drawing.Point(115, 141);
            this.txtApellidoEmpReg.Name = "txtApellidoEmpReg";
            this.txtApellidoEmpReg.Size = new System.Drawing.Size(125, 20);
            this.txtApellidoEmpReg.TabIndex = 9;
            // 
            // txtNameEmpReg
            // 
            this.txtNameEmpReg.Location = new System.Drawing.Point(115, 97);
            this.txtNameEmpReg.Name = "txtNameEmpReg";
            this.txtNameEmpReg.Size = new System.Drawing.Size(125, 20);
            this.txtNameEmpReg.TabIndex = 7;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(43, 145);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(47, 13);
            this.label36.TabIndex = 8;
            this.label36.Tag = "ape";
            this.label36.Text = "Apellido:";
            // 
            // btnBuscarOneEmp
            // 
            this.btnBuscarOneEmp.Location = new System.Drawing.Point(505, 465);
            this.btnBuscarOneEmp.Name = "btnBuscarOneEmp";
            this.btnBuscarOneEmp.Size = new System.Drawing.Size(102, 24);
            this.btnBuscarOneEmp.TabIndex = 8;
            this.btnBuscarOneEmp.Tag = "search";
            this.btnBuscarOneEmp.Text = "Buscar";
            this.btnBuscarOneEmp.UseVisualStyleBackColor = true;
            this.btnBuscarOneEmp.Click += new System.EventHandler(this.btnBuscarOneEmp_Click);
            // 
            // txtNameEmpBuscar
            // 
            this.txtNameEmpBuscar.Location = new System.Drawing.Point(227, 465);
            this.txtNameEmpBuscar.Name = "txtNameEmpBuscar";
            this.txtNameEmpBuscar.Size = new System.Drawing.Size(186, 20);
            this.txtNameEmpBuscar.TabIndex = 7;
            // 
            // dataOneEmpleado
            // 
            this.dataOneEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataOneEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOneEmpleado.Location = new System.Drawing.Point(32, 500);
            this.dataOneEmpleado.Name = "dataOneEmpleado";
            this.dataOneEmpleado.ReadOnly = true;
            this.dataOneEmpleado.Size = new System.Drawing.Size(575, 96);
            this.dataOneEmpleado.TabIndex = 6;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(31, 467);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(178, 13);
            this.label34.TabIndex = 5;
            this.label34.Tag = "searchEmp";
            this.label34.Text = "Buscar un Empleado por su nombre:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(29, 36);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(111, 13);
            this.label31.TabIndex = 1;
            this.label31.Tag = "allEmp";
            this.label31.Text = "Todos los Empleados:";
            // 
            // dataEmpleados
            // 
            this.dataEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmpleados.Location = new System.Drawing.Point(32, 60);
            this.dataEmpleados.Name = "dataEmpleados";
            this.dataEmpleados.ReadOnly = true;
            this.dataEmpleados.Size = new System.Drawing.Size(575, 370);
            this.dataEmpleados.TabIndex = 0;
            this.dataEmpleados.SelectionChanged += new System.EventHandler(this.dataEmpleados_SelectionChanged);
            // 
            // tabPageDesempeño
            // 
            this.tabPageDesempeño.Controls.Add(this.label62);
            this.tabPageDesempeño.Controls.Add(this.btnEliminarBono);
            this.tabPageDesempeño.Controls.Add(this.dataTaskPerEmp);
            this.tabPageDesempeño.Controls.Add(this.btnActDataDesempEmp);
            this.tabPageDesempeño.Controls.Add(this.groupCrearBono);
            this.tabPageDesempeño.Controls.Add(this.label60);
            this.tabPageDesempeño.Controls.Add(this.dataDesempEmp);
            this.tabPageDesempeño.Controls.Add(this.btnActDataBono);
            this.tabPageDesempeño.Controls.Add(this.btnActDetalleTarea);
            this.tabPageDesempeño.Controls.Add(this.dataBonos);
            this.tabPageDesempeño.Controls.Add(this.label24);
            this.tabPageDesempeño.Controls.Add(this.dataDetalleTareas);
            this.tabPageDesempeño.Controls.Add(this.label23);
            this.tabPageDesempeño.Location = new System.Drawing.Point(4, 22);
            this.tabPageDesempeño.Name = "tabPageDesempeño";
            this.tabPageDesempeño.Size = new System.Drawing.Size(1165, 719);
            this.tabPageDesempeño.TabIndex = 3;
            this.tabPageDesempeño.Tag = "tabDesemp";
            this.tabPageDesempeño.Text = "Desempeño";
            this.tabPageDesempeño.UseVisualStyleBackColor = true;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(719, 420);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(164, 13);
            this.label62.TabIndex = 28;
            this.label62.Tag = "detailPerEmp";
            this.label62.Text = "Detalles de Tareas por Empleado";
            // 
            // btnEliminarBono
            // 
            this.btnEliminarBono.Location = new System.Drawing.Point(835, 22);
            this.btnEliminarBono.Name = "btnEliminarBono";
            this.btnEliminarBono.Size = new System.Drawing.Size(107, 23);
            this.btnEliminarBono.TabIndex = 25;
            this.btnEliminarBono.Tag = "enable";
            this.btnEliminarBono.Text = "Eliminar";
            this.btnEliminarBono.UseVisualStyleBackColor = true;
            this.btnEliminarBono.Click += new System.EventHandler(this.btnEliminarBono_Click);
            // 
            // dataTaskPerEmp
            // 
            this.dataTaskPerEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTaskPerEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTaskPerEmp.Location = new System.Drawing.Point(722, 445);
            this.dataTaskPerEmp.Name = "dataTaskPerEmp";
            this.dataTaskPerEmp.ReadOnly = true;
            this.dataTaskPerEmp.Size = new System.Drawing.Size(368, 240);
            this.dataTaskPerEmp.TabIndex = 27;
            // 
            // btnActDataDesempEmp
            // 
            this.btnActDataDesempEmp.Location = new System.Drawing.Point(571, 295);
            this.btnActDataDesempEmp.Name = "btnActDataDesempEmp";
            this.btnActDataDesempEmp.Size = new System.Drawing.Size(117, 23);
            this.btnActDataDesempEmp.TabIndex = 13;
            this.btnActDataDesempEmp.Tag = "update";
            this.btnActDataDesempEmp.Text = "Actualizar y Mostrar";
            this.btnActDataDesempEmp.UseVisualStyleBackColor = true;
            this.btnActDataDesempEmp.Click += new System.EventHandler(this.btnActDataDesempEmp_Click);
            // 
            // groupCrearBono
            // 
            this.groupCrearBono.Controls.Add(this.txtMinTareasBono);
            this.groupCrearBono.Controls.Add(this.label63);
            this.groupCrearBono.Controls.Add(this.btnAgregarBono);
            this.groupCrearBono.Controls.Add(this.txtMontoBono);
            this.groupCrearBono.Controls.Add(this.label29);
            this.groupCrearBono.Controls.Add(this.label3);
            this.groupCrearBono.Controls.Add(this.txtCategBono);
            this.groupCrearBono.Location = new System.Drawing.Point(722, 230);
            this.groupCrearBono.Name = "groupCrearBono";
            this.groupCrearBono.Size = new System.Drawing.Size(368, 179);
            this.groupCrearBono.TabIndex = 26;
            this.groupCrearBono.TabStop = false;
            this.groupCrearBono.Tag = "crearB";
            this.groupCrearBono.Text = "Crear Bono";
            // 
            // txtMinTareasBono
            // 
            this.txtMinTareasBono.Location = new System.Drawing.Point(131, 130);
            this.txtMinTareasBono.Name = "txtMinTareasBono";
            this.txtMinTareasBono.Size = new System.Drawing.Size(99, 20);
            this.txtMinTareasBono.TabIndex = 21;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(33, 126);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(48, 26);
            this.label63.TabIndex = 22;
            this.label63.Tag = "minTask";
            this.label63.Text = "Tareas \r\nMinimas:";
            // 
            // btnAgregarBono
            // 
            this.btnAgregarBono.Location = new System.Drawing.Point(283, 120);
            this.btnAgregarBono.Name = "btnAgregarBono";
            this.btnAgregarBono.Size = new System.Drawing.Size(66, 38);
            this.btnAgregarBono.TabIndex = 0;
            this.btnAgregarBono.Tag = "create";
            this.btnAgregarBono.Text = "Crear";
            this.btnAgregarBono.UseVisualStyleBackColor = true;
            this.btnAgregarBono.Click += new System.EventHandler(this.btnAgregarBono_Click);
            // 
            // txtMontoBono
            // 
            this.txtMontoBono.Location = new System.Drawing.Point(131, 83);
            this.txtMontoBono.Name = "txtMontoBono";
            this.txtMontoBono.Size = new System.Drawing.Size(99, 20);
            this.txtMontoBono.TabIndex = 20;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(70, 86);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 13);
            this.label29.TabIndex = 21;
            this.label29.Tag = "amount";
            this.label29.Text = "Monto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 19;
            this.label3.Tag = "cat";
            this.label3.Text = "Categoria:";
            // 
            // txtCategBono
            // 
            this.txtCategBono.Location = new System.Drawing.Point(131, 39);
            this.txtCategBono.Name = "txtCategBono";
            this.txtCategBono.Size = new System.Drawing.Size(99, 20);
            this.txtCategBono.TabIndex = 18;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(40, 297);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(158, 13);
            this.label60.TabIndex = 12;
            this.label60.Tag = "perform";
            this.label60.Text = "Desempeños de los  Empleados";
            // 
            // dataDesempEmp
            // 
            this.dataDesempEmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDesempEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDesempEmp.Location = new System.Drawing.Point(43, 324);
            this.dataDesempEmp.Name = "dataDesempEmp";
            this.dataDesempEmp.ReadOnly = true;
            this.dataDesempEmp.Size = new System.Drawing.Size(645, 361);
            this.dataDesempEmp.TabIndex = 11;
            this.dataDesempEmp.SelectionChanged += new System.EventHandler(this.dataDesempEmp_SelectionChanged);
            // 
            // btnActDataBono
            // 
            this.btnActDataBono.Location = new System.Drawing.Point(973, 22);
            this.btnActDataBono.Name = "btnActDataBono";
            this.btnActDataBono.Size = new System.Drawing.Size(117, 23);
            this.btnActDataBono.TabIndex = 10;
            this.btnActDataBono.Tag = "update";
            this.btnActDataBono.Text = "Actualizar y Mostrar";
            this.btnActDataBono.UseVisualStyleBackColor = true;
            this.btnActDataBono.Click += new System.EventHandler(this.btnActDataBono_Click);
            // 
            // btnActDetalleTarea
            // 
            this.btnActDetalleTarea.Location = new System.Drawing.Point(571, 23);
            this.btnActDetalleTarea.Name = "btnActDetalleTarea";
            this.btnActDetalleTarea.Size = new System.Drawing.Size(117, 23);
            this.btnActDetalleTarea.TabIndex = 9;
            this.btnActDetalleTarea.Tag = "update";
            this.btnActDetalleTarea.Text = "Actualizar y Mostrar";
            this.btnActDetalleTarea.UseVisualStyleBackColor = true;
            this.btnActDetalleTarea.Click += new System.EventHandler(this.btnActDetalleTarea_Click);
            // 
            // dataBonos
            // 
            this.dataBonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBonos.Location = new System.Drawing.Point(722, 52);
            this.dataBonos.Name = "dataBonos";
            this.dataBonos.ReadOnly = true;
            this.dataBonos.Size = new System.Drawing.Size(368, 172);
            this.dataBonos.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(719, 28);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 2;
            this.label24.Tag = "bonos";
            this.label24.Text = "Bonos:";
            // 
            // dataDetalleTareas
            // 
            this.dataDetalleTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDetalleTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetalleTareas.Location = new System.Drawing.Point(43, 52);
            this.dataDetalleTareas.Name = "dataDetalleTareas";
            this.dataDetalleTareas.ReadOnly = true;
            this.dataDetalleTareas.Size = new System.Drawing.Size(645, 212);
            this.dataDetalleTareas.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(40, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 13);
            this.label23.TabIndex = 0;
            this.label23.Tag = "allTaskDetail";
            this.label23.Text = "Detalles de Tareas:";
            // 
            // tabPageClientes
            // 
            this.tabPageClientes.Controls.Add(this.btnEliminarCliente);
            this.tabPageClientes.Controls.Add(this.btnActDataClientes);
            this.tabPageClientes.Controls.Add(this.btnBuscarCliente);
            this.tabPageClientes.Controls.Add(this.dataALLClientes);
            this.tabPageClientes.Controls.Add(this.label21);
            this.tabPageClientes.Controls.Add(this.groupBox5);
            this.tabPageClientes.Controls.Add(this.txtDNIBuscarCliente);
            this.tabPageClientes.Controls.Add(this.label17);
            this.tabPageClientes.Controls.Add(this.label16);
            this.tabPageClientes.Controls.Add(this.groupBox4);
            this.tabPageClientes.Controls.Add(this.dataOneCliente);
            this.tabPageClientes.Location = new System.Drawing.Point(4, 22);
            this.tabPageClientes.Name = "tabPageClientes";
            this.tabPageClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClientes.Size = new System.Drawing.Size(1165, 719);
            this.tabPageClientes.TabIndex = 2;
            this.tabPageClientes.Tag = "tabClient";
            this.tabPageClientes.Text = "Clientes";
            this.tabPageClientes.UseVisualStyleBackColor = true;
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Location = new System.Drawing.Point(796, 243);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(128, 33);
            this.btnEliminarCliente.TabIndex = 1;
            this.btnEliminarCliente.Tag = "enable";
            this.btnEliminarCliente.Text = "Deshabilitar Cliente";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // btnActDataClientes
            // 
            this.btnActDataClientes.Location = new System.Drawing.Point(951, 246);
            this.btnActDataClientes.Name = "btnActDataClientes";
            this.btnActDataClientes.Size = new System.Drawing.Size(117, 30);
            this.btnActDataClientes.TabIndex = 11;
            this.btnActDataClientes.Tag = "update";
            this.btnActDataClientes.Text = "Actualizar y Mostrar";
            this.btnActDataClientes.UseVisualStyleBackColor = true;
            this.btnActDataClientes.Click += new System.EventHandler(this.btnActDataClientes_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(967, 49);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(101, 33);
            this.btnBuscarCliente.TabIndex = 9;
            this.btnBuscarCliente.Tag = "searchCli";
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // dataALLClientes
            // 
            this.dataALLClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataALLClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataALLClientes.Location = new System.Drawing.Point(504, 290);
            this.dataALLClientes.Name = "dataALLClientes";
            this.dataALLClientes.ReadOnly = true;
            this.dataALLClientes.Size = new System.Drawing.Size(564, 361);
            this.dataALLClientes.TabIndex = 8;
            this.dataALLClientes.SelectionChanged += new System.EventHandler(this.dataALLClientes_SelectionChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(501, 263);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 13);
            this.label21.TabIndex = 7;
            this.label21.Tag = "allCli";
            this.label21.Text = "Ver Todos los Clientes:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.txtDNIModCliente);
            this.groupBox5.Controls.Add(this.btnModificarCliente);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.txtApellidoModCliente);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.txtNameModCliente);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Location = new System.Drawing.Point(52, 369);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(401, 282);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "modCli";
            this.groupBox5.Text = "Modificar Cliente";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(40, 46);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(153, 13);
            this.label27.TabIndex = 11;
            this.label27.Tag = "selectCliMod";
            this.label27.Text = "Seleccione Cliente a Modificar:\r\n";
            // 
            // txtDNIModCliente
            // 
            this.txtDNIModCliente.Location = new System.Drawing.Point(153, 193);
            this.txtDNIModCliente.Name = "txtDNIModCliente";
            this.txtDNIModCliente.Size = new System.Drawing.Size(144, 20);
            this.txtDNIModCliente.TabIndex = 5;
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Location = new System.Drawing.Point(266, 229);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(101, 33);
            this.btnModificarCliente.TabIndex = 1;
            this.btnModificarCliente.Tag = "modCli";
            this.btnModificarCliente.Text = "Modificar Cliente";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 187);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 26);
            this.label18.TabIndex = 4;
            this.label18.Tag = "newDNI";
            this.label18.Text = "Nuevo\r\nDNI:\r\n";
            // 
            // txtApellidoModCliente
            // 
            this.txtApellidoModCliente.Location = new System.Drawing.Point(153, 140);
            this.txtApellidoModCliente.Name = "txtApellidoModCliente";
            this.txtApellidoModCliente.Size = new System.Drawing.Size(144, 20);
            this.txtApellidoModCliente.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(40, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 26);
            this.label19.TabIndex = 2;
            this.label19.Tag = "newApe";
            this.label19.Text = "Nuevo \r\nApellido:";
            // 
            // txtNameModCliente
            // 
            this.txtNameModCliente.Location = new System.Drawing.Point(153, 93);
            this.txtNameModCliente.Name = "txtNameModCliente";
            this.txtNameModCliente.Size = new System.Drawing.Size(144, 20);
            this.txtNameModCliente.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(40, 87);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 26);
            this.label20.TabIndex = 0;
            this.label20.Tag = "newName";
            this.label20.Text = "Nuevo\r\nNombre:\r\n";
            // 
            // txtDNIBuscarCliente
            // 
            this.txtDNIBuscarCliente.Location = new System.Drawing.Point(594, 62);
            this.txtDNIBuscarCliente.Name = "txtDNIBuscarCliente";
            this.txtDNIBuscarCliente.Size = new System.Drawing.Size(167, 20);
            this.txtDNIBuscarCliente.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(501, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 4;
            this.label17.Tag = "enterDNI";
            this.label17.Text = "Ingrese el DNI:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(498, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 3;
            this.label16.Tag = "searchCli";
            this.label16.Text = "Buscar Cliente:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDNIRegCliente);
            this.groupBox4.Controls.Add(this.btnRegistrarCliente);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtApellidoRegCliente);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtNameRegCliente);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(52, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(401, 248);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "registerCli";
            this.groupBox4.Text = "Registrar Cliente";
            // 
            // txtDNIRegCliente
            // 
            this.txtDNIRegCliente.Location = new System.Drawing.Point(141, 146);
            this.txtDNIRegCliente.Name = "txtDNIRegCliente";
            this.txtDNIRegCliente.Size = new System.Drawing.Size(137, 20);
            this.txtDNIRegCliente.TabIndex = 5;
            // 
            // btnRegistrarCliente
            // 
            this.btnRegistrarCliente.Location = new System.Drawing.Point(266, 190);
            this.btnRegistrarCliente.Name = "btnRegistrarCliente";
            this.btnRegistrarCliente.Size = new System.Drawing.Size(101, 33);
            this.btnRegistrarCliente.TabIndex = 1;
            this.btnRegistrarCliente.Tag = "regCli";
            this.btnRegistrarCliente.Text = "Registrar Cliente";
            this.btnRegistrarCliente.UseVisualStyleBackColor = true;
            this.btnRegistrarCliente.Click += new System.EventHandler(this.btnRegistrarCliente_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(46, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 4;
            this.label15.Tag = "dni";
            this.label15.Text = "DNI:";
            // 
            // txtApellidoRegCliente
            // 
            this.txtApellidoRegCliente.Location = new System.Drawing.Point(141, 94);
            this.txtApellidoRegCliente.Name = "txtApellidoRegCliente";
            this.txtApellidoRegCliente.Size = new System.Drawing.Size(137, 20);
            this.txtApellidoRegCliente.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 2;
            this.label14.Tag = "ape";
            this.label14.Text = "Apellido:";
            // 
            // txtNameRegCliente
            // 
            this.txtNameRegCliente.Location = new System.Drawing.Point(141, 46);
            this.txtNameRegCliente.Name = "txtNameRegCliente";
            this.txtNameRegCliente.Size = new System.Drawing.Size(137, 20);
            this.txtNameRegCliente.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 0;
            this.label13.Tag = "name";
            this.label13.Text = "Nombre:";
            // 
            // dataOneCliente
            // 
            this.dataOneCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataOneCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOneCliente.Location = new System.Drawing.Point(501, 94);
            this.dataOneCliente.Name = "dataOneCliente";
            this.dataOneCliente.ReadOnly = true;
            this.dataOneCliente.Size = new System.Drawing.Size(567, 89);
            this.dataOneCliente.TabIndex = 0;
            // 
            // tabPageTareas
            // 
            this.tabPageTareas.Controls.Add(this.btnActDataTareas);
            this.tabPageTareas.Controls.Add(this.btnEliminarTarea);
            this.tabPageTareas.Controls.Add(this.groupCrearTarea);
            this.tabPageTareas.Controls.Add(this.groupProcesarTarea);
            this.tabPageTareas.Controls.Add(this.labelAllTareas);
            this.tabPageTareas.Controls.Add(this.dataTareas);
            this.tabPageTareas.Location = new System.Drawing.Point(4, 22);
            this.tabPageTareas.Name = "tabPageTareas";
            this.tabPageTareas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTareas.Size = new System.Drawing.Size(1165, 719);
            this.tabPageTareas.TabIndex = 1;
            this.tabPageTareas.Tag = "tabTareas";
            this.tabPageTareas.Text = "Tareas";
            this.tabPageTareas.UseVisualStyleBackColor = true;
            // 
            // btnActDataTareas
            // 
            this.btnActDataTareas.Location = new System.Drawing.Point(894, 30);
            this.btnActDataTareas.Name = "btnActDataTareas";
            this.btnActDataTareas.Size = new System.Drawing.Size(117, 32);
            this.btnActDataTareas.TabIndex = 8;
            this.btnActDataTareas.Tag = "update";
            this.btnActDataTareas.Text = "Actualizar y Mostrar";
            this.btnActDataTareas.UseVisualStyleBackColor = true;
            this.btnActDataTareas.Click += new System.EventHandler(this.btnActDataTareas_Click);
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.Location = new System.Drawing.Point(745, 29);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(105, 33);
            this.btnEliminarTarea.TabIndex = 0;
            this.btnEliminarTarea.Tag = "enable";
            this.btnEliminarTarea.Text = "Eliminar";
            this.btnEliminarTarea.UseVisualStyleBackColor = true;
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // groupCrearTarea
            // 
            this.groupCrearTarea.Controls.Add(this.txtDescpTareaCrear);
            this.groupCrearTarea.Controls.Add(this.txtNameTareaCrear);
            this.groupCrearTarea.Controls.Add(this.label5);
            this.groupCrearTarea.Controls.Add(this.btnCrearTarea);
            this.groupCrearTarea.Controls.Add(this.label11);
            this.groupCrearTarea.Location = new System.Drawing.Point(85, 325);
            this.groupCrearTarea.Name = "groupCrearTarea";
            this.groupCrearTarea.Size = new System.Drawing.Size(435, 248);
            this.groupCrearTarea.TabIndex = 9;
            this.groupCrearTarea.TabStop = false;
            this.groupCrearTarea.Tag = "crearT";
            this.groupCrearTarea.Text = "Crear Tarea";
            // 
            // txtDescpTareaCrear
            // 
            this.txtDescpTareaCrear.Location = new System.Drawing.Point(25, 159);
            this.txtDescpTareaCrear.Name = "txtDescpTareaCrear";
            this.txtDescpTareaCrear.Size = new System.Drawing.Size(382, 20);
            this.txtDescpTareaCrear.TabIndex = 10;
            // 
            // txtNameTareaCrear
            // 
            this.txtNameTareaCrear.Location = new System.Drawing.Point(25, 74);
            this.txtNameTareaCrear.Name = "txtNameTareaCrear";
            this.txtNameTareaCrear.Size = new System.Drawing.Size(193, 20);
            this.txtNameTareaCrear.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 6;
            this.label5.Tag = "descrpT";
            this.label5.Text = "Descripcion o Instrucciones:";
            // 
            // btnCrearTarea
            // 
            this.btnCrearTarea.Location = new System.Drawing.Point(313, 201);
            this.btnCrearTarea.Name = "btnCrearTarea";
            this.btnCrearTarea.Size = new System.Drawing.Size(94, 30);
            this.btnCrearTarea.TabIndex = 0;
            this.btnCrearTarea.Tag = "crearT";
            this.btnCrearTarea.Text = "Crear";
            this.btnCrearTarea.UseVisualStyleBackColor = true;
            this.btnCrearTarea.Click += new System.EventHandler(this.btnCrearTarea_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 5;
            this.label11.Tag = "nameT";
            this.label11.Text = "Nombre de la Tarea:";
            // 
            // groupProcesarTarea
            // 
            this.groupProcesarTarea.Controls.Add(this.btnBorrar);
            this.groupProcesarTarea.Controls.Add(this.btn0);
            this.groupProcesarTarea.Controls.Add(this.btn3);
            this.groupProcesarTarea.Controls.Add(this.btn2);
            this.groupProcesarTarea.Controls.Add(this.btn1);
            this.groupProcesarTarea.Controls.Add(this.btn6);
            this.groupProcesarTarea.Controls.Add(this.btn5);
            this.groupProcesarTarea.Controls.Add(this.btn4);
            this.groupProcesarTarea.Controls.Add(this.btn9);
            this.groupProcesarTarea.Controls.Add(this.btn8);
            this.groupProcesarTarea.Controls.Add(this.btn7);
            this.groupProcesarTarea.Controls.Add(this.txtCodEmpDoTarea);
            this.groupProcesarTarea.Controls.Add(this.btnTerminarTarea);
            this.groupProcesarTarea.Controls.Add(this.label7);
            this.groupProcesarTarea.Controls.Add(this.btnHacerTarea);
            this.groupProcesarTarea.Location = new System.Drawing.Point(555, 325);
            this.groupProcesarTarea.Name = "groupProcesarTarea";
            this.groupProcesarTarea.Size = new System.Drawing.Size(493, 248);
            this.groupProcesarTarea.TabIndex = 8;
            this.groupProcesarTarea.TabStop = false;
            this.groupProcesarTarea.Tag = "doT";
            this.groupProcesarTarea.Text = "Hacer Tarea";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(279, 44);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(68, 38);
            this.btnBorrar.TabIndex = 11;
            this.btnBorrar.Text = "⌫";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(214, 100);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(45, 113);
            this.btn0.TabIndex = 17;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(161, 177);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(47, 36);
            this.btn3.TabIndex = 16;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(108, 177);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(47, 36);
            this.btn2.TabIndex = 15;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(55, 177);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(47, 36);
            this.btn1.TabIndex = 14;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(161, 138);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(47, 36);
            this.btn6.TabIndex = 13;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(108, 138);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(47, 36);
            this.btn5.TabIndex = 12;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(55, 138);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(47, 36);
            this.btn4.TabIndex = 11;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(161, 100);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(47, 36);
            this.btn9.TabIndex = 10;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(108, 100);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(47, 36);
            this.btn8.TabIndex = 9;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(55, 99);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(47, 36);
            this.btn7.TabIndex = 8;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btnNumerico_Click);
            // 
            // txtCodEmpDoTarea
            // 
            this.txtCodEmpDoTarea.Location = new System.Drawing.Point(137, 54);
            this.txtCodEmpDoTarea.Name = "txtCodEmpDoTarea";
            this.txtCodEmpDoTarea.Size = new System.Drawing.Size(122, 20);
            this.txtCodEmpDoTarea.TabIndex = 7;
            // 
            // btnTerminarTarea
            // 
            this.btnTerminarTarea.Location = new System.Drawing.Point(373, 174);
            this.btnTerminarTarea.Name = "btnTerminarTarea";
            this.btnTerminarTarea.Size = new System.Drawing.Size(81, 43);
            this.btnTerminarTarea.TabIndex = 0;
            this.btnTerminarTarea.Tag = "end";
            this.btnTerminarTarea.Text = "Terminar";
            this.btnTerminarTarea.UseVisualStyleBackColor = true;
            this.btnTerminarTarea.Click += new System.EventHandler(this.btnTerminarTarea_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 6;
            this.label7.Tag = "codEmp";
            this.label7.Text = "Codigo Empleado:";
            // 
            // btnHacerTarea
            // 
            this.btnHacerTarea.Location = new System.Drawing.Point(373, 104);
            this.btnHacerTarea.Name = "btnHacerTarea";
            this.btnHacerTarea.Size = new System.Drawing.Size(81, 41);
            this.btnHacerTarea.TabIndex = 0;
            this.btnHacerTarea.Tag = "do";
            this.btnHacerTarea.Text = "Hacer";
            this.btnHacerTarea.UseVisualStyleBackColor = true;
            this.btnHacerTarea.Click += new System.EventHandler(this.btnHacerTarea_Click);
            // 
            // labelAllTareas
            // 
            this.labelAllTareas.AutoSize = true;
            this.labelAllTareas.Location = new System.Drawing.Point(125, 40);
            this.labelAllTareas.Name = "labelAllTareas";
            this.labelAllTareas.Size = new System.Drawing.Size(92, 13);
            this.labelAllTareas.TabIndex = 2;
            this.labelAllTareas.Tag = "allHW";
            this.labelAllTareas.Text = "Todas las Tareas:";
            // 
            // dataTareas
            // 
            this.dataTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTareas.Location = new System.Drawing.Point(128, 68);
            this.dataTareas.Name = "dataTareas";
            this.dataTareas.ReadOnly = true;
            this.dataTareas.Size = new System.Drawing.Size(881, 239);
            this.dataTareas.TabIndex = 1;
            // 
            // tabPagePedidos
            // 
            this.tabPagePedidos.Controls.Add(this.btnBorrarSeleccion);
            this.tabPagePedidos.Controls.Add(this.txtCantProdu);
            this.tabPagePedidos.Controls.Add(this.btnMasProdu);
            this.tabPagePedidos.Controls.Add(this.btnMenosProdu);
            this.tabPagePedidos.Controls.Add(this.btnEliminarProduDetalles);
            this.tabPagePedidos.Controls.Add(this.dataDetallesMomentum);
            this.tabPagePedidos.Controls.Add(this.groupCancelarPedido);
            this.tabPagePedidos.Controls.Add(this.groupProcesarPedido);
            this.tabPagePedidos.Controls.Add(this.groupManejoPedidos);
            this.tabPagePedidos.Controls.Add(this.labelDetallePedidos);
            this.tabPagePedidos.Controls.Add(this.dataPedidos);
            this.tabPagePedidos.Controls.Add(this.labelAllPedidos);
            this.tabPagePedidos.Location = new System.Drawing.Point(4, 22);
            this.tabPagePedidos.Name = "tabPagePedidos";
            this.tabPagePedidos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePedidos.Size = new System.Drawing.Size(1165, 719);
            this.tabPagePedidos.TabIndex = 0;
            this.tabPagePedidos.Tag = "tabPed";
            this.tabPagePedidos.Text = "Pedidos";
            this.tabPagePedidos.UseVisualStyleBackColor = true;
            // 
            // btnBorrarSeleccion
            // 
            this.btnBorrarSeleccion.Location = new System.Drawing.Point(1037, 19);
            this.btnBorrarSeleccion.Name = "btnBorrarSeleccion";
            this.btnBorrarSeleccion.Size = new System.Drawing.Size(99, 24);
            this.btnBorrarSeleccion.TabIndex = 44;
            this.btnBorrarSeleccion.Tag = "clearSelection";
            this.btnBorrarSeleccion.Text = "Borrar Seleccion";
            this.btnBorrarSeleccion.UseVisualStyleBackColor = true;
            this.btnBorrarSeleccion.Click += new System.EventHandler(this.btnBorrarSeleccion_Click);
            // 
            // txtCantProdu
            // 
            this.txtCantProdu.Location = new System.Drawing.Point(139, 264);
            this.txtCantProdu.Name = "txtCantProdu";
            this.txtCantProdu.Size = new System.Drawing.Size(43, 20);
            this.txtCantProdu.TabIndex = 43;
            this.txtCantProdu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantProdu_KeyDown);
            // 
            // btnMasProdu
            // 
            this.btnMasProdu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasProdu.Location = new System.Drawing.Point(88, 262);
            this.btnMasProdu.Name = "btnMasProdu";
            this.btnMasProdu.Size = new System.Drawing.Size(35, 23);
            this.btnMasProdu.TabIndex = 42;
            this.btnMasProdu.Text = "+";
            this.btnMasProdu.UseVisualStyleBackColor = true;
            this.btnMasProdu.Click += new System.EventHandler(this.btnMasProdu_Click);
            // 
            // btnMenosProdu
            // 
            this.btnMenosProdu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosProdu.Location = new System.Drawing.Point(36, 261);
            this.btnMenosProdu.Name = "btnMenosProdu";
            this.btnMenosProdu.Size = new System.Drawing.Size(36, 24);
            this.btnMenosProdu.TabIndex = 41;
            this.btnMenosProdu.Text = "-";
            this.btnMenosProdu.UseVisualStyleBackColor = true;
            this.btnMenosProdu.Click += new System.EventHandler(this.btnMenosProdu_Click);
            // 
            // btnEliminarProduDetalles
            // 
            this.btnEliminarProduDetalles.Location = new System.Drawing.Point(200, 264);
            this.btnEliminarProduDetalles.Name = "btnEliminarProduDetalles";
            this.btnEliminarProduDetalles.Size = new System.Drawing.Size(104, 21);
            this.btnEliminarProduDetalles.TabIndex = 40;
            this.btnEliminarProduDetalles.Tag = "deleteDet";
            this.btnEliminarProduDetalles.Text = "Eliminar Producto";
            this.btnEliminarProduDetalles.UseVisualStyleBackColor = true;
            this.btnEliminarProduDetalles.Click += new System.EventHandler(this.btnEliminarProduDetalles_Click);
            // 
            // dataDetallesMomentum
            // 
            this.dataDetallesMomentum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDetallesMomentum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetallesMomentum.Location = new System.Drawing.Point(36, 49);
            this.dataDetallesMomentum.Name = "dataDetallesMomentum";
            this.dataDetallesMomentum.ReadOnly = true;
            this.dataDetallesMomentum.Size = new System.Drawing.Size(268, 196);
            this.dataDetallesMomentum.TabIndex = 32;
            this.dataDetallesMomentum.SelectionChanged += new System.EventHandler(this.dataDetallesMomentum_SelectionChanged);
            // 
            // groupCancelarPedido
            // 
            this.groupCancelarPedido.Controls.Add(this.label22);
            this.groupCancelarPedido.Controls.Add(this.btnCancelPedido);
            this.groupCancelarPedido.Location = new System.Drawing.Point(556, 585);
            this.groupCancelarPedido.Name = "groupCancelarPedido";
            this.groupCancelarPedido.Size = new System.Drawing.Size(580, 92);
            this.groupCancelarPedido.TabIndex = 31;
            this.groupCancelarPedido.TabStop = false;
            this.groupCancelarPedido.Tag = "cancel";
            this.groupCancelarPedido.Text = "Cancelaciones";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(49, 46);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(296, 13);
            this.label22.TabIndex = 37;
            this.label22.Tag = "expCancel";
            this.label22.Text = "Seleccione el Pedido a cancelar por pantalla, luego presione:";
            // 
            // btnCancelPedido
            // 
            this.btnCancelPedido.Location = new System.Drawing.Point(418, 32);
            this.btnCancelPedido.Name = "btnCancelPedido";
            this.btnCancelPedido.Size = new System.Drawing.Size(110, 40);
            this.btnCancelPedido.TabIndex = 8;
            this.btnCancelPedido.Tag = "cancelPed";
            this.btnCancelPedido.Text = "Cancelar Pedido";
            this.btnCancelPedido.UseVisualStyleBackColor = true;
            this.btnCancelPedido.Click += new System.EventHandler(this.btnCancelPedido_Click);
            // 
            // groupProcesarPedido
            // 
            this.groupProcesarPedido.BackColor = System.Drawing.Color.Transparent;
            this.groupProcesarPedido.Controls.Add(this.btnBorrarP);
            this.groupProcesarPedido.Controls.Add(this.button2);
            this.groupProcesarPedido.Controls.Add(this.button3);
            this.groupProcesarPedido.Controls.Add(this.button4);
            this.groupProcesarPedido.Controls.Add(this.button5);
            this.groupProcesarPedido.Controls.Add(this.button6);
            this.groupProcesarPedido.Controls.Add(this.button7);
            this.groupProcesarPedido.Controls.Add(this.button8);
            this.groupProcesarPedido.Controls.Add(this.button9);
            this.groupProcesarPedido.Controls.Add(this.button10);
            this.groupProcesarPedido.Controls.Add(this.button11);
            this.groupProcesarPedido.Controls.Add(this.txtCodEMPPedido);
            this.groupProcesarPedido.Controls.Add(this.label6);
            this.groupProcesarPedido.Controls.Add(this.btnHacerPedido);
            this.groupProcesarPedido.Controls.Add(this.btnFinPedido);
            this.groupProcesarPedido.Location = new System.Drawing.Point(556, 324);
            this.groupProcesarPedido.Name = "groupProcesarPedido";
            this.groupProcesarPedido.Size = new System.Drawing.Size(580, 255);
            this.groupProcesarPedido.TabIndex = 21;
            this.groupProcesarPedido.TabStop = false;
            this.groupProcesarPedido.Tag = "preparePed";
            this.groupProcesarPedido.Text = "Preparar Pedidos";
            // 
            // btnBorrarP
            // 
            this.btnBorrarP.Location = new System.Drawing.Point(279, 39);
            this.btnBorrarP.Name = "btnBorrarP";
            this.btnBorrarP.Size = new System.Drawing.Size(54, 33);
            this.btnBorrarP.TabIndex = 39;
            this.btnBorrarP.Text = "⌫";
            this.btnBorrarP.UseVisualStyleBackColor = true;
            this.btnBorrarP.Click += new System.EventHandler(this.btnBorrarP_Click1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 136);
            this.button2.TabIndex = 46;
            this.button2.Text = "0";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(160, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 39);
            this.button3.TabIndex = 45;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(104, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 39);
            this.button4.TabIndex = 44;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(48, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 39);
            this.button5.TabIndex = 43;
            this.button5.Text = "1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(160, 141);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 39);
            this.button6.TabIndex = 42;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(104, 141);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 39);
            this.button7.TabIndex = 41;
            this.button7.Text = "5";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(48, 141);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 39);
            this.button8.TabIndex = 40;
            this.button8.Text = "4";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(160, 90);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 39);
            this.button9.TabIndex = 38;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(104, 90);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 39);
            this.button10.TabIndex = 37;
            this.button10.Text = "8";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(48, 90);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 39);
            this.button11.TabIndex = 36;
            this.button11.Text = "7";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btnNumericoP_Click);
            // 
            // txtCodEMPPedido
            // 
            this.txtCodEMPPedido.Location = new System.Drawing.Point(137, 46);
            this.txtCodEMPPedido.Name = "txtCodEMPPedido";
            this.txtCodEMPPedido.Size = new System.Drawing.Size(122, 20);
            this.txtCodEMPPedido.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 34;
            this.label6.Tag = "codEmp";
            this.label6.Text = "Codigo Empleado:";
            // 
            // btnHacerPedido
            // 
            this.btnHacerPedido.Location = new System.Drawing.Point(409, 87);
            this.btnHacerPedido.Name = "btnHacerPedido";
            this.btnHacerPedido.Size = new System.Drawing.Size(88, 42);
            this.btnHacerPedido.TabIndex = 11;
            this.btnHacerPedido.Tag = "prep";
            this.btnHacerPedido.Text = "PREPARAR";
            this.btnHacerPedido.UseVisualStyleBackColor = true;
            this.btnHacerPedido.Click += new System.EventHandler(this.btnHacerPedido_Click);
            // 
            // btnFinPedido
            // 
            this.btnFinPedido.Location = new System.Drawing.Point(409, 183);
            this.btnFinPedido.Name = "btnFinPedido";
            this.btnFinPedido.Size = new System.Drawing.Size(88, 38);
            this.btnFinPedido.TabIndex = 18;
            this.btnFinPedido.Tag = "end";
            this.btnFinPedido.Text = "FINALIZAR";
            this.btnFinPedido.UseVisualStyleBackColor = true;
            this.btnFinPedido.Click += new System.EventHandler(this.btnFinPedido_Click);
            // 
            // groupManejoPedidos
            // 
            this.groupManejoPedidos.Controls.Add(this.btnMenosFood);
            this.groupManejoPedidos.Controls.Add(this.btnMenosDrink);
            this.groupManejoPedidos.Controls.Add(this.btnMasFood);
            this.groupManejoPedidos.Controls.Add(this.btnMasDrink);
            this.groupManejoPedidos.Controls.Add(this.label9);
            this.groupManejoPedidos.Controls.Add(this.txtDNIped);
            this.groupManejoPedidos.Controls.Add(this.label45);
            this.groupManejoPedidos.Controls.Add(this.btnAddComida);
            this.groupManejoPedidos.Controls.Add(this.label25);
            this.groupManejoPedidos.Controls.Add(this.btnAddBebida);
            this.groupManejoPedidos.Controls.Add(this.txtCantC);
            this.groupManejoPedidos.Controls.Add(this.label10);
            this.groupManejoPedidos.Controls.Add(this.label44);
            this.groupManejoPedidos.Controls.Add(this.txtCantB);
            this.groupManejoPedidos.Controls.Add(this.comboComidas);
            this.groupManejoPedidos.Controls.Add(this.label2);
            this.groupManejoPedidos.Controls.Add(this.comboBebidas);
            this.groupManejoPedidos.Controls.Add(this.btnAddPedido);
            this.groupManejoPedidos.Location = new System.Drawing.Point(25, 317);
            this.groupManejoPedidos.Name = "groupManejoPedidos";
            this.groupManejoPedidos.Size = new System.Drawing.Size(503, 360);
            this.groupManejoPedidos.TabIndex = 20;
            this.groupManejoPedidos.TabStop = false;
            this.groupManejoPedidos.Tag = "registerPed";
            this.groupManejoPedidos.Text = "Registrar Pedido";
            // 
            // btnMenosFood
            // 
            this.btnMenosFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosFood.Location = new System.Drawing.Point(232, 179);
            this.btnMenosFood.Name = "btnMenosFood";
            this.btnMenosFood.Size = new System.Drawing.Size(37, 23);
            this.btnMenosFood.TabIndex = 36;
            this.btnMenosFood.Text = "-";
            this.btnMenosFood.UseVisualStyleBackColor = true;
            this.btnMenosFood.Click += new System.EventHandler(this.btnMenosFood_Click);
            // 
            // btnMenosDrink
            // 
            this.btnMenosDrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosDrink.Location = new System.Drawing.Point(231, 79);
            this.btnMenosDrink.Name = "btnMenosDrink";
            this.btnMenosDrink.Size = new System.Drawing.Size(37, 23);
            this.btnMenosDrink.TabIndex = 33;
            this.btnMenosDrink.Text = "-";
            this.btnMenosDrink.UseVisualStyleBackColor = true;
            this.btnMenosDrink.Click += new System.EventHandler(this.btnMenosDrink_Click);
            // 
            // btnMasFood
            // 
            this.btnMasFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasFood.Location = new System.Drawing.Point(285, 180);
            this.btnMasFood.Name = "btnMasFood";
            this.btnMasFood.Size = new System.Drawing.Size(36, 22);
            this.btnMasFood.TabIndex = 35;
            this.btnMasFood.Text = "+";
            this.btnMasFood.UseVisualStyleBackColor = true;
            this.btnMasFood.Click += new System.EventHandler(this.btnMasFood_Click);
            // 
            // btnMasDrink
            // 
            this.btnMasDrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasDrink.Location = new System.Drawing.Point(285, 78);
            this.btnMasDrink.Name = "btnMasDrink";
            this.btnMasDrink.Size = new System.Drawing.Size(35, 24);
            this.btnMasDrink.TabIndex = 32;
            this.btnMasDrink.Text = "+";
            this.btnMasDrink.UseVisualStyleBackColor = true;
            this.btnMasDrink.Click += new System.EventHandler(this.btnMasDrink_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 34;
            this.label9.Tag = "enterDNI";
            this.label9.Text = "Ingrese DNI:";
            // 
            // txtDNIped
            // 
            this.txtDNIped.Location = new System.Drawing.Point(114, 279);
            this.txtDNIped.Name = "txtDNIped";
            this.txtDNIped.Size = new System.Drawing.Size(129, 20);
            this.txtDNIped.TabIndex = 33;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(21, 241);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(80, 13);
            this.label45.TabIndex = 32;
            this.label45.Tag = "asociarCli";
            this.label45.Text = "Asociar Cliente:";
            // 
            // btnAddComida
            // 
            this.btnAddComida.Location = new System.Drawing.Point(414, 164);
            this.btnAddComida.Name = "btnAddComida";
            this.btnAddComida.Size = new System.Drawing.Size(65, 51);
            this.btnAddComida.TabIndex = 23;
            this.btnAddComida.Tag = "add";
            this.btnAddComida.Text = "Agregar";
            this.btnAddComida.UseVisualStyleBackColor = true;
            this.btnAddComida.Click += new System.EventHandler(this.btnAddComida_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(329, 152);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 13);
            this.label25.TabIndex = 31;
            this.label25.Tag = "cant";
            this.label25.Text = "Cantidad:";
            // 
            // btnAddBebida
            // 
            this.btnAddBebida.Location = new System.Drawing.Point(414, 59);
            this.btnAddBebida.Name = "btnAddBebida";
            this.btnAddBebida.Size = new System.Drawing.Size(65, 51);
            this.btnAddBebida.TabIndex = 22;
            this.btnAddBebida.Tag = "add";
            this.btnAddBebida.Text = "Agregar";
            this.btnAddBebida.UseVisualStyleBackColor = true;
            this.btnAddBebida.Click += new System.EventHandler(this.btnAddBebida_Click);
            // 
            // txtCantC
            // 
            this.txtCantC.Location = new System.Drawing.Point(344, 182);
            this.txtCantC.Name = "txtCantC";
            this.txtCantC.Size = new System.Drawing.Size(37, 20);
            this.txtCantC.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 23;
            this.label10.Tag = "cant";
            this.label10.Text = "Cantidad:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(17, 152);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(50, 13);
            this.label44.TabIndex = 30;
            this.label44.Tag = "comidas";
            this.label44.Text = "Comidas:";
            // 
            // txtCantB
            // 
            this.txtCantB.Location = new System.Drawing.Point(344, 81);
            this.txtCantB.Name = "txtCantB";
            this.txtCantB.Size = new System.Drawing.Size(36, 20);
            this.txtCantB.TabIndex = 22;
            // 
            // comboComidas
            // 
            this.comboComidas.FormattingEnabled = true;
            this.comboComidas.Location = new System.Drawing.Point(20, 180);
            this.comboComidas.Name = "comboComidas";
            this.comboComidas.Size = new System.Drawing.Size(193, 21);
            this.comboComidas.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 22;
            this.label2.Tag = "bebidas";
            this.label2.Text = "Bebidas:";
            // 
            // comboBebidas
            // 
            this.comboBebidas.FormattingEnabled = true;
            this.comboBebidas.Location = new System.Drawing.Point(20, 81);
            this.comboBebidas.Name = "comboBebidas";
            this.comboBebidas.Size = new System.Drawing.Size(193, 21);
            this.comboBebidas.TabIndex = 28;
            // 
            // btnAddPedido
            // 
            this.btnAddPedido.Location = new System.Drawing.Point(375, 279);
            this.btnAddPedido.Name = "btnAddPedido";
            this.btnAddPedido.Size = new System.Drawing.Size(104, 48);
            this.btnAddPedido.TabIndex = 4;
            this.btnAddPedido.Tag = "registerP";
            this.btnAddPedido.Text = "Registrar Pedido";
            this.btnAddPedido.UseVisualStyleBackColor = true;
            this.btnAddPedido.Click += new System.EventHandler(this.btnAddPedido_Click);
            // 
            // labelDetallePedidos
            // 
            this.labelDetallePedidos.AutoSize = true;
            this.labelDetallePedidos.Location = new System.Drawing.Point(42, 21);
            this.labelDetallePedidos.Name = "labelDetallePedidos";
            this.labelDetallePedidos.Size = new System.Drawing.Size(99, 13);
            this.labelDetallePedidos.TabIndex = 10;
            this.labelDetallePedidos.Tag = "detalles";
            this.labelDetallePedidos.Text = "Detalle de Pedidos:";
            // 
            // dataPedidos
            // 
            this.dataPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPedidos.Location = new System.Drawing.Point(340, 49);
            this.dataPedidos.Name = "dataPedidos";
            this.dataPedidos.ReadOnly = true;
            this.dataPedidos.Size = new System.Drawing.Size(796, 262);
            this.dataPedidos.TabIndex = 1;
            this.dataPedidos.SelectionChanged += new System.EventHandler(this.dataPedidos_SelectionChanged);
            // 
            // labelAllPedidos
            // 
            this.labelAllPedidos.AutoSize = true;
            this.labelAllPedidos.Location = new System.Drawing.Point(337, 25);
            this.labelAllPedidos.Name = "labelAllPedidos";
            this.labelAllPedidos.Size = new System.Drawing.Size(97, 13);
            this.labelAllPedidos.TabIndex = 0;
            this.labelAllPedidos.Tag = "allPedidos";
            this.labelAllPedidos.Text = "Todos los Pedidos:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePedidos);
            this.tabControl1.Controls.Add(this.tabPageTareas);
            this.tabControl1.Controls.Add(this.tabPageClientes);
            this.tabControl1.Controls.Add(this.tabPageDesempeño);
            this.tabControl1.Controls.Add(this.tabPageEmpleados);
            this.tabControl1.Controls.Add(this.tabProductos);
            this.tabControl1.Controls.Add(this.tabAdmin);
            this.tabControl1.Controls.Add(this.tabBitacora);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1173, 745);
            this.tabControl1.TabIndex = 1;
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.btnEnableProduct);
            this.tabProductos.Controls.Add(this.txtNameProdBuscar);
            this.tabProductos.Controls.Add(this.btnBuscarProducto);
            this.tabProductos.Controls.Add(this.btnActDataProd);
            this.tabProductos.Controls.Add(this.label49);
            this.tabProductos.Controls.Add(this.label48);
            this.tabProductos.Controls.Add(this.dataOneProdu);
            this.tabProductos.Controls.Add(this.groupManejoProductos);
            this.tabProductos.Controls.Add(this.dataAllProductos);
            this.tabProductos.Controls.Add(this.label47);
            this.tabProductos.Location = new System.Drawing.Point(4, 22);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(1165, 719);
            this.tabProductos.TabIndex = 5;
            this.tabProductos.Tag = "tabProdu";
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // btnEnableProduct
            // 
            this.btnEnableProduct.Location = new System.Drawing.Point(240, 19);
            this.btnEnableProduct.Name = "btnEnableProduct";
            this.btnEnableProduct.Size = new System.Drawing.Size(128, 29);
            this.btnEnableProduct.TabIndex = 12;
            this.btnEnableProduct.Tag = "enable";
            this.btnEnableProduct.Text = "Habilitar/Deshabilitar";
            this.btnEnableProduct.UseVisualStyleBackColor = true;
            this.btnEnableProduct.Click += new System.EventHandler(this.btnEnableProduct_Click);
            // 
            // txtNameProdBuscar
            // 
            this.txtNameProdBuscar.Location = new System.Drawing.Point(191, 532);
            this.txtNameProdBuscar.Name = "txtNameProdBuscar";
            this.txtNameProdBuscar.Size = new System.Drawing.Size(138, 20);
            this.txtNameProdBuscar.TabIndex = 26;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(434, 523);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(83, 29);
            this.btnBuscarProducto.TabIndex = 12;
            this.btnBuscarProducto.Tag = "search";
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // btnActDataProd
            // 
            this.btnActDataProd.Location = new System.Drawing.Point(401, 19);
            this.btnActDataProd.Name = "btnActDataProd";
            this.btnActDataProd.Size = new System.Drawing.Size(116, 30);
            this.btnActDataProd.TabIndex = 9;
            this.btnActDataProd.Tag = "update";
            this.btnActDataProd.Text = "Actualizar y Consultar";
            this.btnActDataProd.UseVisualStyleBackColor = true;
            this.btnActDataProd.Click += new System.EventHandler(this.btnActDataProd_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(27, 535);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(99, 13);
            this.label49.TabIndex = 7;
            this.label49.Tag = "enterNameP";
            this.label49.Text = "Ingrese el Nombre: ";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(27, 495);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(182, 13);
            this.label48.TabIndex = 6;
            this.label48.Tag = "searchOne";
            this.label48.Text = "Consultar un Producto en Especifico:";
            // 
            // dataOneProdu
            // 
            this.dataOneProdu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataOneProdu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOneProdu.Location = new System.Drawing.Point(27, 567);
            this.dataOneProdu.Name = "dataOneProdu";
            this.dataOneProdu.ReadOnly = true;
            this.dataOneProdu.Size = new System.Drawing.Size(490, 105);
            this.dataOneProdu.TabIndex = 5;
            // 
            // groupManejoProductos
            // 
            this.groupManejoProductos.Controls.Add(this.groupBox14);
            this.groupManejoProductos.Controls.Add(this.groupBox13);
            this.groupManejoProductos.Location = new System.Drawing.Point(542, 55);
            this.groupManejoProductos.Name = "groupManejoProductos";
            this.groupManejoProductos.Size = new System.Drawing.Size(583, 617);
            this.groupManejoProductos.TabIndex = 4;
            this.groupManejoProductos.TabStop = false;
            this.groupManejoProductos.Tag = "produManage";
            this.groupManejoProductos.Text = "Manejo de Productos";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.comboTipoProdMod);
            this.groupBox14.Controls.Add(this.label58);
            this.groupBox14.Controls.Add(this.btnModificarProducto);
            this.groupBox14.Controls.Add(this.txtDescrpProdMod);
            this.groupBox14.Controls.Add(this.label56);
            this.groupBox14.Controls.Add(this.txtPrecioProdMod);
            this.groupBox14.Controls.Add(this.label57);
            this.groupBox14.Controls.Add(this.txtNameProdMod);
            this.groupBox14.Controls.Add(this.label54);
            this.groupBox14.Controls.Add(this.label55);
            this.groupBox14.Location = new System.Drawing.Point(30, 316);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(528, 268);
            this.groupBox14.TabIndex = 6;
            this.groupBox14.TabStop = false;
            this.groupBox14.Tag = "modProdu";
            this.groupBox14.Text = "Modificar un Producto:";
            // 
            // comboTipoProdMod
            // 
            this.comboTipoProdMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoProdMod.FormattingEnabled = true;
            this.comboTipoProdMod.Items.AddRange(new object[] {
            "Comida",
            "Bebida",
            ""});
            this.comboTipoProdMod.Location = new System.Drawing.Point(360, 80);
            this.comboTipoProdMod.Name = "comboTipoProdMod";
            this.comboTipoProdMod.Size = new System.Drawing.Size(138, 21);
            this.comboTipoProdMod.TabIndex = 26;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(27, 43);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(230, 13);
            this.label58.TabIndex = 24;
            this.label58.Text = "Seleccione el Producto a Modificar en pantalla:";
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.Location = new System.Drawing.Point(427, 204);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(83, 40);
            this.btnModificarProducto.TabIndex = 10;
            this.btnModificarProducto.Tag = "modify";
            this.btnModificarProducto.Text = "Modificar";
            this.btnModificarProducto.UseVisualStyleBackColor = true;
            this.btnModificarProducto.Click += new System.EventHandler(this.btnModificarProducto_Click);
            // 
            // txtDescrpProdMod
            // 
            this.txtDescrpProdMod.Location = new System.Drawing.Point(127, 201);
            this.txtDescrpProdMod.Name = "txtDescrpProdMod";
            this.txtDescrpProdMod.Size = new System.Drawing.Size(267, 20);
            this.txtDescrpProdMod.TabIndex = 21;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(27, 204);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(66, 13);
            this.label56.TabIndex = 18;
            this.label56.Tag = "newDescrp";
            this.label56.Text = "Descripcion:";
            // 
            // txtPrecioProdMod
            // 
            this.txtPrecioProdMod.Location = new System.Drawing.Point(117, 135);
            this.txtPrecioProdMod.Name = "txtPrecioProdMod";
            this.txtPrecioProdMod.Size = new System.Drawing.Size(138, 20);
            this.txtPrecioProdMod.TabIndex = 23;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(27, 88);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(47, 13);
            this.label57.TabIndex = 17;
            this.label57.Tag = "newName";
            this.label57.Text = "Nombre:";
            // 
            // txtNameProdMod
            // 
            this.txtNameProdMod.Location = new System.Drawing.Point(117, 85);
            this.txtNameProdMod.Name = "txtNameProdMod";
            this.txtNameProdMod.Size = new System.Drawing.Size(138, 20);
            this.txtNameProdMod.TabIndex = 16;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(32, 138);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(40, 13);
            this.label54.TabIndex = 20;
            this.label54.Tag = "newPrice";
            this.label54.Text = "Precio:";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(295, 83);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(31, 13);
            this.label55.TabIndex = 19;
            this.label55.Tag = "newType";
            this.label55.Text = "Tipo:";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.comboTipoProdCrear);
            this.groupBox13.Controls.Add(this.btnAgregar);
            this.groupBox13.Controls.Add(this.txtPrecioProdCrear);
            this.groupBox13.Controls.Add(this.txtDescrpProdCrear);
            this.groupBox13.Controls.Add(this.label53);
            this.groupBox13.Controls.Add(this.label52);
            this.groupBox13.Controls.Add(this.label51);
            this.groupBox13.Controls.Add(this.label50);
            this.groupBox13.Controls.Add(this.textBox2);
            this.groupBox13.Controls.Add(this.txtNameProdCrear);
            this.groupBox13.Location = new System.Drawing.Point(30, 48);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(528, 214);
            this.groupBox13.TabIndex = 5;
            this.groupBox13.TabStop = false;
            this.groupBox13.Tag = "addProdu";
            this.groupBox13.Text = "Agregar un Producto:";
            // 
            // comboTipoProdCrear
            // 
            this.comboTipoProdCrear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoProdCrear.FormattingEnabled = true;
            this.comboTipoProdCrear.Items.AddRange(new object[] {
            "Comida",
            "Bebida"});
            this.comboTipoProdCrear.Location = new System.Drawing.Point(360, 50);
            this.comboTipoProdCrear.Name = "comboTipoProdCrear";
            this.comboTipoProdCrear.Size = new System.Drawing.Size(138, 21);
            this.comboTipoProdCrear.TabIndex = 16;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(427, 161);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(83, 37);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Tag = "reg";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtPrecioProdCrear
            // 
            this.txtPrecioProdCrear.Location = new System.Drawing.Point(108, 98);
            this.txtPrecioProdCrear.Name = "txtPrecioProdCrear";
            this.txtPrecioProdCrear.Size = new System.Drawing.Size(138, 20);
            this.txtPrecioProdCrear.TabIndex = 15;
            // 
            // txtDescrpProdCrear
            // 
            this.txtDescrpProdCrear.Location = new System.Drawing.Point(117, 146);
            this.txtDescrpProdCrear.Name = "txtDescrpProdCrear";
            this.txtDescrpProdCrear.Size = new System.Drawing.Size(277, 20);
            this.txtDescrpProdCrear.TabIndex = 13;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(47, 101);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 13);
            this.label53.TabIndex = 12;
            this.label53.Tag = "price";
            this.label53.Text = "Precio:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(298, 53);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(31, 13);
            this.label52.TabIndex = 11;
            this.label52.Tag = "type";
            this.label52.Text = "Tipo:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(21, 149);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(66, 13);
            this.label51.TabIndex = 10;
            this.label51.Tag = "descrp";
            this.label51.Text = "Descripcion:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(40, 54);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(47, 13);
            this.label50.TabIndex = 9;
            this.label50.Tag = "name";
            this.label50.Text = "Nombre:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(138, 224);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // txtNameProdCrear
            // 
            this.txtNameProdCrear.Location = new System.Drawing.Point(108, 51);
            this.txtNameProdCrear.Name = "txtNameProdCrear";
            this.txtNameProdCrear.Size = new System.Drawing.Size(138, 20);
            this.txtNameProdCrear.TabIndex = 3;
            // 
            // dataAllProductos
            // 
            this.dataAllProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAllProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAllProductos.Location = new System.Drawing.Point(27, 55);
            this.dataAllProductos.Name = "dataAllProductos";
            this.dataAllProductos.ReadOnly = true;
            this.dataAllProductos.Size = new System.Drawing.Size(490, 417);
            this.dataAllProductos.TabIndex = 2;
            this.dataAllProductos.SelectionChanged += new System.EventHandler(this.dataAllProductos_SelectionChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(24, 27);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(107, 13);
            this.label47.TabIndex = 1;
            this.label47.Tag = "allProd";
            this.label47.Text = "Todos los Productos:";
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.groupNewPermit);
            this.tabAdmin.Controls.Add(this.groupNewRole);
            this.tabAdmin.Controls.Add(this.groupNewUser);
            this.tabAdmin.Controls.Add(this.btnEliminarPatente);
            this.tabAdmin.Controls.Add(this.btnEliminarRol);
            this.tabAdmin.Controls.Add(this.btnEliminarUsuario);
            this.tabAdmin.Controls.Add(this.btnGatherPermisos);
            this.tabAdmin.Controls.Add(this.label72);
            this.tabAdmin.Controls.Add(this.dataPermisosPorRol);
            this.tabAdmin.Controls.Add(this.label71);
            this.tabAdmin.Controls.Add(this.dataFamPorUser);
            this.tabAdmin.Controls.Add(this.btnEnableUser);
            this.tabAdmin.Controls.Add(this.btnAsociarPermiso);
            this.tabAdmin.Controls.Add(this.btnAssociateRol);
            this.tabAdmin.Controls.Add(this.label8);
            this.tabAdmin.Controls.Add(this.label4);
            this.tabAdmin.Controls.Add(this.label1);
            this.tabAdmin.Controls.Add(this.btnActDataPatent);
            this.tabAdmin.Controls.Add(this.btnActDataFam);
            this.tabAdmin.Controls.Add(this.btnActDataUsers);
            this.tabAdmin.Controls.Add(this.dataAllPermisos);
            this.tabAdmin.Controls.Add(this.dataAllRoles);
            this.tabAdmin.Controls.Add(this.dataAllUsers);
            this.tabAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Size = new System.Drawing.Size(1165, 719);
            this.tabAdmin.TabIndex = 6;
            this.tabAdmin.Tag = "tabAdmin";
            this.tabAdmin.Text = "Settings";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // groupNewPermit
            // 
            this.groupNewPermit.Controls.Add(this.txtDataKey);
            this.groupNewPermit.Controls.Add(this.txtPatentName);
            this.groupNewPermit.Controls.Add(this.label69);
            this.groupNewPermit.Controls.Add(this.label68);
            this.groupNewPermit.Controls.Add(this.btnCrearPatent);
            this.groupNewPermit.Location = new System.Drawing.Point(53, 545);
            this.groupNewPermit.Name = "groupNewPermit";
            this.groupNewPermit.Size = new System.Drawing.Size(436, 136);
            this.groupNewPermit.TabIndex = 44;
            this.groupNewPermit.TabStop = false;
            this.groupNewPermit.Tag = "newPermit";
            this.groupNewPermit.Text = "Nuevo Permiso";
            // 
            // txtDataKey
            // 
            this.txtDataKey.Location = new System.Drawing.Point(136, 76);
            this.txtDataKey.Name = "txtDataKey";
            this.txtDataKey.Size = new System.Drawing.Size(164, 20);
            this.txtDataKey.TabIndex = 24;
            // 
            // txtPatentName
            // 
            this.txtPatentName.Location = new System.Drawing.Point(136, 36);
            this.txtPatentName.Name = "txtPatentName";
            this.txtPatentName.Size = new System.Drawing.Size(164, 20);
            this.txtPatentName.TabIndex = 21;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(18, 39);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(47, 13);
            this.label69.TabIndex = 22;
            this.label69.Tag = "permiso";
            this.label69.Text = "Permiso:";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(18, 79);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(51, 13);
            this.label68.TabIndex = 23;
            this.label68.Tag = "dataKey";
            this.label68.Text = "DataKey:";
            // 
            // btnCrearPatent
            // 
            this.btnCrearPatent.Location = new System.Drawing.Point(337, 39);
            this.btnCrearPatent.Name = "btnCrearPatent";
            this.btnCrearPatent.Size = new System.Drawing.Size(77, 44);
            this.btnCrearPatent.TabIndex = 29;
            this.btnCrearPatent.Tag = "regAccess";
            this.btnCrearPatent.Text = "Registrar Permiso";
            this.btnCrearPatent.UseVisualStyleBackColor = true;
            this.btnCrearPatent.Click += new System.EventHandler(this.btnCrearPatent_Click);
            // 
            // groupNewRole
            // 
            this.groupNewRole.Controls.Add(this.btnCrearRol);
            this.groupNewRole.Controls.Add(this.txtRolName);
            this.groupNewRole.Controls.Add(this.label65);
            this.groupNewRole.Location = new System.Drawing.Point(53, 444);
            this.groupNewRole.Name = "groupNewRole";
            this.groupNewRole.Size = new System.Drawing.Size(436, 95);
            this.groupNewRole.TabIndex = 43;
            this.groupNewRole.TabStop = false;
            this.groupNewRole.Tag = "newRole";
            this.groupNewRole.Text = "Nuevo Rol";
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(308, 41);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(94, 28);
            this.btnCrearRol.TabIndex = 28;
            this.btnCrearRol.Tag = "regRol";
            this.btnCrearRol.Text = "Registrar Rol";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(119, 46);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Size = new System.Drawing.Size(144, 20);
            this.txtRolName.TabIndex = 15;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(21, 49);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(26, 13);
            this.label65.TabIndex = 16;
            this.label65.Tag = "rolName";
            this.label65.Text = "Rol:";
            // 
            // groupNewUser
            // 
            this.groupNewUser.Controls.Add(this.txtPassCreate);
            this.groupNewUser.Controls.Add(this.txtUserNameCreate);
            this.groupNewUser.Controls.Add(this.label59);
            this.groupNewUser.Controls.Add(this.label61);
            this.groupNewUser.Controls.Add(this.btnCrearUser);
            this.groupNewUser.Location = new System.Drawing.Point(53, 261);
            this.groupNewUser.Name = "groupNewUser";
            this.groupNewUser.Size = new System.Drawing.Size(436, 177);
            this.groupNewUser.TabIndex = 42;
            this.groupNewUser.TabStop = false;
            this.groupNewUser.Tag = "newUser";
            this.groupNewUser.Text = "Nuevo Usuario";
            // 
            // txtPassCreate
            // 
            this.txtPassCreate.Location = new System.Drawing.Point(136, 82);
            this.txtPassCreate.Name = "txtPassCreate";
            this.txtPassCreate.Size = new System.Drawing.Size(164, 20);
            this.txtPassCreate.TabIndex = 13;
            // 
            // txtUserNameCreate
            // 
            this.txtUserNameCreate.Location = new System.Drawing.Point(136, 42);
            this.txtUserNameCreate.Name = "txtUserNameCreate";
            this.txtUserNameCreate.Size = new System.Drawing.Size(164, 20);
            this.txtUserNameCreate.TabIndex = 10;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(45, 45);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(58, 13);
            this.label59.TabIndex = 11;
            this.label59.Tag = "username";
            this.label59.Text = "Username:";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(45, 85);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(56, 13);
            this.label61.TabIndex = 12;
            this.label61.Tag = "password";
            this.label61.Text = "Password:";
            // 
            // btnCrearUser
            // 
            this.btnCrearUser.Location = new System.Drawing.Point(163, 131);
            this.btnCrearUser.Name = "btnCrearUser";
            this.btnCrearUser.Size = new System.Drawing.Size(100, 31);
            this.btnCrearUser.TabIndex = 14;
            this.btnCrearUser.Tag = "regUser";
            this.btnCrearUser.Text = "Registrar Usuario";
            this.btnCrearUser.UseVisualStyleBackColor = true;
            this.btnCrearUser.Click += new System.EventHandler(this.btnCrearUser_Click);
            // 
            // btnEliminarPatente
            // 
            this.btnEliminarPatente.Location = new System.Drawing.Point(579, 638);
            this.btnEliminarPatente.Name = "btnEliminarPatente";
            this.btnEliminarPatente.Size = new System.Drawing.Size(71, 41);
            this.btnEliminarPatente.TabIndex = 41;
            this.btnEliminarPatente.Tag = "delAccess";
            this.btnEliminarPatente.Text = "Eliminar Permiso";
            this.btnEliminarPatente.UseVisualStyleBackColor = true;
            this.btnEliminarPatente.Click += new System.EventHandler(this.btnEliminarPatente_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Location = new System.Drawing.Point(579, 555);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(71, 41);
            this.btnEliminarRol.TabIndex = 40;
            this.btnEliminarRol.Tag = "delRol";
            this.btnEliminarRol.Text = "Eliminar Rol";
            this.btnEliminarRol.UseVisualStyleBackColor = true;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(579, 479);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(71, 41);
            this.btnEliminarUsuario.TabIndex = 39;
            this.btnEliminarUsuario.Tag = "delUser";
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnGatherPermisos
            // 
            this.btnGatherPermisos.Location = new System.Drawing.Point(537, 275);
            this.btnGatherPermisos.Name = "btnGatherPermisos";
            this.btnGatherPermisos.Size = new System.Drawing.Size(113, 41);
            this.btnGatherPermisos.TabIndex = 37;
            this.btnGatherPermisos.Tag = "groupAccesses";
            this.btnGatherPermisos.Text = "Agrupar Permisos";
            this.btnGatherPermisos.UseVisualStyleBackColor = true;
            this.btnGatherPermisos.Click += new System.EventHandler(this.btnGatherPermisos_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(748, 16);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(89, 13);
            this.label72.TabIndex = 36;
            this.label72.Tag = "permPerRole";
            this.label72.Text = "Permisos por Rol:";
            // 
            // dataPermisosPorRol
            // 
            this.dataPermisosPorRol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataPermisosPorRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPermisosPorRol.Location = new System.Drawing.Point(751, 40);
            this.dataPermisosPorRol.Name = "dataPermisosPorRol";
            this.dataPermisosPorRol.ReadOnly = true;
            this.dataPermisosPorRol.Size = new System.Drawing.Size(366, 183);
            this.dataPermisosPorRol.TabIndex = 35;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(50, 162);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(83, 13);
            this.label71.TabIndex = 34;
            this.label71.Tag = "rolPerUser";
            this.label71.Text = "Rol por Usuario:";
            // 
            // dataFamPorUser
            // 
            this.dataFamPorUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFamPorUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFamPorUser.Location = new System.Drawing.Point(53, 186);
            this.dataFamPorUser.Name = "dataFamPorUser";
            this.dataFamPorUser.ReadOnly = true;
            this.dataFamPorUser.Size = new System.Drawing.Size(285, 57);
            this.dataFamPorUser.TabIndex = 33;
            // 
            // btnEnableUser
            // 
            this.btnEnableUser.Location = new System.Drawing.Point(376, 125);
            this.btnEnableUser.Name = "btnEnableUser";
            this.btnEnableUser.Size = new System.Drawing.Size(113, 28);
            this.btnEnableUser.TabIndex = 31;
            this.btnEnableUser.Tag = "enable";
            this.btnEnableUser.Text = "Habilitar/Deshabilitar";
            this.btnEnableUser.UseVisualStyleBackColor = true;
            this.btnEnableUser.Click += new System.EventHandler(this.btnEnableUser_Click);
            // 
            // btnAsociarPermiso
            // 
            this.btnAsociarPermiso.Location = new System.Drawing.Point(538, 336);
            this.btnAsociarPermiso.Name = "btnAsociarPermiso";
            this.btnAsociarPermiso.Size = new System.Drawing.Size(112, 41);
            this.btnAsociarPermiso.TabIndex = 30;
            this.btnAsociarPermiso.Tag = "asociarAccesses";
            this.btnAsociarPermiso.Text = "Asociar Permisos";
            this.btnAsociarPermiso.UseVisualStyleBackColor = true;
            this.btnAsociarPermiso.Click += new System.EventHandler(this.btnAsociarPermiso_Click);
            // 
            // btnAssociateRol
            // 
            this.btnAssociateRol.Location = new System.Drawing.Point(376, 50);
            this.btnAssociateRol.Name = "btnAssociateRol";
            this.btnAssociateRol.Size = new System.Drawing.Size(113, 33);
            this.btnAssociateRol.TabIndex = 9;
            this.btnAssociateRol.Tag = "asociarRol";
            this.btnAssociateRol.Text = "Asociar Rol";
            this.btnAssociateRol.UseVisualStyleBackColor = true;
            this.btnAssociateRol.Click += new System.EventHandler(this.btnAssociateRol_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(670, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 8;
            this.label8.Tag = "accesses";
            this.label8.Text = "Permisos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Tag = "roles";
            this.label4.Text = "Roles:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Tag = "users";
            this.label1.Text = "Usuarios:";
            // 
            // btnActDataPatent
            // 
            this.btnActDataPatent.Location = new System.Drawing.Point(1005, 246);
            this.btnActDataPatent.Name = "btnActDataPatent";
            this.btnActDataPatent.Size = new System.Drawing.Size(112, 23);
            this.btnActDataPatent.TabIndex = 5;
            this.btnActDataPatent.Tag = "update";
            this.btnActDataPatent.Text = "Actualizar y Mostrar";
            this.btnActDataPatent.UseVisualStyleBackColor = true;
            this.btnActDataPatent.Click += new System.EventHandler(this.btnActDataPatent_Click);
            // 
            // btnActDataFam
            // 
            this.btnActDataFam.Location = new System.Drawing.Point(610, 11);
            this.btnActDataFam.Name = "btnActDataFam";
            this.btnActDataFam.Size = new System.Drawing.Size(112, 23);
            this.btnActDataFam.TabIndex = 4;
            this.btnActDataFam.Tag = "update";
            this.btnActDataFam.Text = "Actualizar y Mostrar";
            this.btnActDataFam.UseVisualStyleBackColor = true;
            this.btnActDataFam.Click += new System.EventHandler(this.btnActDataFam_Click);
            // 
            // btnActDataUsers
            // 
            this.btnActDataUsers.Location = new System.Drawing.Point(226, 16);
            this.btnActDataUsers.Name = "btnActDataUsers";
            this.btnActDataUsers.Size = new System.Drawing.Size(112, 23);
            this.btnActDataUsers.TabIndex = 3;
            this.btnActDataUsers.Tag = "update";
            this.btnActDataUsers.Text = "Actualizar y Mostrar";
            this.btnActDataUsers.UseVisualStyleBackColor = true;
            this.btnActDataUsers.Click += new System.EventHandler(this.btnActDataUsers_Click);
            // 
            // dataAllPermisos
            // 
            this.dataAllPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAllPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAllPermisos.Location = new System.Drawing.Point(673, 275);
            this.dataAllPermisos.Name = "dataAllPermisos";
            this.dataAllPermisos.ReadOnly = true;
            this.dataAllPermisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAllPermisos.Size = new System.Drawing.Size(444, 420);
            this.dataAllPermisos.TabIndex = 2;
            // 
            // dataAllRoles
            // 
            this.dataAllRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAllRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAllRoles.Location = new System.Drawing.Point(531, 40);
            this.dataAllRoles.Name = "dataAllRoles";
            this.dataAllRoles.ReadOnly = true;
            this.dataAllRoles.Size = new System.Drawing.Size(191, 183);
            this.dataAllRoles.TabIndex = 1;
            this.dataAllRoles.SelectionChanged += new System.EventHandler(this.dataAllRoles_SelectionChanged);
            // 
            // dataAllUsers
            // 
            this.dataAllUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAllUsers.Location = new System.Drawing.Point(53, 50);
            this.dataAllUsers.Name = "dataAllUsers";
            this.dataAllUsers.ReadOnly = true;
            this.dataAllUsers.Size = new System.Drawing.Size(285, 103);
            this.dataAllUsers.TabIndex = 0;
            this.dataAllUsers.SelectionChanged += new System.EventHandler(this.dataAllUsers_SelectionChanged);
            // 
            // tabBitacora
            // 
            this.tabBitacora.Controls.Add(this.btnActDataBitacora);
            this.tabBitacora.Controls.Add(this.btnActDataLogs);
            this.tabBitacora.Controls.Add(this.label43);
            this.tabBitacora.Controls.Add(this.label28);
            this.tabBitacora.Controls.Add(this.dataLogs);
            this.tabBitacora.Controls.Add(this.dataBitacora);
            this.tabBitacora.Location = new System.Drawing.Point(4, 22);
            this.tabBitacora.Name = "tabBitacora";
            this.tabBitacora.Size = new System.Drawing.Size(1165, 719);
            this.tabBitacora.TabIndex = 7;
            this.tabBitacora.Tag = "tabBitacora";
            this.tabBitacora.Text = "Bitacora";
            this.tabBitacora.UseVisualStyleBackColor = true;
            // 
            // btnActDataBitacora
            // 
            this.btnActDataBitacora.Location = new System.Drawing.Point(988, 65);
            this.btnActDataBitacora.Name = "btnActDataBitacora";
            this.btnActDataBitacora.Size = new System.Drawing.Size(108, 23);
            this.btnActDataBitacora.TabIndex = 6;
            this.btnActDataBitacora.Tag = "update";
            this.btnActDataBitacora.Text = "Actualizar y Mostrar";
            this.btnActDataBitacora.UseVisualStyleBackColor = true;
            this.btnActDataBitacora.Click += new System.EventHandler(this.btnActDataBitacora_Click);
            // 
            // btnActDataLogs
            // 
            this.btnActDataLogs.Location = new System.Drawing.Point(988, 378);
            this.btnActDataLogs.Name = "btnActDataLogs";
            this.btnActDataLogs.Size = new System.Drawing.Size(108, 23);
            this.btnActDataLogs.TabIndex = 5;
            this.btnActDataLogs.Tag = "update";
            this.btnActDataLogs.Text = "Actualizar y Mostrar";
            this.btnActDataLogs.UseVisualStyleBackColor = true;
            this.btnActDataLogs.Click += new System.EventHandler(this.btnActDataLogs_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(59, 378);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(95, 13);
            this.label43.TabIndex = 4;
            this.label43.Tag = "datalog";
            this.label43.Text = "Registros de Logs:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(59, 65);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(111, 13);
            this.label28.TabIndex = 3;
            this.label28.Tag = "databit";
            this.label28.Text = "Registros de Bitacora:";
            // 
            // dataLogs
            // 
            this.dataLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLogs.Location = new System.Drawing.Point(62, 410);
            this.dataLogs.Name = "dataLogs";
            this.dataLogs.Size = new System.Drawing.Size(1034, 253);
            this.dataLogs.TabIndex = 1;
            // 
            // dataBitacora
            // 
            this.dataBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBitacora.Location = new System.Drawing.Point(62, 98);
            this.dataBitacora.Name = "dataBitacora";
            this.dataBitacora.Size = new System.Drawing.Size(1034, 247);
            this.dataBitacora.TabIndex = 0;
            // 
            // Coffee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 743);
            this.Controls.Add(this.tabControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Coffee";
            this.Text = "Coffee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Coffee_FormClosing);
            this.Load += new System.EventHandler(this.Coffee_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Coffee_KeyDown);
            this.tabPageEmpleados.ResumeLayout(false);
            this.tabPageEmpleados.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOneEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpleados)).EndInit();
            this.tabPageDesempeño.ResumeLayout(false);
            this.tabPageDesempeño.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTaskPerEmp)).EndInit();
            this.groupCrearBono.ResumeLayout(false);
            this.groupCrearBono.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDesempEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalleTareas)).EndInit();
            this.tabPageClientes.ResumeLayout(false);
            this.tabPageClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataALLClientes)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOneCliente)).EndInit();
            this.tabPageTareas.ResumeLayout(false);
            this.tabPageTareas.PerformLayout();
            this.groupCrearTarea.ResumeLayout(false);
            this.groupCrearTarea.PerformLayout();
            this.groupProcesarTarea.ResumeLayout(false);
            this.groupProcesarTarea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTareas)).EndInit();
            this.tabPagePedidos.ResumeLayout(false);
            this.tabPagePedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetallesMomentum)).EndInit();
            this.groupCancelarPedido.ResumeLayout(false);
            this.groupCancelarPedido.PerformLayout();
            this.groupProcesarPedido.ResumeLayout(false);
            this.groupProcesarPedido.PerformLayout();
            this.groupManejoPedidos.ResumeLayout(false);
            this.groupManejoPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPedidos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabProductos.ResumeLayout(false);
            this.tabProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOneProdu)).EndInit();
            this.groupManejoProductos.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllProductos)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.tabAdmin.PerformLayout();
            this.groupNewPermit.ResumeLayout(false);
            this.groupNewPermit.PerformLayout();
            this.groupNewRole.ResumeLayout(false);
            this.groupNewRole.PerformLayout();
            this.groupNewUser.ResumeLayout(false);
            this.groupNewUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPermisosPorRol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFamPorUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllUsers)).EndInit();
            this.tabBitacora.ResumeLayout(false);
            this.tabBitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageEmpleados;
        private System.Windows.Forms.TabPage tabPageDesempeño;
        private System.Windows.Forms.DataGridView dataBonos;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dataDetalleTareas;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tabPageClientes;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.DataGridView dataALLClientes;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtDNIModCliente;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtApellidoModCliente;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNameModCliente;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDNIBuscarCliente;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDNIRegCliente;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtApellidoRegCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNameRegCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataOneCliente;
        private System.Windows.Forms.TabPage tabPageTareas;
        private System.Windows.Forms.Button btnTerminarTarea;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.GroupBox groupCrearTarea;
        private System.Windows.Forms.TextBox txtDescpTareaCrear;
        private System.Windows.Forms.TextBox txtNameTareaCrear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCrearTarea;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupProcesarTarea;
        private System.Windows.Forms.TextBox txtCodEmpDoTarea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHacerTarea;
        private System.Windows.Forms.Label labelAllTareas;
        private System.Windows.Forms.DataGridView dataTareas;
        private System.Windows.Forms.TabPage tabPagePedidos;
        private System.Windows.Forms.GroupBox groupProcesarPedido;
        private System.Windows.Forms.Button btnFinPedido;
        private System.Windows.Forms.Button btnHacerPedido;
        private System.Windows.Forms.GroupBox groupManejoPedidos;
        private System.Windows.Forms.Button btnAddPedido;
        private System.Windows.Forms.Button btnCancelPedido;
        private System.Windows.Forms.Label labelDetallePedidos;
        private System.Windows.Forms.DataGridView dataPedidos;
        private System.Windows.Forms.Label labelAllPedidos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnAgregarBono;
        private System.Windows.Forms.Button btnEliminarBono;
        private System.Windows.Forms.TextBox txtCategBono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtMontoBono;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DataGridView dataEmpleados;
        private System.Windows.Forms.TextBox txtCodEmpReg;
        private System.Windows.Forms.Button btnRegistrarEmp;
        private System.Windows.Forms.TextBox txtApellidoEmpReg;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtNameEmpReg;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtDNIEmpReg;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtTelefonoEmpReg;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btnBuscarOneEmp;
        private System.Windows.Forms.TextBox txtNameEmpBuscar;
        private System.Windows.Forms.DataGridView dataOneEmpleado;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtTelefonoEmpMod;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnModificarEmp;
        private System.Windows.Forms.TextBox txtDNIEmpMod;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtApellidoEmpMod;
        private System.Windows.Forms.TextBox txtNameEmpMod;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button btnEliminarEmp;
        private System.Windows.Forms.ComboBox comboTurnoEmpMod;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox comboTurnoEmpReg;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnActDataEmpleados;
        private System.Windows.Forms.Button btnActDataClientes;
        private System.Windows.Forms.Button btnActDataTareas;
        private System.Windows.Forms.Button btnActDetalleTarea;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.DataGridView dataAllProductos;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.DataGridView dataOneProdu;
        private System.Windows.Forms.GroupBox groupManejoProductos;
        private System.Windows.Forms.TextBox txtNameProdCrear;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Button btnModificarProducto;
        private System.Windows.Forms.TextBox txtPrecioProdMod;
        private System.Windows.Forms.TextBox txtDescrpProdMod;
        private System.Windows.Forms.TextBox txtNameProdMod;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtPrecioProdCrear;
        private System.Windows.Forms.TextBox txtDescrpProdCrear;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btnActDataProd;
        private System.Windows.Forms.ComboBox comboTipoProdCrear;
        private System.Windows.Forms.ComboBox comboTipoProdMod;
        private System.Windows.Forms.TextBox txtNameProdBuscar;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnActDataBono;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.DataGridView dataDesempEmp;
        private System.Windows.Forms.Button btnActDataDesempEmp;
        private System.Windows.Forms.GroupBox groupCrearBono;
        private System.Windows.Forms.TextBox txtMinTareasBono;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.ComboBox comboBebidas;
        private System.Windows.Forms.TextBox txtDNIped;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btnAddComida;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnAddBebida;
        private System.Windows.Forms.TextBox txtCantC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtCantB;
        private System.Windows.Forms.ComboBox comboComidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupCancelarPedido;
        private System.Windows.Forms.TextBox txtRolEmpMod;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtRolEmpReg;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnBorrarP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox txtCodEMPPedido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMasDrink;
        private System.Windows.Forms.Button btnMenosDrink;
        private System.Windows.Forms.Button btnMasFood;
        private System.Windows.Forms.Button btnMenosFood;
        private System.Windows.Forms.DataGridView dataDetallesMomentum;
        private System.Windows.Forms.Button btnEliminarProduDetalles;
        private System.Windows.Forms.Button btnMasProdu;
        private System.Windows.Forms.Button btnMenosProdu;
        private System.Windows.Forms.TextBox txtCantProdu;
        private System.Windows.Forms.Button btnBorrarSeleccion;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnEnableProduct;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.DataGridView dataAllPermisos;
        private System.Windows.Forms.DataGridView dataAllRoles;
        private System.Windows.Forms.DataGridView dataAllUsers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActDataPatent;
        private System.Windows.Forms.Button btnActDataFam;
        private System.Windows.Forms.Button btnActDataUsers;
        private System.Windows.Forms.Button btnCrearUser;
        private System.Windows.Forms.TextBox txtPassCreate;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txtUserNameCreate;
        private System.Windows.Forms.Button btnAssociateRol;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox txtRolName;
        private System.Windows.Forms.TextBox txtDataKey;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox txtPatentName;
        private System.Windows.Forms.Button btnCrearPatent;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnAsociarPermiso;
        private System.Windows.Forms.Button btnEnableUser;
        private System.Windows.Forms.DataGridView dataFamPorUser;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.DataGridView dataPermisosPorRol;
        private System.Windows.Forms.Button btnGatherPermisos;
        private System.Windows.Forms.Button btnEliminarPatente;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.GroupBox groupNewPermit;
        private System.Windows.Forms.GroupBox groupNewRole;
        private System.Windows.Forms.GroupBox groupNewUser;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.DataGridView dataTaskPerEmp;
        private System.Windows.Forms.TabPage tabBitacora;
        private System.Windows.Forms.DataGridView dataLogs;
        private System.Windows.Forms.DataGridView dataBitacora;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnActDataBitacora;
        private System.Windows.Forms.Button btnActDataLogs;
    }
}

