Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports Intelexion.Nomina
Imports Nomina

Public Class AcumuladodeConceptos
    Inherits DataDynamics.ActiveReports.ActiveReport3
    Dim sConnection As String = Intelexion.Framework.Model.SQLConnectionProvider.getConnection("default").getConnection.ConnectionString

    Public Sub AcumuladodeConceptos_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.ShowParameterUI = False

        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")

        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
                sConnection, "spq_nomAcumuladoConcepto @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
                "@Anio = " + Me.Parameters("Anio").Value + "," & _
                "@UID = " + Me.Parameters("UID").Value + "," & _
                "@LID = " + Me.Parameters("LID").Value + "," & _
                "@idAccion = " + Me.Parameters("idAccion").Value + "", 90)


        'parametros que se envian al subreporte abajo mencionados
        Dim ParamIdRazonSocial As New Parameter
        ParamIdRazonSocial.Key = "IdRazonSocial"

        Dim ParamAnio As New Parameter
        ParamAnio.Key = "Anio"

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
        'Dim SubReportePercepciones As New Percepciones2
        'SubReportePercepciones.Parameters.Clear()

        ''aqui se agregan
        'SubReportePercepciones.Parameters.Add(ParamIdRazonSocial)
        'SubReportePercepciones.Parameters.Add(ParamIdTipoNominaAsig)
        'SubReportePercepciones.Parameters.Add(ParamIdTipoNominaProc)
        'SubReportePercepciones.Parameters.Add(ParamAnio)
        'SubReportePercepciones.Parameters.Add(ParamPeriodo)
        'SubReportePercepciones.Parameters.Add(ParamIdEmpleado)
        'SubReportePercepciones.Parameters.Add(ParamUID)
        'SubReportePercepciones.Parameters.Add(ParamLID)
        'SubReportePercepciones.Parameters.Add(ParamidAccion)


        ''aqui se les asigna el valor
        'SubReportePercepciones.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        'SubReportePercepciones.Parameters("IdTipoNominaAsig").Value = Me.Parameters("IdTipoNominaAsig").Value
        'SubReportePercepciones.Parameters("IdTipoNominaProc").Value = Me.Parameters("IdTipoNominaProc").Value
        'SubReportePercepciones.Parameters("Anio").Value = Me.Parameters("Anio").Value
        'SubReportePercepciones.Parameters("Periodo").Value = Me.Parameters("Periodo").Value
        'SubReportePercepciones.Parameters("IdEmpleado").Value = Me.Parameters("IdEmpleado").Value
        'SubReportePercepciones.Parameters("UID").Value = Me.Parameters("UID").Value
        'SubReportePercepciones.Parameters("LID").Value = Me.Parameters("LID").Value
        'SubReportePercepciones.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        'Me.SubReport1.Report = SubReportePercepciones

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format

    End Sub
End Class