Imports System.Collections.ObjectModel
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO

Module VARIABLES
#Region "variables"
    Public usuario As Integer
    Public nameUser As String
    Public GNombreAgencia As String
    Public GProductoContratado As String
    Public GOperacion As Integer
    'Variable para determinar el idioma de algunos formularios
    Public TRADUCE As Boolean

    Public CuentaCompApertura As String

    Public RepTipoMT103 As Integer = 0

    'para armado de sentencia que pasa a formulario
    Public ls_PorImprimir As String
    Public ls_TituloReporte As String
    Public fe_Inicio As String
    Public fe_Fin As String
    Public opcionReporte As Integer = 0
    'Public Ambiente As String = ""
    Public iReportes As Integer = 0      'Indica si el llamado es de el modulo de reportes
    Public iBD As Integer = 0      'Indica 0 para BD Ticket, 1 para BD Funcionarios
    'variables para reportes de operativa
    Public iHayRegistros As Integer = 0
    Public lsHora000 As String = ""
    Public iRango As Integer = 0
    Public sCuentaIni As String = ""
    Public sCuentaFin As String = ""

    'Fijar Agencia Houston
    Public gb_FijarAgencia = True

#End Region

#Region "Variables de Permisos de Seguridad"
    Structure TipoPermiso
        Public Nombre As String
        Public Descripcion As String
        Public Valor As Integer
        Public IDAplicacion As Integer '------------- RACB 09/08/2021
    End Structure

    Structure TipoAutorizacion
        Public Nombre As String
        Public Descripcion As String
        Public Comentario As Boolean '------------- RACB 09/08/2021
        Public Hora As String
        Public Valor As Integer
        Public IDAplicacion As Integer '------------- RACB 09/08/2021
    End Structure

    Public gs_Permisos1 As String                   'Permisos Aplicación 1 - Mesa
    Public gn_Autorizaciones1 As String             'Autorizaciones Aplicación 1 - Mesa
    Public gs_Permisos2 As String                   'Permisos Aplicación 2 - Back
    Public gn_Autorizaciones2 As String             'Autorizaciones Aplicación 2 - Back

    Public gn_TotalPermisos As Integer
    Public gn_TotalAutorizaciones As Integer
    Public ga_Permisos() As TipoPermiso
    Public ga_Autorizaciones() As TipoAutorizacion 'Arreglo para almacenar las autorizaciones
    Public gn_MaxPermiso As Integer
    Public gn_MaxAutorizacion As Integer

    Public Relogin As Boolean                       'Para saber si se activo la opción de Relogueo

    'variable usada para modulo de chequeras
    Public iCtaCliente As String = ""
    Public gs_FormatoFecha As String = "DD-MM-AAAA"

    'VARIABLES GLOBALES DE TIPO STRING
    Public gs_Sql As String = ""
    Public PATHGOS As String = ""
    Public PAGISVIEWER As String

    'variable usada para modulo de AICED captura
    Public msHoraCap As String = ""

    '--------------------------------------------------------  RACB 20/01/2021
    'variables usadas para modulo de Genera Archivo Interfase
    Public gs_HoraSistema As String = ""
    Public gs_FechaHoy As String = ""                'Variable que guarda la fecha del sistema en formato 'mm-dd-yy'
    Public GPATH As String = ""                      'Variable para almacenar la ruta de los Reportes del Sistema
    Public GsRepTDOver As String
    Public DEFAULT_SRVR As String                    'Variable para almacenar el nombre del Servidor a Utilizar
    Public iPass_gn_Usuario As Integer
    Public sPass_Usuario As String
    Public sPass_Contraseña As String
    Public gn_Linea As Byte
    Public iValorTransaccion As Integer = 0
    Public dTablaTransaccion As New DataTable

    Public ga_PermisosRemotos As New PermisoRemoto    'Arreglo para control de operaciones hechas con password
    Public gn_Autno_Regsi As Integer          'se utiliza para registrar operaciones TD cuando no se req. autorizacion
    Public gn_IDAutorizacion As Integer          'Numero Identity de la Autorizacion con que se registra al peticion
    Public gn_MesaRegional As Integer          'usuario mesa regional tipo tasa 2
    Public gn_Monto As Double           'Monto para autorizacion
    Public gn_OpDefinida As Integer
    Public gn_Operacion_Definida As Integer          'Numero de Operacion Definida Global de la operacion por autorizar
    Public gn_OrigenTipoTasa3 As Integer          'origen cuando tipo tasa es 3
    Public gn_Peticion As Long             'Numero Identity con el que se registra la petición
    Public gn_Pide_Autorizacion As Boolean          'si el tipo de tasa requiere autorizacion
    Public gn_Plazo As Integer          'Plazo de la Operacion con SobreTasa
    Public gn_Registra_Operacion As Boolean          'si el tipo de tasa registra operacion
    Public gn_SobreTasa As Double           'Monto de la SobreTasa
    Public gn_Tasa As Double           'Monto de la Tasa Normal
    Public gn_Tipo_Tasa As Integer          'tipo de tasa
    Public gs_Comentario As String           'Comentario de Peticion de Autorizacion
    Public gs_Cuenta_Cliente As String           'Numero de cuenta del cliente para la autorizacion de operacion
    Public gs_Respuesta As String           'Comentario de Respuesta a la Autorizacion
    Public gn_Autorizaciones As String           'Numero de Autorizaciones asignados al usuario que firma la aplicacion
    Public gb_CambioAutorizacion As Boolean          'Bandera para detección de cambios en autorizaciones
    Public gb_OperacionConPassword As Boolean          'Bandera para deteccion de operaciones con password
    Public gb_Autorizacion As Boolean          'Bandera para validacion de autorizaciones
    Public gs_Autorizacion As String           'Nombre de la autorizacion por evaluar
    Public gs_ComentarioAutorizacion As String       'Comentario por insertar en el evento de autorizacion
    Public gn_UsuarioAutoriza As Integer      'Usuario utilizado para la autorización
    Public gn_NumeroAutorizacion As Byte         'Numero de autorización utilizada en la validación
    Public GsPermisoAgencia As String   'Variable utilizada para Permiso Agencias
    Public GsTipoFuente As String = "0"      'Variable para complemento 
    Public GsFuente As String = "0"          'Variable para complemento 
    Public GsPlaza As String = "0"           'Variable para complemento 
    Public GsPlazaBack As String = "0"           'Variable para complemento 
    Public GsCentroRegional As String = "0"           'Variable para complemento 
    '--------------------------------------------------------  RACB 20/01/2021

#End Region
End Module
