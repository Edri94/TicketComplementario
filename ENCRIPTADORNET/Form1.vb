Option Strict Off
Option Explicit On
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Form1
    Implements IDisposable



    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider
    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Function Encrypt(ByVal stringToEncrypt As String, Optional ByVal key As String = "BBVA BANCOMER") As String
        On Error Resume Next
        If stringToEncrypt = "" Then
            stringToEncrypt = "BBVA BANCOMER"
        End If
        DES.Key = MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Public Function Decrypt(ByVal encryptedString As String, Optional ByVal key As String = "BBVA BANCOMER") As String
        Try
            If encryptedString = "" Then
                Return ""
                Exit Function
            End If

            DES.Key = MD5Hash(key)
            DES.Mode = CipherMode.ECB
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Return ""
        End Try

        Return ""
    End Function

    Private Sub Desencripta_Click(sender As Object, e As EventArgs) Handles Desencripta.Click
        Dim texto As String

        texto = Trim(txtTexto.Text)
        txtResutado.Text = Decrypt(texto)
    End Sub

    Private Sub Encripta_Click(sender As Object, e As EventArgs) Handles Encripta.Click
        Dim texto As String

        texto = Trim(txtTexto.Text)
        txtResutado.Text = Encrypt(texto)
    End Sub


    Private Sub btConexionbd_Click(sender As Object, e As EventArgs) Handles btConexionbd.Click
        
        Dim d As New Datasource
        Dim dtlogin As New DataTable

        If My.Computer.Network.IsAvailable = False Then
            lbError.Text = "EL EQUIPO NO TIENE CONEXION DE RED"
            Exit Sub
        Else
            'dtlogin = d.login("B0756465")

            gvDatos.DataSource = dtlogin

            If Not Err.Number = 0 Then
                MsgBox("Error al firmarse en el sistema", Err.Description)
                Err.Clear()
            End If
        End If




    End Sub



End Class
