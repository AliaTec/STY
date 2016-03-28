Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports Intelexion.Nomina
Imports Nomina
Imports System.IO
'Imports System.Web
'Imports Intelexion.Framework.Model
'Imports Intelexion.Framework.View
'Imports System.Exception



Public Class CartaFiniquito
    Inherits DataDynamics.ActiveReports.ActiveReport3

    Dim RPT As New ActiveReport3

    Dim sConnection As String = Intelexion.Framework.Model.SQLConnectionProvider.getConnection("default").getConnection.ConnectionString
    Public Sub New()

        'This call is required by the ActiveReports Designer.
        InitializeComponent()


    End Sub

    Public Sub New(ByVal reporte As Entities.ReportesProceso)

        'This call is required by the ActiveReports Designer.
        InitializeComponent()

    End Sub


 

    Public Sub CartaFiniquito_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.ShowParameterUI = False
        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")

        ' Dim Path As String = Intelexion.Framework.ApplicationConfiguration.ConfigurationSettings.GetConfigurationSettings("ApplicationPath")
        'Dim picRazonSocial As String = "/logos/Logoempresa" + Me.Parameters("IdRazonSocial").Value + ".jpg"
        'Dim archivo As New FileInfo(System.Web.HttpContext.Current.Server.MapPath(Path) + picRazonSocial)


        ' Picture1.Image = Image.FromFile(archivo.FullName)
        'Picture1.Visible = True



        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
                 sConnection, "sp_Reporte_CartaFiniquitoMc @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
                 "@IdTipoNominaAsig = " + Me.Parameters("IdTipoNominaAsig").Value + "," & _
                 "@IdTipoNominaProc = " + Me.Parameters("IdTipoNominaProc").Value + "," & _
                 "@Anio = " + Me.Parameters("Anio").Value + "," & _
                 "@Periodo = " + Me.Parameters("Periodo").Value + "," & _
                 "@IdEmpleado = " + "'" + Me.Parameters("IdEmpleado").Value + "'" + "," & _
                 "@UID = " + Me.Parameters("UID").Value + "," & _
                 "@LID = " + Me.Parameters("LID").Value + "," & _
                 "@idAccion = " + Me.Parameters("idAccion").Value + "", 90)


        'parametros que se envian al subreporte abajo mencionados
        Dim ParamIdRazonSocial As New Parameter
        ParamIdRazonSocial.Key = "IdRazonSocial"

        Dim ParamIdTipoNominaAsig As New Parameter
        ParamIdTipoNominaAsig.Key = "IdTipoNominaAsig"
        ParamIdTipoNominaAsig.Type = Parameter.DataType.String

        Dim ParamIdTipoNominaProc As New Parameter
        ParamIdTipoNominaProc.Key = "IdTipoNominaProc"
        ParamIdTipoNominaProc.Type = Parameter.DataType.String

        Dim ParamAnio As New Parameter
        ParamAnio.Key = "Anio"

        Dim ParamPeriodo As New Parameter
        ParamPeriodo.Key = "Periodo"

        Dim ParamIdEmpleado As New Parameter
        ParamIdEmpleado.Key = "IdEmpleado"
        ParamIdEmpleado.Type = Parameter.DataType.String

        Dim ParamUID As New Parameter
        ParamUID.Key = "UID"
        ParamUID.Type = Parameter.DataType.String

        Dim ParamLID As New Parameter
        ParamLID.Key = "LID"
        ParamLID.Type = Parameter.DataType.String

        Dim ParamidAccion As New Parameter
        ParamidAccion.Key = "idAccion"

        ''******* SUBREPORTE PERCEPCIONES **************/
        '                                  nombre del subreporte
        Dim SubReportePercepciones As New Percepciones
        SubReportePercepciones.Parameters.Clear()

        'aqui se agregan
        SubReportePercepciones.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepciones.Parameters.Add(ParamIdTipoNominaAsig)
        SubReportePercepciones.Parameters.Add(ParamIdTipoNominaProc)
        SubReportePercepciones.Parameters.Add(ParamAnio)
        SubReportePercepciones.Parameters.Add(ParamPeriodo)
        SubReportePercepciones.Parameters.Add(ParamIdEmpleado)
        SubReportePercepciones.Parameters.Add(ParamUID)
        SubReportePercepciones.Parameters.Add(ParamLID)
        SubReportePercepciones.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepciones.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        SubReportePercepciones.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        SubReportePercepciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepciones.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        SubReportePercepciones.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        SubReportePercepciones.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReportePercepciones.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport1.Report = SubReportePercepciones




        '*************************************************************************
        ''******* SUBREPORTE DEDUCCIONES **************/
        '                                  nombre del subreporte
        Dim SubReporteDeducciones As New Deducciones
        SubReporteDeducciones.Parameters.Clear()

        'aqui se agregan
        SubReporteDeducciones.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeducciones.Parameters.Add(ParamIdTipoNominaAsig)
        SubReporteDeducciones.Parameters.Add(ParamIdTipoNominaProc)
        SubReporteDeducciones.Parameters.Add(ParamAnio)
        SubReporteDeducciones.Parameters.Add(ParamPeriodo)
        SubReporteDeducciones.Parameters.Add(ParamIdEmpleado)
        SubReporteDeducciones.Parameters.Add(ParamUID)
        SubReporteDeducciones.Parameters.Add(ParamLID)
        SubReporteDeducciones.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeducciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeducciones.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        SubReporteDeducciones.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        SubReporteDeducciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeducciones.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        SubReporteDeducciones.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        SubReporteDeducciones.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteDeducciones.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeducciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReporteDeducciones

    End Sub


    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
